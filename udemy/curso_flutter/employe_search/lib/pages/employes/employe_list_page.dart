import 'package:employe_search/domain/repositories/employe_repository.dart';
import 'package:flutter/material.dart';

class EmployeListPage extends StatelessWidget {
  final EmployeRepository employeRepository;

  EmployeListPage({Key key, this.employeRepository}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final employes = employeRepository.all();

    return Scaffold(
        backgroundColor: Colors.black,
        appBar: AppBar(
          title: Text(
            "Colaboradores",
            textDirection: TextDirection.ltr,
            style: TextStyle(color: Colors.white),
          ),
          backgroundColor: Colors.black,
        ),
        body: Column(
          children: <Widget>[
            Padding(
              padding: EdgeInsets.all(16),
              child: TextField(
                  style: TextStyle(color: Colors.white),
                  decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    fillColor: Colors.white,
                    labelText: "Nome colaborador",
                  )),
            ),
            Expanded(
              child: GridView.builder(
                  gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                      crossAxisCount: 2),
                  itemCount: employes.length,
                  itemBuilder: (context, position) {
                    final employe = employes[position];

                    return SizedBox(
                      child: Padding(
                        padding: EdgeInsets.all(16),
                        child: Column(
                          children: <Widget>[
                            Image.network(employe.image),
                            Divider(),
                            Row(
                              mainAxisAlignment: MainAxisAlignment.center,
                              children: <Widget>[
                                Text(
                                  employe.name,
                                  textDirection: TextDirection.ltr,
                                  style: TextStyle(color: Colors.white),
                                ),
                                Text(
                                  "/",
                                  textDirection: TextDirection.ltr,
                                  style: TextStyle(color: Colors.white),
                                ),
                                Text(
                                  employe.role,
                                  textDirection: TextDirection.ltr,
                                  style: TextStyle(color: Colors.white),
                                ),
                              ],
                            )
                          ],
                        ),
                      ),
                    );
                  }),
            )
          ],
        ));
  }
}
