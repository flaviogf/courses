import 'package:bytebank/screens/contact_list.dart';
import 'package:bytebank/screens/transaction_list.dart';
import 'package:flutter/material.dart';

class Dashboard extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Dashboard'),
      ),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
          Padding(
            padding: EdgeInsets.all(8.0),
            child: Image.asset('images/bytebank_logo.png'),
          ),
          SingleChildScrollView(
            scrollDirection: Axis.horizontal,
            child: Row(
              children: <Widget>[
                Feature(
                  icon: Icon(
                    Icons.monetization_on,
                    color: Colors.white,
                  ),
                  title: Text(
                    'Transfers',
                    style: TextStyle(
                      color: Colors.white,
                    ),
                  ),
                  onClick: () {
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (context) => ContactList(),
                      ),
                    );
                  },
                ),
                Feature(
                  icon: Icon(
                    Icons.description,
                    color: Colors.white,
                  ),
                  title: Text(
                    'Transaction feed',
                    style: TextStyle(
                      color: Colors.white,
                    ),
                  ),
                  onClick: () {
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (context) => TransactionList(),
                      ),
                    );
                  },
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}

class Feature extends StatelessWidget {
  final Icon icon;
  final Text title;
  final Function onClick;

  Feature({
    Key key,
    this.icon,
    this.title,
    @required this.onClick,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.all(8.0),
      child: Material(
        color: Theme.of(context).primaryColor,
        child: InkWell(
          onTap: () => onClick(),
          child: Container(
            padding: EdgeInsets.all(8.0),
            height: 100,
            width: 150,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: <Widget>[
                icon,
                title,
              ],
            ),
          ),
        ),
      ),
    );
  }
}
