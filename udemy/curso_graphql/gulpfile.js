const gulp = require('gulp')
const clean = require('gulp-clean')
const ts = require('gulp-typescript')

const tsProject = ts.createProject('tsconfig.json')

gulp.task('scripts', ['static'], () => {
  return tsProject
    .src()
    .pipe(tsProject())
    .js
    .pipe(gulp.dest('dist'))
})

gulp.task('static', ['clean'], () => {
  return gulp
    .src('src/**/*.json')
    .pipe(gulp.dest('dist'))
})

gulp.task('clean', () => {
  return gulp
    .src('dist')
    .pipe(clean())
})

gulp.task('default', ['scripts'], () => {
  return gulp
    .watch(['src/**/*.ts', 'src/**/*.json'], ['scripts'])
})
