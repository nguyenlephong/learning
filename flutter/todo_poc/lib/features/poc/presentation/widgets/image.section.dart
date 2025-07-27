
import 'package:flutter/material.dart';

class ImageSection extends StatelessWidget {
  const ImageSection({super.key, required this.imagePath});

  final String imagePath;
  @override
  Widget build(BuildContext context) {
    return Image.asset(imagePath, fit: BoxFit.cover, height: 220, width: 600);
  }
}