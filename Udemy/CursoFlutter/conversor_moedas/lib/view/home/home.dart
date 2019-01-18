import 'package:flutter/material.dart';
import 'package:conversor_moedas/view/widgets/campoTexto.dart';
import 'package:conversor_moedas/domain/moeda/models/real.dart';
import 'package:conversor_moedas/domain/moeda/models/dolar.dart';
import 'package:conversor_moedas/domain/moeda/models/euro.dart';

class Home extends StatefulWidget {
  Real _real;
  Dolar _dolar;
  Euro _euro;

  Home(this._real, this._dolar, this._euro);

  @override
  _HomeState createState() => _HomeState(this._real, this._dolar, this._euro);
}

class _HomeState extends State<Home> {
  Real _real;
  Dolar _dolar;
  Euro _euro;
  TextEditingController _realController = TextEditingController();
  TextEditingController _dolarController = TextEditingController();
  TextEditingController _euroController = TextEditingController();

  _HomeState(this._real, this._dolar, this._euro);

  _entradaReais(String texto) {
    var valor = double.tryParse(texto) ?? 0;
    var dolar = _real.dolar(valor, _dolar);
    var euro = _real.euro(valor, _euro);
    _dolarController.text = dolar.toStringAsFixed(2);
    _euroController.text = euro.toStringAsFixed(2);
  }

  _entradaDolar(String texto) {
    var valor = double.tryParse(texto) ?? 0;
    var real = _dolar.real(valor, _real);
    var euro = _real.euro(real, _euro);
    _realController.text = real.toStringAsFixed(2);
    _euroController.text = euro.toStringAsFixed(2);
  }

  _entradaEuros(String texto) {
    var valor = double.tryParse(texto) ?? 0;
    var real = _euro.real(valor, _real);
    var dolar = _real.dolar(real, _dolar);
    _realController.text = real.toStringAsFixed(2);
    _dolarController.text = dolar.toStringAsFixed(2);
  }

  _limpaFormulario() {
    _realController.clear();
    _dolarController.clear();
    _euroController.clear();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.black,
      appBar: AppBar(
        backgroundColor: Colors.amber,
        title: Text(
          "\$ Conversor \$",
          style: TextStyle(color: Colors.white),
        ),
        centerTitle: true,
      ),
      body: SingleChildScrollView(
        padding: EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: <Widget>[
            Icon(
              Icons.monetization_on,
              color: Colors.amber,
              size: 100.0,
            ),
            Divider(),
            CampoTexto(
              label: "Reais",
              prefixo: "R\$ ",
              onChanged: _entradaReais,
              controller: _realController,
            ),
            Divider(),
            CampoTexto(
              label: "Dolar",
              prefixo: "US\$ ",
              onChanged: _entradaDolar,
              controller: _dolarController,
            ),
            Divider(),
            CampoTexto(
              label: "Euros",
              prefixo: "€ ",
              onChanged: _entradaEuros,
              controller: _euroController,
            ),
            Divider(),
            RaisedButton(
              child: Text("Limpar", style: TextStyle(color: Colors.white)),
              onPressed: _limpaFormulario,
              color: Colors.amber,
            )
          ],
        ),
      ),
    );
  }
}
