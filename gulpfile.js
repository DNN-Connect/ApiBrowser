var gulp = require('gulp'),
    msbuild = require('gulp-msbuild'),
    minifyCss = require('gulp-minify-css'),
    uglify = require('gulp-uglify'),
    assemblyInfo = require('gulp-dotnet-assembly-info'),
    config = require('./package.json'),
    zip = require('gulp-zip'),
    filter = require('gulp-filter'),
    merge = require('merge2'),
    gutil = require('gulp-util'),
    markdown = require('gulp-markdown'),
    rename = require('gulp-rename'),
    manifest = require('gulp-dnn-manifest'),
    path = require('path'),
    less = require('gulp-less'),
    lessPluginCleanCSS = require('less-plugin-clean-css'),
    cleancss = new lessPluginCleanCSS({
        advanced: true
    });

gulp.task('less', function() {
    return gulp.src('css/less/module.less')
        .pipe(less({
            paths: [path.join(__dirname, 'less', 'includes')],
            plugins: [cleancss]
        }))
        .pipe(gulp.dest('.'));
});

gulp.task('watch', function() {
    gulp.watch('css/src/**/*.less', ['less']);
});

gulp.task('assemblyInfo', function() {
    return gulp
        .src(['**/AssemblyInfo.cs', '!node_modules/**'])
        .pipe(assemblyInfo({
            title: config.dnn.friendlyName,
            description: config.description,
            version: config.version,
            fileVersion: config.version,
            company: config.dnn.owner.organization,
            copyright: function(value) {
                return 'Copyright ' + new Date().getFullYear() + ' by ' + config.dnn.owner.organization;
            }
        }))
        .pipe(gulp.dest('.'));
});

gulp.task('build', ['assemblyInfo'], function() {
    return gulp.src('./ApiBrowser.csproj')
        .pipe(msbuild({
            toolsVersion: 12.0,
            targets: ['Clean', 'Build'],
            errorOnFail: true,
            stdout: true,
            properties: {
                Configuration: 'Release',
                OutputPath: config.dnn.pathToAssemblies
            }
        }));
});

gulp.task('packageInstall', ['build'], function() {
    var packageName = config.dnn.fullName + '_' + config.version;
    var dirFilter = filter(fileTest);
    return merge(
            merge(
                gulp.src([
                    '**/*.html',
                    '**/*.resx'
                ], {
                    base: '.'
                })
                .pipe(dirFilter),
                gulp.src(['**/*.css'], {
                    base: '.'
                })
                .pipe(minifyCss())
                .pipe(dirFilter),
                gulp.src(['js/*.js', '!js/*.min.js'], {
                    base: '.'
                })
                .pipe(uglify().on('error', gutil.log)),
                gulp.src(['js/*.min.js'], {
                    base: '.'
                })
            )
            .pipe(zip('Resources.zip')),
            gulp.src(config.dnn.pathToSupplementaryFiles + '/*.dnn')
            .pipe(manifest(config)),
            gulp.src([config.dnn.pathToAssemblies + '/*.dll',
                config.dnn.pathToScripts + '/*.SqlDataProvider',
                config.dnn.pathToSupplementaryFiles + '/License.txt',
                config.dnn.pathToSupplementaryFiles + '/ReleaseNotes.txt'
            ]),
            gulp.src(config.dnn.pathToSupplementaryFiles + '/ReleaseNotes.md')
            .pipe(markdown())
            .pipe(rename('ReleaseNotes.txt'))
        )
        .pipe(zip(packageName + '_Install.zip'))
        .pipe(gulp.dest(config.dnn.packagesPath));
});

gulp.task('packageSource', ['build'], function() {
    var packageName = config.dnn.fullName + '_' + config.version;
    var dirFilter = filter(fileTest);
    return merge(
            gulp.src(['**/*.html',
                '**/*.css',
                'js/**/*.js',
                '**/*.??proj',
                '**/*.sln',
                '**/*.json',
                '**/*.cs',
                '**/*.vb',
                '**/*.resx',
                config.dnn.pathToSupplementaryFiles + '**/*.*'
            ], {
                base: '.'
            })
            .pipe(dirFilter)
            .pipe(zip('Resources.zip')),
            gulp.src(config.dnn.pathToSupplementaryFiles + '/*.dnn')
            .pipe(manifest(config)),
            gulp.src([config.dnn.pathToAssemblies + '/*.dll',
                config.dnn.pathToScripts + '/*.SqlDataProvider',
                config.dnn.pathToSupplementaryFiles + '/License.txt',
                config.dnn.pathToSupplementaryFiles + '/ReleaseNotes.txt'
            ])
        )
        .pipe(zip(packageName + '_Source.zip'))
        .pipe(gulp.dest(config.dnn.packagesPath));
})

gulp.task('package', ['packageInstall', 'packageSource'], function() {
    return null;
})

gulp.task('default', ['watch']);

function fileTest(file) {
    var res = false;
    for (var i = config.dnn.excludeFilter.length - 1; i >= 0; i--) {
        res = res | file.relative.startsWith(config.dnn.excludeFilter[i]);
    };
    return !res;
}

function startsWith(str, strToSearch) {
    return str.indexOf(strToSearch) === 0;
}