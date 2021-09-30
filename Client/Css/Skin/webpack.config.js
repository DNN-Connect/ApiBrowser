var path = require("path"),
  MiniCssExtractPlugin = require("mini-css-extract-plugin"),
  FileManagerPlugin = require("filemanager-webpack-plugin");

var outPath = path.resolve(__dirname, "../../../Themes/Skins/ApiBrowser");

var skinAppConfig = {
  context: path.join(__dirname, "."),
  entry: "./scss/skin.scss",
  output: {
    path: outPath,
    filename: "skin.css.js",
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
      filename: "skin.css",
    }),
    new FileManagerPlugin({
      events: {
        onEnd: {
          delete: [outPath + "/skin.css.js"],
        },
      },
    }),
  ],
};

module.exports = skinAppConfig;
