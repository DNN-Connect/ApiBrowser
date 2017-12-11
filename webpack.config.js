var path = require('path'),
    webpack = require('webpack');

module.exports = {
    context: path.resolve(__dirname, '.'),
    entry: "./js/src/App.tsx",
    output: {
        path: path.resolve(__dirname, './js'),
        publicPath: '/js/',
        filename: 'api-browser.js'
    },
    devtool: '#source-map',
    resolve: {
        extensions: ['*', '.webpack.js', '.web.js', '.ts', '.tsx', '.js', '.jsx']
    },
    module: {
        loaders: [{
            test: /\.tsx?$/,
            loader: 'ts-loader'
        }]
    },
    externals: {
        // 'react': 'React',
        // 'react-dom': 'ReactDOM',
        'jquery': 'jQuery'
    },
    plugins: [
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery',
            'window.jQuery': 'jquery'
        }),
        // new webpack.optimize.UglifyJsPlugin({
        //     compress: { warnings: false }
        // })
    ]
}