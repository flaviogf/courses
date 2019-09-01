import { expect } from 'chai'

import spotify from '../src'

describe('spotify', () => {
  const sp = spotify()

  context('smoke test', () => {
    it('should spotify have search method', () => {
      expect(sp.search).to.be.a('function')
    })

    it('should spotify have searchArtists method', () => {
      expect(sp.searchArtists).to.be.a('function')
    })

    it('should spotify have searchAlbums method', () => {
      expect(sp.searchAlbums).to.be.a('function')
    })

    it('should spotify have searchTracks method', () => {
      expect(sp.searchTracks).to.be.a('function')
    })

    it('should spotify have searchPlaylist method', () => {
      expect(sp.searchPlaylists).to.be.a('function')
    })
  })
})
