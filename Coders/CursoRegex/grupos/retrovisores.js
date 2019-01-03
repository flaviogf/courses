const texto = '<b>Desc</b><h1>Desc</h1>'

console.log(texto.match(/<(\w+)>.*<\/\1>/g))
console.log(texto.replace(/(b)/g, 'teste$1teste'))
