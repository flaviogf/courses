const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');

module.exports = {
  entry: './src/index.jsx',
  output: {
    filename: 'app.js',
    path: path.resolve(__dirname, 'public')
  },
  module: {
    rules: [
      {
        test: /\.js[x]?$/,
        exclude: /node_modules/,
        loader: 'babel-loader',
        options: {
          presets: ['es2015', 'react'],
          plugins: ['react-html-attrs', 'transform-object-rest-spread']
        }
      },
      {
        test: /\.css$/,
        use: ExtractTextPlugin.extract({
          fallback: 'style-loader',
          use: 'css-loader'
        })
      },
      {
        test: /\.(woff|woff2|eot|ttf|otf)$/,
        loader: 'file-loader'
      }
    ]
  },
  resolve: {
    extensions: ['.js', '.jsx'],
    alias: {
      module: path.resolve(__dirname, 'node_modules'),
      jquery: path.resolve(__dirname, 'node_modules/jquery/dist/jquery.js'),
    }
  },
  devServer: {
    port: 3000,
    contentBase: path.resolve(__dirname, 'public')
  },
  plugins: [
    new webpack.DefinePlugin({
      $: 'jquery',
      JQuery: 'jquery'
    }),
    new ExtractTextPlugin('app.css')
  ]
}