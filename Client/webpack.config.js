var apibrowserAppConfig = require("./Js/ApiBrowser/webpack.config"),
  moduleCssConfig = require("./Css/ApiBrowser/webpack.config"),
  skinCssConfig = require("./Css/Skin/webpack.config");

module.exports = [apibrowserAppConfig, moduleCssConfig, skinCssConfig];
