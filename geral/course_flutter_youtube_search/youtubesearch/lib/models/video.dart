class Video {
  final String id;
  final String title;
  final String thumbnail;
  final String description;

  Video(this.id, this.title, this.thumbnail, this.description);

  @override
  String toString() => 'Video{id:$id, title:$title}';
}
