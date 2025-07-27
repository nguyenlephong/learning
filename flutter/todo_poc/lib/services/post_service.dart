import 'package:todo_flutter/data/remote/post_api.dart';
import 'package:todo_flutter/domain/entities/post.dart';

class PostService {
  final _api = PostApi();

  Future<List<Post>> getPosts() async => await _api.fetchPosts();
}