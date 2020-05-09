const del = require("del");
const gulp = require("gulp");

gulp.task("clean", function () {
  return del(["app/lib/"]);
});

gulp.task("build", function () {
  return gulp
    .src([
      "node_modules/systemjs/dist/system.js",
      "node_modules/systemjs/dist/system.js.map",
      "node_modules/jquery/dist/jquery.min.js",
      "node_modules/jquery/dist/jquery.min.map",
    ])
    .pipe(gulp.dest("app/lib/"));
});
