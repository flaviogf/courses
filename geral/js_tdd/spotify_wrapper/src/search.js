const API_URL = 'https://api.spotify.com/v1'

const json = () => (res) => res.json()

export function search(query, type, headers = {}) {
  const url = `${API_URL}/search?q=${query}&type=${type}`
  return fetch(url, { headers }).then(json())
}

export function searchArtists(query, headers = {}) {
  return search(query, 'artist', headers)
}

export function searchAlbums(query, headers = {}) {
  return search(query, 'album', headers)
}

export function searchTracks(query, headers = {}) {
  return search(query, 'track', headers)
}

export function searchPlaylists(query, headers = {}) {
  return search(query, 'playlist', headers)
}
