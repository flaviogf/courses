import 'package:flutter/material.dart';

class AuthenticateDialog extends StatefulWidget {
  final Function(String email, String password) confirm;

  const AuthenticateDialog({Key key, this.confirm}) : super(key: key);

  @override
  State<StatefulWidget> createState() => AuthenticateDialogState();
}

class AuthenticateDialogState extends State<AuthenticateDialog> {
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text('Authenticate'),
      content: SingleChildScrollView(
        child: ListBody(
          children: <Widget>[
            TextField(
              controller: _emailController,
              decoration: InputDecoration(
                labelText: 'Email',
              ),
            ),
            TextField(
              controller: _passwordController,
              decoration: InputDecoration(
                labelText: 'Password',
              ),
            ),
          ],
        ),
      ),
      actions: <Widget>[
        FlatButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: Text('CANCEL'),
        ),
        FlatButton(
          onPressed: () {
            final String email = _emailController.text;
            final String password = _passwordController.text;
            widget.confirm(email, password);
            Navigator.of(context).pop();
          },
          child: Text('CONFIRM'),
        )
      ],
    );
  }
}
