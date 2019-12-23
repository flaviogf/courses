import 'package:flutter/material.dart';

class CenteredMessage extends StatelessWidget {
  final String message;
  final IconData icon;

  CenteredMessage({
    Key key,
    this.message,
    this.icon,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: <Widget>[
          Visibility(
            child: Icon(
              icon,
              size: 52.0,
            ),
            visible: icon != null,
          ),
          Text(
            message,
            style: TextStyle(fontSize: 24.0),
          ),
        ],
      ),
    );
  }
}
