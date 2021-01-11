const https = require("https");

function fetch(url) {
  const options = {
    hostname: url,
    port: 443,
    method: "GET",
    headers: { "User-Agent": "Mozilla/5.0" },
  };

  return new Promise((resolve, reject) => {
    let response = [];

    const request = https.request(options, (res) => {
      res.on("data", (data) => {
        response.push(data);
      });

      res.on("end", () => {
        resolve(JSON.parse(Buffer.concat(response).toString()));
      });
    });

    request.on("error", (err) => {
      reject(err);
    });

    request.end();
  });
}

const fetchData = () => {
  fetch("api.github.com").then((data) => {
    console.log(data);
  });
};

const fetchDataAsync = async () => {
  const data = await fetch("api.github.com");

  console.log(data);
};

fetchData();

fetchDataAsync();
