const expected = require('chai').expect;

describe('Main', () => {
  let itens;

  before(() => {
    console.log('before');
  });

  after(() => {
    console.log('after');
  });

  beforeEach(() => {
    itens = [1, 2, 3];
  });

  afterEach(() => {
    console.log('afterEach');
  });

  it('should hava a size of 4', () => {
    itens.push(4);
    expected(itens).to.be.length(4);
  });

  it('should remove value 3 when pop', () => {
    expected(itens.pop()).to.be.equal(3);
  });

  it('should have size of 2 when pop', () => {
    itens.pop();
    expected(itens).to.be.length(2);
  });
});
