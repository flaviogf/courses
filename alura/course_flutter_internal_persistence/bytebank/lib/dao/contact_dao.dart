import 'package:bytebank/database.dart';
import 'package:bytebank/models/contact.dart';
import 'package:sqflite/sqflite.dart';

class ContactDao {
  Future<Contact> insert(Contact contact) async {
    final Database database = await getDatabase();

    final Map<String, dynamic> values = Map();
    values['name'] = contact.name;
    values['account'] = contact.account;

    await database.insert('contacts', values);

    return contact;
  }

  Future<List<Contact>> findAll() async {
    final Database database = await getDatabase();

    final List<Map<String, dynamic>> records = await database.query('contacts');

    final List<Contact> contacts = records
        .map((it) => Contact(it['name'], it['account'], id: it['id']))
        .toList();

    return contacts;
  }
}
