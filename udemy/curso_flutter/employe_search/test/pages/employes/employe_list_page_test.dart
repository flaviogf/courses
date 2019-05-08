import 'package:employe_search/domain/query/list_employ_query_result.dart';
import 'package:employe_search/domain/repositories/employe_repository.dart';
import 'package:employe_search/pages/employes/employe_list_page.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';

class MockEmployeRepositroy extends Mock implements EmployeRepository {}

void main() {
  EmployeListPage _employeListPage;
  MockEmployeRepositroy _employRepository;

  setUp(() {
    _employRepository = MockEmployeRepositroy();
    _employeListPage = EmployeListPage(employeRepository: _employRepository);
  });

  testWidgets("Should page contains title 'Colaboradores'",
      (WidgetTester tester) async {
    await tester.pumpWidget(_employeListPage);

    expect(find.text("Colaboradores"), findsOneWidget);
  });

  testWidgets("Should page contains a list of employes",
      (WidgetTester tester) async {
    final steve = ListEmployeQueryResult(
        name: "Steve", image: "steve.png", role: "Avenger");

    when(_employRepository.all()).thenReturn([steve]);

    await tester.pumpWidget(_employeListPage);

    expect(find.text("Steve"), findsOneWidget);
  });
}
