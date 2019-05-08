import 'package:employe_search/domain/repositories/employe_repository.dart';
import 'package:flutter/material.dart';

class EmployeListPage extends StatelessWidget {
  final EmployeRepository employeRepository;

  EmployeListPage({Key key, this.employeRepository}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text("Colaboradores"),
        ),
        body: Container(
          child: GridView.builder(
            itemCount: 1,
            itemBuilder: (context, position) => Text(
                  "Steve",
                  textDirection: TextDirection.ltr,
                ),
          ),
        ));
  }
}
