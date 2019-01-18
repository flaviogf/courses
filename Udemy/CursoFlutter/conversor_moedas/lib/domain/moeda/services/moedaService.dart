import 'package:conversor_moedas/infra/services/requestService.dart';
import 'package:conversor_moedas/infra/config/config.dart';
import 'package:conversor_moedas/domain/moeda/queries/moedaQueryResult.dart';

class MoedaService {
  final RequestService _requestService;
  final Config _config;

  MoedaService(this._requestService, this._config);

  Future<Map<String, MoedaQueryResult>> moedas() async {
    var url = "${_config.api}/quotations?format=json&key=61795436";
    var resposta = await _requestService.get(url);
    var moedas = resposta["results"]["currencies"];
    var dolar = moedas["USD"];
    var euro = moedas["EUR"];
    return {
      "real": MoedaQueryResult("real", 1.0),
      "dolar": MoedaQueryResult(dolar["name"], dolar["buy"]),
      "euro": MoedaQueryResult(euro["name"], euro["buy"])
    };
  }
}
