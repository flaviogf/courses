const texto = 'http://www.site.info www.escolaninja.com.br google.com.br'

console.log(texto.match(/(http:\/\/)?(w{3}\.)?\w+\.\w+(\.\w+)?/g))
