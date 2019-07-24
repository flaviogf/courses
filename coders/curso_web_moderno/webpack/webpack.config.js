const webpack = require('webpack')
const path = require('path')


module.exports = {
    mode: 'development',
    entry: path.join(__dirname, 'src', 'index.js'),
    output: {
        filename: 'app.js',
        path: path.join(__dirname, 'public')
    },
    devServer: {
        contentBase: './public',
        port: 9000
    },
    module: {
        rules: [{
            exclude: /node_modules/,
            test: /\.s?[ac]ss$/,
            use: [
                'style-loader',
                'css-loader',
                'sass-loader',
            ]
        }]
    },
}