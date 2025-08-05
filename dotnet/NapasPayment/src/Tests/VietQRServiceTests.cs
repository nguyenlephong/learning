namespace NapasPayment.Tests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

public class VietQRServiceTests
    {
        private readonly ITestOutputHelper _output;
        private readonly VietQRTestRunner _testRunner;
        private readonly IVietQRService _vietQRService;

        public VietQRServiceTests(ITestOutputHelper output)
        {
            _output = output;
            
            var services = new ServiceCollection();
            services.AddLogging(builder => builder.AddConsole());
            services.AddScoped<IVietQRService, VietQRService>();
            services.AddScoped<VietQRTestRunner>();
            
            var serviceProvider = services.BuildServiceProvider();
            _vietQRService = serviceProvider.GetRequiredService<IVietQRService>();
            _testRunner = serviceProvider.GetRequiredService<VietQRTestRunner>();
        }

        [Fact]
        public async Task RunTestSuite_FromJsonFile()
        {
            // Arrange
            var testFilePath = Path.Combine("src", "Tests", "TestData", "vietqr_testcases.json");
            
            // Act & Assert
            if (File.Exists(testFilePath))
            {
                var result = await _testRunner.RunTestsFromJsonAsync(testFilePath);
                
                // Log results
                _output.WriteLine($"Test Suite: {result.TestSuiteInfo}");
                _output.WriteLine($"Total Tests: {result.TotalTests}");
                _output.WriteLine($"Passed: {result.PassedTests}");
                _output.WriteLine($"Failed: {result.FailedTests}");
                _output.WriteLine($"Success Rate: {result.SuccessRate:F1}%");
                _output.WriteLine($"Total Execution Time: {result.TotalExecutionTime}");
                
                foreach (var testResult in result.TestResults.Where(t => !t.Passed))
                {
                    _output.WriteLine($"FAILED: {testResult.TestName} - {testResult.ErrorMessage}");
                }
                
                Assert.True(result.SuccessRate == 100, $"Not all tests passed. Success rate: {result.SuccessRate:F1}%");
            }
            else
            {
                _output.WriteLine($"Test file not found: {testFilePath}");
                _output.WriteLine("Skipping JSON-based tests");
            }
        }

    }