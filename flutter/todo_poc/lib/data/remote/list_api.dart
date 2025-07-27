class ListApi {
  Future<List<String>> loadListOfString() async {
    // Giả lập API delay 2 giây
    await Future.delayed(const Duration(seconds: 2));
    // Đây là dữ liệu giả, bạn thay bằng kết quả từ API thật
    final fetchedItems = List.generate(10, (i) => 'API Item ${i + 1}');
    return fetchedItems;
  }
}
