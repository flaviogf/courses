function createMarkup(data) {
  const markup = (item) => `
  <div class="menu-item">
    <img class="menu-item__image" src="${item.images[2].url}" alt="album">
    <div class="menu-item__description">
      <p class="menu-item__title">${item.name}</p>
      <p class="menu-item__subtitle">${item.artists[0].name}</p>
    </div>
  </div>`

  return data.map(markup).join('')
}

export function renderAlbumList(data, element) {
  const markup = createMarkup(data)
  element.innerHTML = markup
}

export default renderAlbumList
