import { expect } from 'chai';

import { renderAlbumList } from '../src/album-list';

describe('AlbumList', () => {
  const data1 = [{}];

  const markup1 = `
  <div class="menu-item">
    <img class="menu-item__image" src="https://picsum.photos/id/415/200/200" alt="album">
    <div class="menu-item__description">
      <p class="menu-item__title">Title</p>
      <p class="menu-item__subtitle">Description</p>
    </div>
  </div>`;

  it('should create markup and render that on html', () => {
    const element = document.createElement('div');
    renderAlbumList(data1, element);
    expect(element.innerHTML).to.be.eql(markup1);
  });

  const data2 = [{}, {}];

  const markup2 = `
  <div class="menu-item">
    <img class="menu-item__image" src="https://picsum.photos/id/415/200/200" alt="album">
    <div class="menu-item__description">
      <p class="menu-item__title">Title</p>
      <p class="menu-item__subtitle">Description</p>
    </div>
  </div>
  <div class="menu-item">
    <img class="menu-item__image" src="https://picsum.photos/id/415/200/200" alt="album">
    <div class="menu-item__description">
      <p class="menu-item__title">Title</p>
      <p class="menu-item__subtitle">Description</p>
    </div>
  </div>`;

  it('should create markup and render with more than one element', () => {
    const element = document.createElement('div');
    renderAlbumList(data2, element);
    expect(element.innerHTML).to.be.eql(markup2);
  });
});
