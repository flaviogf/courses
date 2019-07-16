function Snackbar() {
    const element = document.querySelector('.snackbar__content')
    const button = document.querySelector('.snackbar__button')

    this.show = () => {
        if (element.children.length <= 1) return;
        element.classList.add('snackbar--visible')
    }

    this.dismiss = () => {
        element.classList.remove('snackbar--visible')
    }

    setTimeout(this.show, 100);

    button.onclick = this.dismiss
}