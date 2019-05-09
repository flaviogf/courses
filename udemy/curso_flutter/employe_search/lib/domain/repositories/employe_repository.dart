import 'package:employe_search/domain/query/list_employ_query_result.dart';

abstract class EmployeRepository {
  List<ListEmployeQueryResult> all();
}

class HttpClientEmployeRepository implements EmployeRepository {
  @override
  List<ListEmployeQueryResult> all() {
    return [
      ListEmployeQueryResult(
        name: "Steve",
        image: "https://source.unsplash.com/random/400x200",
        role: "Avenger",
      ),
      ListEmployeQueryResult(
        name: "Tony Stark",
        image: "https://source.unsplash.com/random/400x200",
        role: "Avenger",
      ),
    ];
  }
}
