"use strict";

module.exports.sendReminderDaily = (event, context, callback) => {
  var AWS = require("aws-sdk");

  AWS.config.update({ region: "us-east-1" });

  var ses = new AWS.SES();

  var fs = require("fs");

  var emailHtml = fs.readFileSync("./dailyReminder.html", 'utf-8');

  var toAndFromAddress = "flaviogf6@outlook.com";

  var params = {
    Destination: {
      ToAddresses: [toAndFromAddress],
    },
    Message: {
      Body: {
        Html: {
          Charset: "UTF-8",
          Data: emailHtml,
        },
        Text: {
          Charset: "UTF-8",
          Data:
            "Remember to continue helping the Woof Garden in your Pluralsight Course",
        },
      },
      Subject: {
        Charset: "UTF-8",
        Data: "Woof Garden Reminder",
      },
    },
    ReplyToAddresses: [toAndFromAddress],
    Source: toAndFromAddress,
  };

  ses.sendEmail(params, function (err, data) {
    if (err) console.log(err, err.stack);
    else callback(null, data);
  });
};
