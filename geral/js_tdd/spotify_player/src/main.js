import spotify from 'spotify-wrapper-flaviogf'

import { renderAlbumList } from './album-list'

const API_TOKEN =
  'BQD9-iY2yZfluXTRA7Vf7qWg9m6zLT5LSMNDzWOYxm75fJTNnbk2VH8cNkjLlvMWqB5Xx8nKfeFNVuygltUtXZSQW9he1a_Nxn3-38qQAHdgh_sr37dZ3Cpc1tgQDVl8atMJPWx6NiyY'

const sp = spotify(API_TOKEN)

sp.searchAlbums('Linkin Park')
  .then(({ albums }) => albums)
  .then(({ items }) => items)
  .then((items) =>
    renderAlbumList(items, document.querySelector('[data-menu-albums]'))
  )
  .catch(console.error)
