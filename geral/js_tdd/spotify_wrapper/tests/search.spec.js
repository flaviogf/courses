import { expect } from 'chai'

import sinon from 'sinon'

import fetch from 'node-fetch'

import {
  search,
  searchArtists,
  searchAlbums,
  searchTracks,
  searchPlaylists
} from '../src/search'

global.fetch = fetch

describe('search', () => {
  const response = { json: () => {} }

  afterEach(() => {
    sinon.restore()
  })

  context('smoke test', () => {
    it('should have search function', () => {
      expect(search).to.be.a('function')
    })

    it('should have searchArtists function', () => {
      expect(searchArtists).to.be.a('function')
    })

    it('should have searchAlbums function', () => {
      expect(searchAlbums).to.be.a('function')
    })

    it('should have searchTracks function', () => {
      expect(searchTracks).to.be.a('function')
    })

    it('should have searchPlaylists function', () => {
      expect(searchPlaylists).to.be.a('function')
    })
  })

  context('search', () => {
    it('should fetch is called', () => {
      const stub = sinon
        .stub(global, 'fetch')
        .usingPromise(global.Promise)
        .resolves(response)

      search('Linkin Park', 'album')

      expect(stub.called).to.be.true
    })

    it('should fetch is called with correct URL', () => {
      const url = 'https://api.spotify.com/v1/search?q=Linkin Park&type=album'

      const stub = sinon
        .stub(global, 'fetch')
        .usingPromise(global.Promise)
        .resolves(response)

      search('Linkin Park', 'album')

      expect(stub.calledWith(url)).to.be.true
    })
  })

  context('searchArtists', () => {
    it('should fetch is called', () => {
      const stub = sinon
        .stub(global, 'fetch')
        .usingPromise(global.Promise)
        .resolves(response)

      searchArtists('Linkin Park')

      expect(stub.called).to.be.true
    })

    it('should fetch is called with correct URL', () => {
      const url = 'https://api.spotify.com/v1/search?q=Linkin Park&type=artist'

      const stub = sinon
        .stub(global, 'fetch')
        .usingPromise(global.Promise)
        .resolves(response)

      searchArtists('Linkin Park')

      expect(stub.calledWith(url)).to.be.true
    })
  })

  context('searchAlbums', () => {
    it('should fetch is called', () => {
      const stub = sinon
        .stub(global, 'fetch')
        .usingPromise(global.Promise)
        .resolves(response)

      searchAlbums('Linkin Park')

      expect(stub.called).to.be.true
    })

    it('should fetch is called with correct URL', () => {
      const url = 'https://api.spotify.com/v1/search?q=Linkin Park&type=album'

      const stub = sinon
        .stub(global, 'fetch')
        .usingPromise(global.Promise)
        .resolves(response)

      searchAlbums('Linkin Park')

      expect(stub.calledWith(url)).to.be.true
    })
  })

  context('searchTracks', () => {
    it('should fetch is called', () => {
      const stub = sinon
        .stub(global, 'fetch')
        .usingPromise(global.Promise)
        .resolves(response)

      searchTracks('Linkin Park')

      expect(stub.called).to.be.true
    })

    it('should fetch is called with correct URL', () => {
      const url = 'https://api.spotify.com/v1/search?q=Linkin Park&type=track'

      const stub = sinon
        .stub(global, 'fetch')
        .usingPromise(global.Promise)
        .resolves(response)

      searchTracks('Linkin Park')

      expect(stub.calledWith(url)).to.be.true
    })
  })

  context('searchPlaylist', () => {
    it('should fetch is called', () => {
      const stub = sinon
        .stub(global, 'fetch')
        .usingPromise(global.Promise)
        .resolves(response)

      searchPlaylists('Linkin Park')

      expect(stub.called).to.be.true
    })

    it('should fetch is called with correct URL', () => {
      const url =
        'https://api.spotify.com/v1/search?q=Linkin Park&type=playlist'

      const stub = sinon
        .stub(global, 'fetch')
        .usingPromise(global.Promise)
        .resolves(response)

      searchPlaylists('Linkin Park')

      expect(stub.calledWith(url)).to.be.true
    })
  })
})
