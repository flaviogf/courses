import 'package:employe_search/domain/query/list_employ_query_result.dart';

abstract class EmployeRepository {
  List<ListEmployeQueryResult> all();
}
