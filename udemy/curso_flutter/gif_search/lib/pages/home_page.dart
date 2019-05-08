import 'package:flutter/cupertino.dart';

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return CupertinoApp(
      title: "Gif search",
      home: CupertinoPageScaffold(
        child: Center(
          child: Text("Gif search"),
        ),
      ),
    );
  }
}
