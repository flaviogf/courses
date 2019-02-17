document.querySelector('.menu-abrir').onclick = (event) => {
    document.documentElement.classList.add('menu-ativo')
}

document.querySelector('.menu-fechar').onclick = (event) => {
    document.documentElement.classList.remove('menu-ativo')
}

document.documentElement.onclick = (event) => {
    event.target === document.documentElement
        && document.documentElement.classList.remove('menu-ativo')
}