
import 'package:flutter/material.dart';
import 'package:todo_flutter/domain/entities/post.dart';

class ListPostSection extends StatelessWidget {
  const ListPostSection({
    super.key,
    required this.posts,
    required this.isLoading,
  });
  final List<Post> posts;
  final bool isLoading;

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.symmetric(vertical: 20),
      height: 600,
      child: (isLoading)
          ? const CircularProgressIndicator()
          : ListView.builder(
              itemCount: posts.length,
              itemBuilder: (context, index) {
                final post = posts[index];
                return ListTile(
                  leading: Text(post.id.toString()),
                  title: Text(post.title),
                );
              },
            ),
    );
  }
}