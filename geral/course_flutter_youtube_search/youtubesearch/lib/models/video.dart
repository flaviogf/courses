class Video {
  final String id;
  final String title;
  final String thumbnail;

  Video(this.id, this.title, this.thumbnail);

  @override
  String toString() => 'Video{id:$id, title:$title}';
}
