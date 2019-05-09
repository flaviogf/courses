import 'package:employe_search/domain/query/list_employ_query_result.dart';
import 'package:employe_search/domain/repositories/employe_repository.dart';
import 'package:employe_search/pages/employes/employe_list_page.dart';
import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:image_test_utils/image_test_utils.dart';
import 'package:mockito/mockito.dart';

class MockEmployeRepositroy extends Mock implements EmployeRepository {}

void main() {
  MockEmployeRepositroy _employRepository;
  MaterialApp _employePage;
  ListEmployeQueryResult _steve;

  setUp(() {
    _steve = ListEmployeQueryResult(
      name: "Steve",
      image: "https://source.unsplash.com/random/400x200",
      role: "Avenger",
    );

    _employRepository = MockEmployeRepositroy();
    when(_employRepository.all()).thenReturn([_steve]);

    _employePage = MaterialApp(
        home: EmployeListPage(
      employeRepository: _employRepository,
    ));
  });

  testWidgets("Should page contains title 'Colaboradores'",
      (WidgetTester tester) {
    provideMockedNetworkImages(() async {
      await tester.pumpWidget(_employePage);

      expect(find.text("Colaboradores"), findsOneWidget);
    });
  });

  testWidgets("Should page contain employe 'Steve'",
      (WidgetTester tester) async {
    provideMockedNetworkImages(() async {
      await tester.pumpWidget(_employePage);

      expect(find.text(_steve.name), findsOneWidget);
    });
  });
}
