import 'package:flutter/material.dart';

void main() => runApp(ExampleSafeAreaApp());

class ExampleSafeAreaApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
        primaryColor: Colors.purple[900],
        accentColor: Colors.purpleAccent[700],
      ),
      home: Scaffold(
        appBar: AppBar(
          title: Text("Example Safe Area"),
        ),
        body: SafeArea(
          child: ListView(
            children: <Widget>[
              Card(
                child: ListTile(
                  leading: Icon(
                    Icons.person,
                    color: Theme.of(context).accentColor,
                  ),
                  title: Text('Flavio'),
                  subtitle: Text("Programmer"),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
