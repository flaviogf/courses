(function() {
    const inputImagem = document.querySelector('#input_imagem')
    const imagem = document.querySelector('#imagem')
    inputImagem.onchange = e => {
        if(e.target.files.length) {
            const imagemSelecionada = e.target.files[0]
            const reader = new FileReader()
            reader.onload = e => imagem.src = e.target.result
            reader.readAsDataURL(imagemSelecionada)
        }
    }
})()
