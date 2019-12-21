import 'package:bytebank/components/custom_editor.dart';
import 'package:bytebank/models/transfer.dart';
import 'package:flutter/material.dart';

class TransferForm extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return TransferFormState();
  }
}

class TransferFormState extends State<TransferForm> {
  final TextEditingController _accountNumberTextEditingController =
      TextEditingController();

  final TextEditingController _valueTextEditingController =
      TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          'Creating transfer',
        ),
      ),
      body: SingleChildScrollView(
        child: Column(
          children: <Widget>[
            CustomEditor(
              controller: _accountNumberTextEditingController,
              labelText: 'Account Number',
              hintText: '0000',
              keyboardType: TextInputType.number,
            ),
            CustomEditor(
              controller: _valueTextEditingController,
              labelText: 'Value',
              hintText: '0000',
              icon: Icon(
                Icons.monetization_on,
              ),
              keyboardType: TextInputType.number,
            ),
            Center(
              child: Builder(
                builder: (context) {
                  return RaisedButton(
                    child: Text(
                      'Confirmar',
                    ),
                    onPressed: () {
                      final String accountNumber =
                          _accountNumberTextEditingController.text;

                      final int value =
                          int.tryParse(_valueTextEditingController.text) ?? 0;

                      final Transfer transfer = Transfer(accountNumber, value);

                      Navigator.pop(context, transfer);
                    },
                  );
                },
              ),
            )
          ],
        ),
      ),
    );
  }
}
