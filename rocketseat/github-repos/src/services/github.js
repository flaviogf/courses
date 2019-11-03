import axios from 'axios'

const GitHub = axios.create({
  baseURL: 'https://api.github.com',
})

export default GitHub
