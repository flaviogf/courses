import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:youtubesearch/models/video.dart';
import 'package:youtubesearch/pages/detail/detail_page.dart';
import 'package:youtubesearch/pages/search/search_bloc.dart';
import 'package:youtubesearch/pages/search/search_event.dart';
import 'package:youtubesearch/pages/search/search_state.dart';

class SearchPage extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => SearchPageState();
}

class SearchPageState extends State<SearchPage> {
  final SearchBloc _bloc = kiwi.Container().resolve<SearchBloc>();
  final ScrollController _scrollController = ScrollController();

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (_) => _bloc,
      child: Scaffold(
        appBar: AppBar(
          title: SearchBar(),
        ),
        body: BlocBuilder<SearchBloc, SearchState>(
          builder: (context, state) {
            if (state is SearchStateInitial) {
              return Center(
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: <Widget>[
                    Icon(
                      Icons.ondemand_video,
                      size: 36,
                    ),
                    Text(
                      'Start searching!',
                    ),
                  ],
                ),
              );
            }

            if (state is SearchStateLoading) {
              return Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
                  Center(
                    child: CircularProgressIndicator(),
                  ),
                ],
              );
            }

            if (state is SearchStateSuccess) {
              return NotificationListener<ScrollNotification>(
                onNotification: (notification) {
                  bool hasReachedOnTheEnd =
                      notification is ScrollEndNotification &&
                          _scrollController.position.extentAfter == 0;

                  if (hasReachedOnTheEnd) {
                    BlocProvider.of<SearchBloc>(context).add(SearchEventNext());
                  }

                  return false;
                },
                child: ListView.builder(
                  controller: _scrollController,
                  itemCount: state.data.length + 1,
                  itemBuilder: (context, index) {
                    if (index >= state.data.length) {
                      return Padding(
                        padding: EdgeInsets.all(8.0),
                        child: Center(
                          child: CircularProgressIndicator(),
                        ),
                      );
                    }

                    Video video = state.data[index];
                    return GestureDetector(
                      onTap: () {
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (_) => DetailPage(id: video.id),
                          ),
                        );
                      },
                      child: Card(
                        child: Padding(
                          padding: EdgeInsets.all(8.0),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: <Widget>[
                              AspectRatio(
                                aspectRatio: 16 / 9,
                                child: Image.network(
                                  video.thumbnail,
                                  fit: BoxFit.cover,
                                ),
                              ),
                              SizedBox(
                                height: 8.0,
                              ),
                              Text(
                                video.title,
                                maxLines: 1,
                                overflow: TextOverflow.ellipsis,
                                style: TextStyle(
                                  fontWeight: FontWeight.bold,
                                  fontSize: 20.0,
                                ),
                              ),
                              SizedBox(
                                height: 8.0,
                              ),
                              Text(
                                video.description,
                              ),
                            ],
                          ),
                        ),
                      ),
                    );
                  },
                ),
              );
            }

            return Text('Unknown error.');
          },
        ),
      ),
    );
  }

  @override
  void dispose() {
    super.dispose();
    _bloc.close();
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

class SearchTextField extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => SearchTextFieldState();
}

class SearchTextFieldState extends State<SearchTextField> {
  final TextEditingController _controller = TextEditingController();
  final FocusNode _focusNode = FocusNode();

  @override
  void initState() {
    super.initState();

    _focusNode.addListener(() {
      if (!_focusNode.hasFocus) return;

      _controller.selection =
          TextSelection(baseOffset: 0, extentOffset: _controller.text.length);
    });
  }

  @override
  Widget build(BuildContext context) {
    return TextField(
      controller: _controller,
      focusNode: _focusNode,
      decoration: InputDecoration(
        hintText: 'Search videos',
        border: InputBorder.none,
        icon: Icon(Icons.search),
      ),
      onSubmitted: (title) {
        BlocProvider.of<SearchBloc>(context).add(SearchEventFind(title));
      },
    );
  }
}
