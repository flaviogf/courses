import 'package:conversor_moedas/domain/moeda/services/moedaService.dart';
import 'package:conversor_moedas/domain/moeda/models/moeda.dart';
import 'package:conversor_moedas/domain/moeda/models/real.dart';
import 'package:conversor_moedas/domain/moeda/models/dolar.dart';
import 'package:conversor_moedas/domain/moeda/models/euro.dart';

class MoedaQueryHandler {
  MoedaService _moedaService;

  MoedaQueryHandler(this._moedaService);

  Future<Map<String, Moeda>> moedas() async {
    var moedas = await _moedaService.moedas();
    var real = moedas["real"];
    var dolar = moedas["dolar"];
    var euro = moedas["euro"];
    return {
      "real": Real(real.valor),
      "dolar": Dolar(dolar.valor),
      "euro": Euro(euro.valor)
    };
  }
}
