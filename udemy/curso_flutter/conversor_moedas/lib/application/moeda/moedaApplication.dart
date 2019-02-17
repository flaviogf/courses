import 'package:conversor_moedas/domain/moeda/queryHandlers/moedaQueryHandler.dart';
import 'package:conversor_moedas/domain/moeda/models/moeda.dart';

class MoedaApplication {
  MoedaQueryHandler _moedaQueryHandler;

  MoedaApplication(this._moedaQueryHandler);

  Future<Map<String, Moeda>> moedas() {
    return _moedaQueryHandler.moedas();
  }
}
