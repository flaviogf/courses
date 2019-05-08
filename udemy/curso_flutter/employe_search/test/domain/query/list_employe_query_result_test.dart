import 'package:employe_search/domain/query/list_employ_query_result.dart';
import 'package:flutter_test/flutter_test.dart';

void main() {
  ListEmployeQueryResult _steve;

  setUp(() {
    _steve = ListEmployeQueryResult(
        name: "Steve", image: "steve.png", role: "soldier");
  });

  test("Should employe contains name", () {
    expect("Steve", equals(_steve.name));
  });

  test("Should employe contains image", () {
    expect("steve.png", equals(_steve.image));
  });

  test("Should employe contains role", () {
    expect("soldier", equals(_steve.role));
  });
}
