import 'package:employe_search/domain/repositories/employe_repository.dart';
import 'package:employe_search/pages/employes/employe_list_page.dart';
import 'package:flutter/material.dart';

final employeRepository = HttpClientEmployeRepository();

void main() {
  runApp(MaterialApp(
    theme: ThemeData(
      primaryColor: Colors.white,
      hintColor: Colors.white,
    ),
    home: EmployeListPage(
      employeRepository: employeRepository,
    ),
    debugShowCheckedModeBanner: false,
  ));
}
