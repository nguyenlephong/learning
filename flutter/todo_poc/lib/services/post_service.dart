import 'package:todo_flutter/data/remote/list_api.dart';
import 'package:todo_flutter/data/remote/post_api.dart';
import 'package:todo_flutter/domain/entities/post.dart';

class PostService {
  final _api = PostApi();
  final _apiList = ListApi();

  Future<List<Post>> getPosts() async => await _api.fetchPosts();
  Future<List<String>> loadDataFromApi() async => await _apiList.loadListOfString();
}