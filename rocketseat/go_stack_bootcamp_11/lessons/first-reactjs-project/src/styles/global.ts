import { createGlobalStyle } from 'styled-components'
import background from '../assets/github-background.svg'

export default createGlobalStyle`
  * {
    box-sizing: border-box;
    margin: 0;
    outline: none;
    padding: 0;
  }

  body {
    background: #F0F0F5 url(${background}) no-repeat 70% top;
  }

  body, input, button {
    font: 16px Roboto, sans-serif;
    -webkit-font-smoothing: antialiased;
  }

  #root {
    margin: 0 auto;
    max-width: 960px;
    padding: 40px 20px;
  }

  button {
    cursor: pointer;
  }
`
