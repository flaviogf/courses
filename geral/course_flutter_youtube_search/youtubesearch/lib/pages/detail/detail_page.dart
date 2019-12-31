import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:kiwi/kiwi.dart' as kiwi;
import 'package:youtubesearch/pages/detail/detail_bloc.dart';
import 'package:youtubesearch/pages/detail/detail_event.dart';
import 'package:youtubesearch/pages/detail/detail_state.dart';

class DetailPage extends StatefulWidget {
  final String id;

  DetailPage({
    Key key,
    this.id,
  }) : super(key: key);

  @override
  State<StatefulWidget> createState() => DetailPageState();
}

class DetailPageState extends State<DetailPage> {
  final DetailBloc _bloc = kiwi.Container().resolve<DetailBloc>();

  @override
  void initState() {
    super.initState();
    _bloc.add(DetailEventFindOne(widget.id));
  }

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (_) => _bloc,
      child: Scaffold(
        body: BlocBuilder<DetailBloc, DetailState>(
          builder: (context, state) {
            if (state is DetailStateLoading) {
              return CustomScrollView(
                slivers: <Widget>[
                  SliverAppBar(
                    title: Text('Loading...'),
                    expandedHeight: 178,
                  ),
                  SliverFillRemaining(
                    child: Center(
                      child: CircularProgressIndicator(),
                    ),
                  )
                ],
              );
            }

            if (state is DetailStateSuccess) {
              return CustomScrollView(
                slivers: <Widget>[
                  SliverAppBar(
                    expandedHeight: 178,
                    pinned: true,
                    flexibleSpace: FlexibleSpaceBar(
                      title: Text(
                        state.data.title,
                        overflow: TextOverflow.ellipsis,
                        maxLines: 1,
                      ),
                      background: Stack(
                        fit: StackFit.expand,
                        children: <Widget>[
                          Image.network(
                            state.data.thumbnail,
                            fit: BoxFit.cover,
                          ),
                          Container(
                            decoration: BoxDecoration(
                              gradient: LinearGradient(
                                begin: Alignment.bottomCenter,
                                end: Alignment.topCenter,
                                stops: [0.15, 0.5],
                                colors: [
                                  Colors.black.withOpacity(0.7),
                                  Colors.transparent,
                                ],
                              ),
                            ),
                          )
                        ],
                      ),
                    ),
                  ),
                  SliverPadding(
                    padding: EdgeInsets.all(8.0),
                    sliver: SliverList(
                      delegate: SliverChildListDelegate([
                        SizedBox(
                          height: 5.0,
                        ),
                        Text(
                          state.data.title,
                          style: TextStyle(
                            fontWeight: FontWeight.bold,
                            fontSize: 25.0,
                          ),
                        ),
                        SizedBox(
                          height: 5.0,
                        ),
                        Text(
                          'Description',
                          style: Theme.of(context).textTheme.title,
                        ),
                        SizedBox(
                          height: 5.0,
                        ),
                        Text(state.data.description),
                      ]),
                    ),
                  )
                ],
              );
            }

            return CustomScrollView(
              slivers: <Widget>[
                SliverAppBar(
                  expandedHeight: 178,
                ),
              ],
            );
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
