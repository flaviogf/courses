sendgrid = require '@sendgrid/mail'

sendgrid.setApiKey process.env.EMAIL_API_KEY

exports.send = ({ to, subject, html }) ->
  sendgrid.send {
    from: process.env.EMAIL
    to
    subject
    html
  }
