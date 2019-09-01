import { expect } from 'chai'

import { renderAlbumList } from '../src/album-list'

describe('AlbumList', () => {
  const data1 = [
    {
      album_type: 'album',
      artists: [
        {
          external_urls: {
            spotify: 'https://open.spotify.com/artist/6XyY86QOPPrYVGvF9ch6wz'
          },
          href: 'https://api.spotify.com/v1/artists/6XyY86QOPPrYVGvF9ch6wz',
          id: '6XyY86QOPPrYVGvF9ch6wz',
          name: 'Linkin Park',
          type: 'artist',
          uri: 'spotify:artist:6XyY86QOPPrYVGvF9ch6wz'
        }
      ],
      available_markets: [],
      external_urls: {
        spotify: 'https://open.spotify.com/album/6hPkbAV3ZXpGZBGUvL6jVM'
      },
      href: 'https://api.spotify.com/v1/albums/6hPkbAV3ZXpGZBGUvL6jVM',
      id: '6hPkbAV3ZXpGZBGUvL6jVM',
      images: [
        {
          height: 640,
          url:
            'https://i.scdn.co/image/78a2c6dcc4928bbc9ee4b3480eb096d362e60fbf',
          width: 640
        },
        {
          height: 300,
          url:
            'https://i.scdn.co/image/bf391956e4c0d79bcedaa6f2897756db36233dd9',
          width: 300
        },
        {
          height: 64,
          url:
            'https://i.scdn.co/image/831d8b3fb3de81ca24e1a9c10d02baf3c7a3f33f',
          width: 64
        }
      ],
      name: 'Hybrid Theory (Bonus Edition)',
      release_date: '2000-10-24',
      release_date_precision: 'day',
      total_tracks: 15,
      type: 'album',
      uri: 'spotify:album:6hPkbAV3ZXpGZBGUvL6jVM'
    }
  ]

  const markup1 = `
  <div class="menu-item">
    <img class="menu-item__image" src="https://i.scdn.co/image/831d8b3fb3de81ca24e1a9c10d02baf3c7a3f33f" alt="album">
    <div class="menu-item__description">
      <p class="menu-item__title">Hybrid Theory (Bonus Edition)</p>
      <p class="menu-item__subtitle">Linkin Park</p>
    </div>
  </div>`

  it('should create markup and render that on html', () => {
    const element = document.createElement('div')
    renderAlbumList(data1, element)
    expect(element.innerHTML).to.be.eql(markup1)
  })

  const data2 = [
    {
      album_type: 'album',
      artists: [
        {
          external_urls: {
            spotify: 'https://open.spotify.com/artist/6XyY86QOPPrYVGvF9ch6wz'
          },
          href: 'https://api.spotify.com/v1/artists/6XyY86QOPPrYVGvF9ch6wz',
          id: '6XyY86QOPPrYVGvF9ch6wz',
          name: 'Linkin Park',
          type: 'artist',
          uri: 'spotify:artist:6XyY86QOPPrYVGvF9ch6wz'
        }
      ],
      available_markets: [],
      external_urls: {
        spotify: 'https://open.spotify.com/album/6hPkbAV3ZXpGZBGUvL6jVM'
      },
      href: 'https://api.spotify.com/v1/albums/6hPkbAV3ZXpGZBGUvL6jVM',
      id: '6hPkbAV3ZXpGZBGUvL6jVM',
      images: [
        {
          height: 640,
          url:
            'https://i.scdn.co/image/78a2c6dcc4928bbc9ee4b3480eb096d362e60fbf',
          width: 640
        },
        {
          height: 300,
          url:
            'https://i.scdn.co/image/bf391956e4c0d79bcedaa6f2897756db36233dd9',
          width: 300
        },
        {
          height: 64,
          url:
            'https://i.scdn.co/image/831d8b3fb3de81ca24e1a9c10d02baf3c7a3f33f',
          width: 64
        }
      ],
      name: 'Hybrid Theory (Bonus Edition)',
      release_date: '2000-10-24',
      release_date_precision: 'day',
      total_tracks: 15,
      type: 'album',
      uri: 'spotify:album:6hPkbAV3ZXpGZBGUvL6jVM'
    },
    {
      album_type: 'album',
      artists: [
        {
          external_urls: {
            spotify: 'https://open.spotify.com/artist/6XyY86QOPPrYVGvF9ch6wz'
          },
          href: 'https://api.spotify.com/v1/artists/6XyY86QOPPrYVGvF9ch6wz',
          id: '6XyY86QOPPrYVGvF9ch6wz',
          name: 'Linkin Park',
          type: 'artist',
          uri: 'spotify:artist:6XyY86QOPPrYVGvF9ch6wz'
        }
      ],
      available_markets: [],
      external_urls: {
        spotify: 'https://open.spotify.com/album/6hPkbAV3ZXpGZBGUvL6jVM'
      },
      href: 'https://api.spotify.com/v1/albums/6hPkbAV3ZXpGZBGUvL6jVM',
      id: '6hPkbAV3ZXpGZBGUvL6jVM',
      images: [
        {
          height: 640,
          url:
            'https://i.scdn.co/image/78a2c6dcc4928bbc9ee4b3480eb096d362e60fbf',
          width: 640
        },
        {
          height: 300,
          url:
            'https://i.scdn.co/image/bf391956e4c0d79bcedaa6f2897756db36233dd9',
          width: 300
        },
        {
          height: 64,
          url:
            'https://i.scdn.co/image/831d8b3fb3de81ca24e1a9c10d02baf3c7a3f33f',
          width: 64
        }
      ],
      name: 'Hybrid Theory (Bonus Edition)',
      release_date: '2000-10-24',
      release_date_precision: 'day',
      total_tracks: 15,
      type: 'album',
      uri: 'spotify:album:6hPkbAV3ZXpGZBGUvL6jVM'
    }
  ]

  const markup2 = `
  <div class="menu-item">
    <img class="menu-item__image" src="https://i.scdn.co/image/831d8b3fb3de81ca24e1a9c10d02baf3c7a3f33f" alt="album">
    <div class="menu-item__description">
      <p class="menu-item__title">Hybrid Theory (Bonus Edition)</p>
      <p class="menu-item__subtitle">Linkin Park</p>
    </div>
  </div>
  <div class="menu-item">
    <img class="menu-item__image" src="https://i.scdn.co/image/831d8b3fb3de81ca24e1a9c10d02baf3c7a3f33f" alt="album">
    <div class="menu-item__description">
      <p class="menu-item__title">Hybrid Theory (Bonus Edition)</p>
      <p class="menu-item__subtitle">Linkin Park</p>
    </div>
  </div>`

  it('should create markup and render with more than one element', () => {
    const element = document.createElement('div')
    renderAlbumList(data2, element)
    expect(element.innerHTML).to.be.eql(markup2)
  })
})
