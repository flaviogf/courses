const webpack = require('webpack');

module.exports = {
    entry: './src/index.jsx',
    output: {
        path: __dirname + '/public',
        filename: 'app.js'
    },
    resolve: {
        extensions: ['.js', '.jsx'],
        alias: {
            module: __dirname + "/node_modules"
        }
    },
    module: {
        loaders: [
            {
                test: /.js[x]?$/,
                loader: 'babel-loader',
                exclude: /node_modules/,
                query: {
                    presets: ['es2015', 'react'],
                    plugins: "transform-object-rest-spread"
                }
            },
            {
                test: /\.woff|.woff2|.ttf|.eot|.svg*.*$/,
                loader: 'file-loader'
            },
            {
                test: /\.css$/,
                loaders:  ['style-loader', 'css-loader']
            }
        ]
    },
    devServer: {
        port: 8080,
        contentBase: './public'
    }
}
