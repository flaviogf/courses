import 'package:flutter/material.dart';

class CustomEditor extends StatelessWidget {
  final String labelText;
  final String hintText;
  final Icon icon;
  final TextEditingController controller;
  final TextInputType keyboardType;

  const CustomEditor({
    Key key,
    this.labelText,
    this.hintText,
    this.icon,
    this.controller,
    this.keyboardType,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.all(16),
      child: TextField(
        controller: controller,
        decoration: InputDecoration(
          labelText: labelText,
          hintText: hintText,
          icon: icon,
        ),
        keyboardType: keyboardType,
        style: TextStyle(
          fontSize: 24,
        ),
      ),
    );
  }
}
