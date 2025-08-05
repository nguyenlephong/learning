using System.Text.Json;
using Microsoft.Extensions.Logging;

public class VietQRTestRunner
{
  private readonly IVietQRService _vietQRService;
  private readonly ILogger<VietQRTestRunner> _logger;

  public VietQRTestRunner(IVietQRService vietQRService, ILogger<VietQRTestRunner> logger)
  {
    _vietQRService = vietQRService;
    _logger = logger;
  }

  public async Task<TestRunResult> RunTestsFromJsonAsync(string jsonFilePath)
  {
    try
    {
      var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
      var testSuite = JsonSerializer.Deserialize<VietQRTestSuite>(jsonContent, new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true,
        AllowTrailingCommas = true
      });

      if (testSuite?.TestCases == null)
      {
        throw new InvalidOperationException("Invalid test suite format");
      }

      return await RunTestSuiteAsync(testSuite);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error reading or parsing test file: {FilePath}", jsonFilePath);
      throw;
    }
  }

  public async Task<TestRunResult> RunTestSuiteAsync(VietQRTestSuite testSuite)
  {
    var result = new TestRunResult
    {
      TotalTests = testSuite.TestCases.Length,
      TestSuiteInfo = $"{testSuite.Description} (v{testSuite.Version})"
    };

    _logger.LogInformation("Starting test suite: {Description}", testSuite.Description);

    foreach (var testCase in testSuite.TestCases)
    {
      var testResult = await RunSingleTestAsync(testCase);
      result.TestResults.Add(testResult);

      if (testResult.Passed)
      {
        result.PassedTests++;
        _logger.LogInformation("✓ {TestName}: PASSED", testCase.TestName);
      }
      else
      {
        result.FailedTests++;
        _logger.LogError("✗ {TestName}: FAILED - {ErrorMessage}", testCase.TestName, testResult.ErrorMessage);
      }
    }

    result.SuccessRate = result.TotalTests > 0 ? (double)result.PassedTests / result.TotalTests * 100 : 0;

    _logger.LogInformation("Test suite completed: {Passed}/{Total} tests passed ({SuccessRate:F1}%)",
      result.PassedTests, result.TotalTests, result.SuccessRate);

    return result;
  }

  private async Task<SingleTestResult> RunSingleTestAsync(VietQRTestCase testCase)
  {
    var result = new SingleTestResult
    {
      TestName = testCase.TestName,
      Description = testCase.Description
    };

    try
    {
      var startTime = DateTime.UtcNow;

      string actualQRCode;
      Exception? thrownException = null;

      try
      {
        // Use the helper method to get amount as double
        var amount = testCase.Input.GetAmountAsDouble();

        // Call the specific function GenerateWithParams
        actualQRCode = _vietQRService.GenerateWithParams(
          testCase.Input.OneTime,
          testCase.Input.ServiceType,
          amount,
          testCase.Input.BankBIN,
          testCase.Input.AccountNumber,
          testCase.Input.Note,
          testCase.Input.Currency,
          testCase.Input.CountryCode
        );
      }
      catch (Exception ex)
      {
        thrownException = ex;
        actualQRCode = "";
      }

      result.ExecutionTime = DateTime.UtcNow - startTime;

      // Validate results
      if (testCase.ShouldThrowException)
      {
        result.Passed = ValidateException(thrownException, testCase.ExpectedException, result);
      }
      else
      {
        if (thrownException != null)
        {
          result.Passed = false;
          result.ErrorMessage = $"Unexpected exception: {thrownException.Message}";
          result.ActualOutput = $"Exception: {thrownException.GetType().Name}";
        }
        else
        {
          result.Passed = ValidateQRCodeOutput(actualQRCode, testCase.Expected, result);
          result.ActualOutput = actualQRCode;
        }
      }
    }
    catch (Exception ex)
    {
      result.Passed = false;
      result.ErrorMessage = $"Test execution error: {ex.Message}";
      _logger.LogError(ex, "Error executing test {TestName}", testCase.TestName);
    }

    return result;
  }

  private bool ValidateException(Exception? thrownException, string expectedExceptionType, SingleTestResult result)
  {
    if (thrownException == null)
    {
      result.ErrorMessage = "Expected exception but none was thrown";
      return false;
    }

    if (!string.IsNullOrEmpty(expectedExceptionType))
    {
      var actualExceptionType = thrownException.GetType().Name;
      if (!actualExceptionType.Equals(expectedExceptionType, StringComparison.OrdinalIgnoreCase))
      {
        result.ErrorMessage = $"Expected {expectedExceptionType} but got {actualExceptionType}";
        return false;
      }
    }

    result.ActualOutput = $"Exception: {thrownException.GetType().Name} - {thrownException.Message}";
    return true;
  }

  private bool ValidateQRCodeOutput(string actualQRCode, VietQRTestOutput expected, SingleTestResult result)
  {
    if ((expected.ExpectedQRCode) is null)
    {
      result.ErrorMessage = "Expected QR code is not null";
      return false;
    }

    if (actualQRCode != expected.ExpectedQRCode)
    {
      result.ErrorMessage = $"QR code mismatch.\nExpected: {expected.ExpectedQRCode}\nActual:   {actualQRCode}";
      return false;
    }

    return true;
  }
}

public class TestRunResult
{
  public int TotalTests { get; set; }
  public int PassedTests { get; set; }
  public int FailedTests { get; set; }
  public double SuccessRate { get; set; }
  public string TestSuiteInfo { get; set; } = "";
  public List<SingleTestResult> TestResults { get; set; } = new();

  public TimeSpan TotalExecutionTime =>
    TimeSpan.FromMilliseconds(TestResults.Sum(t => t.ExecutionTime.TotalMilliseconds));
}

public class SingleTestResult
{
  public string TestName { get; set; } = "";
  public string Description { get; set; } = "";
  public bool Passed { get; set; }
  public string ErrorMessage { get; set; } = "";
  public string ActualOutput { get; set; } = "";
  public TimeSpan ExecutionTime { get; set; }
}