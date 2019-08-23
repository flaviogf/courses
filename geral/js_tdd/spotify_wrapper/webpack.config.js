const path = require('path')

module.exports = {
  mode: process.env.NODE_ENV || 'development',
  entry: path.resolve('.', 'index.js'),
  output: {
    library: 'spotify',
    libraryTarget: 'umd'
  },
  module: {
    rules: [
      {
        test: /\.js$/,
        exclude: /node_modules/,
        include: path.resolve('src'),
        use: {
          loader: 'babel-loader'
        }
      }
    ]
  }
}
