import 'package:flutter/material.dart';
import 'package:conversor_moedas/view/home/home.dart';
import 'package:conversor_moedas/application/moeda/moedaApplication.dart';
import 'package:conversor_moedas/domain/moeda/queryHandlers/moedaQueryHandler.dart';
import 'package:conversor_moedas/domain/moeda/services/moedaService.dart';
import 'package:conversor_moedas/infra/services/requestService.dart';
import 'package:conversor_moedas/infra/config/config.dart';

void main() async {
  var request = RequestService();
  var config = Config();
  var service = MoedaService(request, config);
  var queryHandler = MoedaQueryHandler(service);
  var application = MoedaApplication(queryHandler);

  var moedas = await application.moedas();
  
  var real = moedas["real"];
  var dolar = moedas["dolar"];
  var euro = moedas["euro"];

  runApp(MaterialApp(
    title: "Conversor",
    home: Home(real, dolar, euro),
    theme: ThemeData(hintColor: Colors.amber, primaryColor: Colors.amber),
  ));
}
