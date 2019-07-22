const gulp = require('gulp')

gulp.task('default', () => {
    console.log('|> default...')

    gulp.start('copy', 'end')
})

gulp.task('copy', ['before1', 'before2'], () => {
    console.log('|> copy...')

    return gulp.src('pastaA/**/*.txt')
        .pipe(gulp.dest('pastaB'))
})

gulp.task('before1', () => {
    console.log('|> before1...')
})

gulp.task('before2', () => {
    console.log('|> before2...')
})

gulp.task('end', () => {
    console.log('|> end...')
})