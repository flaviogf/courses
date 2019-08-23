import {
  search,
  searchArtists,
  searchAlbums,
  searchTracks,
  searchPlaylists
} from './search'

export default function spotify(token) {
  const header = {
    Authorization: `Bearer ${token}`
  }

  return {
    search: (query, type) => search(query, type, header),
    searchArtists: (query) => searchArtists(query, header),
    searchAlbums: (query) => searchAlbums(query, header),
    searchTracks: (query) => searchTracks(query, header),
    searchPlaylists: (query) => searchPlaylists(query, header)
  }
}
