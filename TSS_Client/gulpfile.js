/// <binding AfterBuild='sass' />
'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass');

sass.compiler = require('node-sass');

gulp.task('sass', function () {
	return gulp.src('./scss/**/*.scss')
		.pipe(sass.sync().on('error', sass.logError))
		.pipe(gulp.dest('./wwwroot/css'));
});

gulp.task('sass:watch', function () {
	gulp.watch('./scss/**/*.scss', ['sass']);
});