const gulp = require('gulp')
const uglify = require('gulp-uglify')
const concat = require('gulp-concat')
const typescript = require('gulp-typescript')
const tsProject = typescript.createProject('tsconfig.json')

gulp.task('default', () => {
    return gulp.src('src/**/*.ts')
        .pipe(tsProject())
        .pipe(uglify())
        .pipe(gulp.dest('build'))
})