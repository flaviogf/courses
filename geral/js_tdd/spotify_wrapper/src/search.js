const API_URL = 'https://api.spotify.com/v1'

const json = () => (res) => res.json()

export const search = (query, type, headers = {}) => {
  const url = `${API_URL}/search?q=${query}&type=${type}`
  return fetch(url, headers).then(json())
}

export const searchArtists = (query, headers = {}) => {
  const url = `${API_URL}/search?q=${query}&type=artist`
  return fetch(url, headers).then(json())
}

export const searchAlbums = (query, headers = {}) => {
  const url = `${API_URL}/search?q=${query}&type=album`
  return fetch(url, headers).then(json())
}

export const searchTracks = (query, headers = {}) => {
  const url = `${API_URL}/search?q=${query}&type=track`
  return fetch(url, headers).then(json())
}

export const searchPlaylists = (query, headers = {}) => {
  const url = `https://api.spotify.com/v1/search?q=${query}&type=playlist`
  return fetch(url, headers).then(json())
}
