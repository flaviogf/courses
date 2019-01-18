import 'package:flutter/material.dart';

void main() {
  runApp(MaterialApp(title: "Contador de Pessoas", home: Home()));
}

class Home extends StatefulWidget {
  @override
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {
  int _pessoas = 0;
  String _infoTexto = "Pode entrar";

  void _atualizaPessoas(int quantidade) {
    setState(() {
      _pessoas += quantidade;

      if (_pessoas > 10) {
        _infoTexto = "Lotado";
      } else if (_pessoas < 0) {
        _infoTexto = "Mundo invertido!?";
      } else {
        _infoTexto = "Pode entrar";
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return Stack(
      fit: StackFit.expand,
      children: <Widget>[
        Image.asset(
          "images/restaurant.jpg",
          fit: BoxFit.cover,
          height: 1000.0,
        ),
        Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Text(
              "Pessoas $_pessoas",
              style:
                  TextStyle(color: Colors.white, fontWeight: FontWeight.bold),
            ),
            Padding(
              padding: EdgeInsets.all(10.0),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
                  FlatButton(
                    child: Text(
                      "+1",
                      style: TextStyle(color: Colors.white, fontSize: 30.0),
                    ),
                    onPressed: () {
                      _atualizaPessoas(1);
                    },
                  ),
                  FlatButton(
                    child: Text(
                      "-1",
                      style: TextStyle(color: Colors.white, fontSize: 30.0),
                    ),
                    onPressed: () {
                      _atualizaPessoas(-1);
                    },
                  )
                ],
              ),
            ),
            Text(
              _infoTexto,
              style: TextStyle(
                  color: Colors.white,
                  fontStyle: FontStyle.italic,
                  fontSize: 30.0),
            )
          ],
        )
      ],
    );
  }
}
