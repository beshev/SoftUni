const isOddOrEven = require('./02.Even-Or-Odd');
const assert = require('chai').assert;

describe('Tests for isOddOrEven function', () => {
    it('Should return undefined if type is not a string', () => {
        assert.equal(isOddOrEven(123),undefined);
        assert.equal(isOddOrEven([]),undefined);
        assert.equal(isOddOrEven({}),undefined);
        assert.equal(isOddOrEven(null),undefined);
        assert.equal(isOddOrEven(true),undefined);
        assert.equal(isOddOrEven(undefined),undefined);
    })

    it('Should return "odd" for odd length of string', () => {
        let expect = 'odd';
        let actual =isOddOrEven('123');

        assert.equal(expect,actual);
    })

    it('Should return "even" for even length of string', () => {
        let expect = 'even';
        let actual =isOddOrEven('1234');

        assert.equal(expect,actual);
    })
})