import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:todo_flutter/models/post.model.dart';

void main() => runApp(const MyApp());

class MyApp extends StatefulWidget {
  const MyApp({super.key});

  @override
  State<StatefulWidget> createState() {
    return _MyAppState();
  }
}

class _MyAppState extends State<MyApp> {
  List<String> items = [];
  List<Post> posts = [];
  bool isLoading = false;

  Future<void> loadDataFromApi() async {
    // Giả lập API delay 2 giây
    await Future.delayed(const Duration(seconds: 2));
    // Đây là dữ liệu giả, bạn thay bằng kết quả từ API thật
    final fetchedItems = List.generate(10, (i) => 'API Item ${i + 1}');
    setState(() {
      items = fetchedItems;
    });
  }

  Future<void> fetchPosts() async {
    setState(() => isLoading = true);

    try {
      final response = await http.get(
        Uri.parse('https://jsonplaceholder.typicode.com/posts'),
        headers: {
          'User-Agent':
              'Mozilla/5.0 (Windows NT 10.0; Win64; x64) '
              'AppleWebKit/537.36 (KHTML, like Gecko) '
              'Chrome/115.0.0.0 Safari/537.36',
          'Accept': 'application/json',
        },
      );
      print('Fetch response:  ${response.statusCode}');

      if (response.statusCode == 200) {
        final List<dynamic> jsonList = jsonDecode(response.body);
        final List<Post> loadedPosts = jsonList
            .map((json) => Post.fromJson(json))
            .toList();

        setState(() {
          posts = loadedPosts;
          isLoading = false;
        });
      } else {
        setState(() => isLoading = false);
        // throw Exception('Failed to load posts');
      }
    } catch (e) {
      print('Fetch failed: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    const String appTitle = 'Flutter layout';
    return MaterialApp(
      title: appTitle,
      home: Scaffold(
        appBar: AppBar(title: const Text(appTitle)),
        body: SingleChildScrollView(
          child: Column(
            children: [
              ImageSection(imagePath: 'lib/images/bg.jpeg'),
              TitleSection(name: 'Son Tay', location: 'Quan Ngai, VN'),
              ButtonSection(
                onLoadPressed: loadDataFromApi,
                handleFetchPosts: fetchPosts,
              ),
              TextSection(
                description:
                    'Lake Oeschinen lies at the foot of the Blüemlisalp in the '
                    'Bernese Alps. Situated 1,578 meters above sea level, it '
                    'is one of the larger Alpine Lakes. A gondola ride from '
                    'Kandersteg, followed by a half-hour walk through pastures '
                    'and pine forest, leads you to the lake, which warms to 20 '
                    'degrees Celsius in the summer. Activities enjoyed here '
                    'include rowing, and riding the summer toboggan run.',
              ),
              ListViewSection(items: items),
              ListPostSection(posts: posts, isLoading: isLoading),
            ],
          ),
        ),
      ),
    );
  }
}

class TitleSection extends StatelessWidget {
  const TitleSection({super.key, required this.name, required this.location});

  final String name;
  final String location;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(32),
      child: Row(
        children: [
          Expanded(
            /*1*/
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                /*2*/
                Padding(
                  padding: const EdgeInsets.only(bottom: 8),
                  child: Text(
                    name,
                    style: const TextStyle(fontWeight: FontWeight.bold),
                  ),
                ),
                Text(location, style: TextStyle(color: Colors.grey[500])),
              ],
            ),
          ),
          /*3*/
          Icon(Icons.star, color: Colors.red[500]),
          const Text('41'),
        ],
      ),
    );
  }
}

class ButtonSection extends StatelessWidget {
  const ButtonSection({
    super.key,
    required this.onLoadPressed,
    required this.handleFetchPosts,
  });

  final VoidCallback onLoadPressed;
  final VoidCallback handleFetchPosts;

  @override
  Widget build(BuildContext context) {
    final Color color = Theme.of(context).primaryColorDark;
    return SizedBox(
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          ButtonWithText(
            icon: Icons.call,
            label: 'Call',
            color: color,
            onTap: () {
              print('Call Button tapped');
            },
          ),
          ButtonWithText(
            icon: Icons.message,
            label: 'Post',
            color: color,
            onTap: handleFetchPosts,
          ),
          ButtonWithText(
            icon: Icons.message,
            label: 'Load',
            color: color,
            onTap: onLoadPressed,
          ),
          ButtonWithText(
            icon: Icons.message,
            label: 'List view',
            color: color,
            onTap: () {
              print('Load Button tapped');
            },
          ),
        ],
      ),
    );
  }
}

class ButtonWithText extends StatelessWidget {
  const ButtonWithText({
    super.key,
    required this.icon,
    required this.label,
    required this.color,
    required this.onTap,
  });

  final IconData icon;
  final String label;
  final Color color;
  final VoidCallback? onTap;

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap!,
      child: Column(
        mainAxisSize: MainAxisSize.min,
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Icon(icon, color: color),
          Text(
            label,
            style: TextStyle(
              color: color,
              fontSize: 14,
              fontWeight: FontWeight.w400,
            ),
          ),
        ],
      ),
    );
  }
}

class TextSection extends StatelessWidget {
  const TextSection({super.key, required this.description});

  final String description;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(12),
      child: Text(description, softWrap: true),
    );
  }
}

class ImageSection extends StatelessWidget {
  const ImageSection({super.key, required this.imagePath});

  final String imagePath;
  @override
  Widget build(BuildContext context) {
    return Image.asset(imagePath, fit: BoxFit.cover, height: 220, width: 600);
  }
}

class ListViewSection extends StatelessWidget {
  const ListViewSection({super.key, required this.items});
  final List<String> items;

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.symmetric(vertical: 20),
      height: 200,
      child: items.isEmpty
          ? const Center(child: Text("No data loaded"))
          : ListView.builder(
              itemCount: items.length,
              itemBuilder: (context, index) => ListTile(
                leading: const Icon(Icons.list),
                title: Text(items[index]),
              ),
            ),
      // child: ListView(
      //   children: items
      //       .map(
      //         (txt) => ListTile(leading: Icon(Icons.phone), title: Text(txt)),
      //       )
      //       .toList(),
      // ),
    );
  }
}

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
