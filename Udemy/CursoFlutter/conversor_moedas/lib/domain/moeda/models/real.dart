import 'package:conversor_moedas/domain/moeda/models/moeda.dart';
import 'package:conversor_moedas/domain/moeda/models/dolar.dart';
import 'package:conversor_moedas/domain/moeda/models/euro.dart';

class Real extends Moeda {
  Real(double valor) : super(valor);

  double dolar(double valor, Dolar dolar) {
    return this.valor * valor * dolar.valor;
  }

  double euro(double valor, Euro euro) {
    return this.valor * valor * euro.valor;
  }
}
