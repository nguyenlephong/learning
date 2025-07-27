import 'package:flutter/material.dart';
import 'package:todo_flutter/domain/entities/post.dart';
import 'package:todo_flutter/features/poc/presentation/widgets/widgets.dart';
import 'package:todo_flutter/services/post_service.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<StatefulWidget> createState() {
    return _HomePageState();
  }
}

class _HomePageState extends State<HomePage> {
  List<String> items = [];
  List<Post> posts = [];
  bool isLoading = false;

  @override
  void initState() {
    super.initState();
    PostService().loadDataFromApi().then((resp) => {items = resp});
    print('init state called');
  }

  Future<void> loadDataFromApi() async {
    PostService().loadDataFromApi().then((resp) => {items = resp});
    print('load api via button called');
  }

  Future<void> fetchPosts() async {
    setState(() => isLoading = true);

    try {
      final Future<List<Post>> response = PostService().getPosts();
      response.then(
        (loadedPosts) => {
          setState(() {
            posts = loadedPosts;
            isLoading = false;
          }),
        },
      );
    } catch (e) {
      print('Fetch failed: $e');
      setState(() => isLoading = false);
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
