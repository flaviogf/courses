import 'package:flutter/material.dart';

void main() {
  runApp(MaterialApp(
    title: "Calculadora IMC",
    home: Home(),
  ));
}

class Home extends StatefulWidget {
  @override
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {
  TextEditingController _textPeso = TextEditingController();
  TextEditingController _textAltura = TextEditingController();
  GlobalKey<FormState> _validador = GlobalKey<FormState>();
  String _textImc = "Informe seus dados";

  void _reseta() {
    _textPeso.clear();
    _textAltura.clear();

    setState(() {
      _textImc = "Infome seus dados";
    });
  }

  void _imc() {
    if (!_validador.currentState.validate()) return;
    var peso = double.tryParse(_textPeso.text) ?? 0;
    var altura = double.tryParse(_textAltura.text) ?? 0;
    if (peso == 0 || altura == 0) return;
    var imc = peso / (altura * altura);
    setState(() {
      _textImc = imc.toStringAsPrecision(4);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.orange,
        title: Text(
          "Calculadora IMC",
          textAlign: TextAlign.center,
        ),
        actions: <Widget>[
          IconButton(icon: Icon(Icons.refresh), onPressed: _reseta)
        ],
      ),
      body: SingleChildScrollView(
        padding: EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: <Widget>[
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[
                Icon(
                  Icons.people,
                  color: Colors.orange,
                  size: 75.0,
                )
              ],
            ),
            Form(
              key: _validador,
              child: Column(
                children: <Widget>[
                  TextFormField(
                    decoration: InputDecoration(
                        labelText: "Peso",
                        labelStyle: TextStyle(color: Colors.orange),
                        focusedBorder: UnderlineInputBorder(
                            borderSide: BorderSide(color: Colors.orange))),
                    keyboardType: TextInputType.number,
                    controller: _textPeso,
                    validator: (texto) =>
                        texto.isEmpty ? "Informe o peso" : null,
                  ),
                  TextFormField(
                    decoration: InputDecoration(
                        labelText: "Altura",
                        labelStyle: TextStyle(color: Colors.orange),
                        focusedBorder: UnderlineInputBorder(
                            borderSide: BorderSide(color: Colors.orange))),
                    keyboardType: TextInputType.number,
                    controller: _textAltura,
                    validator: (texto) =>
                        texto.isEmpty ? "Informe a altura" : null,
                  ),
                  Container(
                    margin: EdgeInsets.only(top: 8),
                    width: double.infinity,
                    child: RaisedButton(
                      onPressed: _imc,
                      child: Text(
                        "Calcular",
                        style: TextStyle(color: Colors.white),
                      ),
                      color: Colors.orange,
                    ),
                  ),
                  Container(
                    margin: EdgeInsets.only(top: 8),
                    child: Text(
                      _textImc,
                      style: TextStyle(color: Colors.orange),
                    ),
                  )
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}
