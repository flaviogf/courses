import { expect } from 'chai';
import { sum, sub, mult, div } from '../src/main';

describe('Calc', () => {
  it('should return 4 when sum(2, 2)', () => {
    expect(sum(2, 2)).to.be.equal(4);
  });

  it('should return 4 when sub(6, 2)', () => {
    expect(sub(6, 2)).to.be.equal(4);
  });

  it('should return 4 when mult(2, 2)', () => {
    expect(mult(2, 2)).to.be.equal(4);
  });

  it('should return 4 when div(8, 2)', () => {
    expect(div(8, 2)).to.be.equal(4);
  });

  it('should return "Division by zero not exists." when div(4, 0)', () => {
    expect(div(4, 0)).to.be.equal('Division by zero not exists.');
  });
});
