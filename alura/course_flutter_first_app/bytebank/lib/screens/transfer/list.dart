import 'package:bytebank/models/transfer.dart';
import 'package:flutter/material.dart';

import 'form.dart';

class TransferList extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return TransferListState();
  }
}

class TransferListState extends State<TransferList> {
  final List<Transfer> transfers = [];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          'Transfers',
        ),
      ),
      body: Card(
        child: ListView.builder(
          itemCount: transfers.length,
          itemBuilder: (context, index) {
            return TransferItem(
              transfer: transfers[index],
            );
          },
        ),
      ),
      floatingActionButton: FloatingActionButton(
        child: Icon(
          Icons.add,
        ),
        onPressed: () async {
          final Transfer transfer = await Navigator.push(
            context,
            MaterialPageRoute(builder: (context) {
              return TransferForm();
            }),
          );

          if (transfer == null) {
            return;
          }

          setState(() {
            transfers.add(transfer);
          });
        },
      ),
    );
  }
}

class TransferItem extends StatelessWidget {
  final Transfer transfer;

  const TransferItem({Key key, this.transfer}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Card(
      child: ListTile(
        leading: Icon(
          Icons.monetization_on,
          color: Colors.green[900],
        ),
        title: Text(
          transfer.accountNumber,
        ),
        subtitle: Text(
          transfer.value.toString(),
        ),
      ),
    );
  }
}
