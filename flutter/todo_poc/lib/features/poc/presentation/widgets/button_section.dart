import 'package:flutter/material.dart';
import 'package:todo_flutter/features/poc/presentation/widgets/button_with_text.dart';

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
