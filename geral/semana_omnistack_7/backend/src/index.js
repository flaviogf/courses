const express = require('express')
const path = require('path')
const mongoose = require('mongoose')
const app = express()

mongoose.connect('mongodb+srv://semana:semana@cluster0-vdxmr.azure.mongodb.net/test?retryWrites=true&w=majority', {
    useNewUrlParser: true
})

app.get('/', (req, res) => res.json({ ok: true }))

app.use(require('./routes'))

app.use('/files', express.static(path.resolve(__dirname, '..', 'uploads', 'resized')))

app.listen(3000)