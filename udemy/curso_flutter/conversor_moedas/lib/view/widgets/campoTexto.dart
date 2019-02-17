import 'package:flutter/material.dart';

class CampoTexto extends StatelessWidget {
  String label;
  String prefixo;
  Function onChanged;
  TextEditingController controller;

  CampoTexto({this.label, this.prefixo, this.onChanged, this.controller});

  @override
  Widget build(BuildContext context) {
    return TextField(
      decoration: InputDecoration(
          labelText: label,
          labelStyle: TextStyle(color: Colors.amber),
          border: OutlineInputBorder(),
          prefixText: prefixo),
      style: TextStyle(color: Colors.white),
      onChanged: onChanged,
      controller: controller,
    );
  }
}
