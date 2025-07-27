

import 'package:flutter/material.dart';

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