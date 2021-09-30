var path = require("path"),
  commonConfig = require("../../webpack.common.config");

var clientAppConfig = Object.assign({}, commonConfig, {
  context: path.join(__dirname, "."),
  entry: "./App.tsx",
  output: {
    path: path.resolve(__dirname, "../../../Server/ApiBrowser/js"),
    filename: "api-browser.js"
  },
  resolve: {
    extensions: [".js", ".ts", ".tsx"],
    mainFields: ["module", "browser", "main"],
    alias: {
      app: path.resolve(__dirname, "src/app/")
    }
  }
});

module.exports = clientAppConfig;
