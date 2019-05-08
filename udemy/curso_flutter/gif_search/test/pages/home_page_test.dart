import 'package:flutter_test/flutter_test.dart';
import 'package:gif_search/pages/home_page.dart';

main() {
  testWidgets('Should home page contains title Gif Search',
      (WidgetTester tester) async {
    await tester.pumpWidget(HomePage());

    expect(find.text("Gif search"), findsOneWidget);
  });
}
