/// <binding AfterBuild='min, less' />
"use strict";
/// <binding Clean='clean' />

/// <binding AfterBuild='less' />

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    fs = require("fs"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    less = require("gulp-less");

var paths = {
    webroot: "./wwwroot/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.lib = paths.webroot + "lib/";
paths.fonts = paths.lib + "font-awesome/fonts/**/*.{ttf,woff,eof,svg,woff2}";

paths.bootstrapCss = paths.lib + "bootstrap/dist/css/bootstrap.css";
paths.bootstrapJs = paths.lib + "bootstrap/dist/js/bootstrap.js";
paths.faCss = paths.lib + "Font-Awesome/css/font-awesome.css";
paths.jqueryJs = paths.lib + "jquery/dist/jquery.js";
paths.toastrJs = paths.lib + "toastr/toastr.js";

paths.concatJsDest = paths.webroot + "js/all.min.js";
paths.concatCssDest = paths.webroot + "css/all.min.css";
paths.fontsDest = paths.webroot + "fonts";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task('less', function () {
    return gulp.src('Styles/Site.less')
               .pipe(less())
               .pipe(gulp.dest(paths.webroot + '/css'));
});

gulp.task("min:js", function () {
    return gulp.src([
        paths.jqueryJs,
        paths.bootstrapJs,
        paths.toastrJs,
        paths.js,
        "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css,
        paths.bootstrapCss,
        paths.faCss,
        "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);

gulp.task('copyfonts', function () {
    gulp.src(paths.fonts)
    .pipe(gulp.dest(paths.fontsDest));
});