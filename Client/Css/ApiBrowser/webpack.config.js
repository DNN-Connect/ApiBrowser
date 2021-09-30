var path = require("path"),
  MiniCssExtractPlugin = require("mini-css-extract-plugin"),
  FileManagerPlugin = require("filemanager-webpack-plugin");

var outPath = path.resolve(__dirname, "../../../Server/ApiBrowser");

var apibrowserAppConfig = {
  context: path.join(__dirname, "."),
  entry: "./scss/module.scss",
  output: {
    path: outPath,
    filename: "module.css.js",
  },
  module: {
    rules: [
      {
        test: /\.scss$/,
        use: [MiniCssExtractPlugin.loader, "css-loader", "sass-loader"],
      },
    ],
  },
  plugins: [
    new MiniCssExtractPlugin({
      filename: "module.css",
    }),
    new FileManagerPlugin({
      events: {
        onEnd: {
          delete: [outPath + "/module.css.js"],
        },
      },
    }),
  ],
};

module.exports = apibrowserAppConfig;
