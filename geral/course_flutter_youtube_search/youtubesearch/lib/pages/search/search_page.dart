import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:youtubesearch/pages/search/search_bloc.dart';
import 'package:youtubesearch/pages/search/search_event.dart';

class SearchPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (_) => kiwi.Container().resolve<SearchBloc>(),
      child: Scaffold(
        appBar: AppBar(
          title: SearchBar(),
        ),
        body: Center(
          child: Text("It's running."),
        ),
      ),
    );
  }
}

class SearchBar extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.only(left: 8.0, right: 8.0),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(5.0),
        color: Colors.white,
      ),
      child: SearchTextField(),
    );
  }
}

class SearchTextField extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return TextField(
      decoration: InputDecoration(
        hintText: 'Search videos',
        border: InputBorder.none,
        icon: Icon(Icons.search),
      ),
      onSubmitted: (name) {
        BlocProvider.of<SearchBloc>(context).add(SearchEventFind(name));
      },
    );
  }
}
