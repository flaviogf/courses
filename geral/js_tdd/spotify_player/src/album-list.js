function createMarkup(data) {
  const markup = (item) => `
  <div class="menu-item">
    <img class="menu-item__image" src="https://picsum.photos/id/415/200/200" alt="album">
    <div class="menu-item__description">
      <p class="menu-item__title">Title</p>
      <p class="menu-item__subtitle">Description</p>
    </div>
  </div>`

  return data.map(markup).join('')
}

export function renderAlbumList(data, element) {
  const markup = createMarkup(data)
  element.innerHTML = markup
}

export default renderAlbumList
