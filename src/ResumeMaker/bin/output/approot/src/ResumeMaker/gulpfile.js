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
    less = require("gulp-less"),
    browserSync = require("browser-sync");


var paths = {
    webroot: "./wwwroot/"
};
paths.lib = paths.webroot + "lib/";

///*********Src files**********//
//**Src Js Files**//
paths.js = paths.webroot + "js/**/*.js";
paths.jqueryJs = paths.lib + "jquery/dist/jquery.js";
paths.toastrJs = paths.lib + "toastr/toastr.js";
paths.bootstrapJs = paths.lib + "bootstrap/dist/js/bootstrap.js";
paths.jqueryConfirmJs = paths.lib + "jquery-confirm2/js/jquery-confirm.js";
paths.minJs = paths.webroot + "js/**/*.min.js";

var allJsFilesToProcess = [paths.jqueryJs, paths.toastrJs, paths.bootstrapJs, paths.jqueryConfirmJs, paths.js, "!" + paths.minJs];


//****Src CSS Files********//
paths.css = paths.webroot + "css/**/*.css";
paths.bootstrapCss = paths.lib + "bootstrap/dist/css/bootstrap.css";
paths.faCss = paths.lib + "Font-Awesome/css/font-awesome.css";
paths.minCss = paths.webroot + "css/**/*.min.css";

var allCssFilesToProcess = [paths.bootstrapCss, paths.faCss, paths.css, "!" + paths.minCss];

//**Src Less Files**//
paths.siteLess = "./Styles/Site.less";
paths.jqueryConfirmLess = paths.lib + "jquery-confirm2/css/jquery-confirm.less";

var allLessFilesToProcess = [paths.siteLess, paths.jqueryConfirmLess];

//**Src fonts files**//
paths.fonts = paths.lib + "font-awesome/fonts/**/*.{ttf,woff,eof,svg,woff2}";


///***Dest Files*******/////
paths.concatJsDest = paths.webroot + "js/all.min.js";
paths.concatCssDest = paths.webroot + "css/all.min.css";
paths.fontsDest = paths.webroot + "fonts";



/////////////////////////*************Tasks*********************///////////////////////////
gulp.task("default", function (cb) {
    console.log('This is the default task.');
});

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task('less', function () {
    return gulp.src(allLessFilesToProcess)
        .pipe(less())
        .pipe(gulp.dest(paths.webroot + '/css'))
        .pipe(browserSync.reload({
            stream: true
        }));
});

gulp.task("min:js", function () {
    return gulp.src(allJsFilesToProcess, { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src(allCssFilesToProcess)
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);

gulp.task('copyfonts', function () {
    gulp.src(paths.fonts)
    .pipe(gulp.dest(paths.fontsDest));
});


gulp.task('browserSync', function () {
    browserSync.init({
        proxy: "localhost:52570"
    });
});

gulp.task('watch', ['browserSync', 'less'], function () {
    gulp.watch(allLessFilesToProcess, ['less', 'min']);
});
