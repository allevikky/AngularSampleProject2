const { env } = require('process');

const target =  'http://localhost:5284';

const PROXY_CONFIG = [
  {
    context: [
      "/Home/GetProducts",
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
