class Contact {
  final int id;
  final String name;
  final String account;

  Contact(this.name, this.account, {this.id});

  @override
  String toString() {
    return 'Contact{id:$id, name:$name, account:$account}';
  }
}
