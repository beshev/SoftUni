const rgbToHexColor = require('./06.RGBToHex.js');
const assert = require('chai').assert;

describe('rgbToHexColor tests',  () => {
    it('Should return undefined with negative numbers', () => {
        assert.equal(rgbToHexColor(-1,2,2),undefined)
        assert.equal(rgbToHexColor(2,-1,2),undefined)
        assert.equal(rgbToHexColor(2,2,-2),undefined)
    })

    it('Should return undefined with number more than 255', () => {
        assert.equal(rgbToHexColor(256,2,2),undefined)
        assert.equal(rgbToHexColor(2,1000,2),undefined)
        assert.equal(rgbToHexColor(2,2,600),undefined)
    })

    it('Should return undefined with float numbers', () => {
        assert.equal(rgbToHexColor(2.56,2,2),undefined)
        assert.equal(rgbToHexColor(2,20.35,2),undefined)
        assert.equal(rgbToHexColor(2,2,156.23),undefined)
    })

    it('Should return undefined with invalid values types', () => {
        assert.equal(rgbToHexColor(null,2,2),undefined)
        assert.equal(rgbToHexColor(2,undefined,2),undefined)
        assert.equal(rgbToHexColor(2,2,'yes baby'),undefined)
    })

    it('Should work correct', () => {
        let expected = '#010203';
        let actual = rgbToHexColor(1,2,3);
        
        assert.equal(actual,expected);
    })

    it('Should work uncorrect', () => {
        let expected = '#010204';
        let actual = rgbToHexColor(1,2,3);
        
        assert.notEqual(actual,expected);
    })
})