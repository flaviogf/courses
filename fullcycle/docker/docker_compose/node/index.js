const express = require('express')
const mysql = require('mysql')

const PORT = 3000

const app = express()

app.get('/:name', (req, res) => {
  const connection = mysql.createConnection({ host: 'db', user: 'root', password: 'root', database: 'nodedb' })

  const name = req.params['name'].toString().toUpperCase()

  connection.query('INSERT INTO people SET ?', { name: name }, (error, response) => {
    if(error) throw error;

    res.send(`<h1>HELLO ${name}!</h1>`)
  })
})

app.listen(PORT, () => console.log(`running at port: ${PORT}`))
