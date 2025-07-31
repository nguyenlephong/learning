import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class AppBarComponent extends StatelessWidget implements PreferredSizeWidget {
  const AppBarComponent({super.key});

  @override
  Widget build(BuildContext context) {
    return AppBar(
      title: const Text(
        'TODO',
        style: TextStyle(
          color: Colors.black,
          fontSize: 18,
          fontWeight: FontWeight.w400,
        ),
      ),
      backgroundColor: Colors.white,
      centerTitle: true,
      elevation: 0.0,
      leading: Container(
        alignment: Alignment.center,
        margin: EdgeInsets.all(8),
        child: SvgPicture.asset(
          'lib/assets/icons/arrow_left_ic.svg',
          width: 20,
          height: 20,
        ),
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(24),
          color: Color(0xfff7f8f8),
        ),
      ),
      actions: [
        Container(
          alignment: Alignment.center,
          margin: EdgeInsets.all(8),
          width: 40,
          child: SvgPicture.asset(
            'lib/assets/icons/dots_ic.svg',
            width: 6,
            height: 6,
          ),
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(24),
            color: Color(0xfff7f8f8),
          ),
        ),
      ],
    );
  }

  @override
  Size get preferredSize => Size.fromHeight(kToolbarHeight);
}
