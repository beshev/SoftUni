const rgbToHexColor = require('./06.RGBToHex.js');
const assert = require('chai').assert;

describe('rgbToHexColor tests',  () => {
    it('Should return undefined with negative numbers', () => {
        assert.strictEqual(rgbToHexColor(-50,2,2),undefined)
        assert.strictEqual(rgbToHexColor(2,-23,2),undefined)
        assert.strictEqual(rgbToHexColor(2,2,-2),undefined)
    })

    it('Should return undefined with number more than 255', () => {
        assert.strictEqual(rgbToHexColor(256,2,2),undefined)
        assert.strictEqual(rgbToHexColor(2,1000,2),undefined)
        assert.strictEqual(rgbToHexColor(2,2,600),undefined)
    })

    it('Should return undefined with float numbers', () => {
        assert.strictEqual(rgbToHexColor(2.56,2,2),undefined)
        assert.strictEqual(rgbToHexColor(2,20.35,2),undefined)
        assert.strictEqual(rgbToHexColor(2,2,156.23),undefined)
    })

    it('Should return undefined with invalid values types', () => {
        assert.strictEqual(rgbToHexColor([],2,2),undefined)
        assert.strictEqual(rgbToHexColor(2,{},2),undefined)
        assert.strictEqual(rgbToHexColor(2,2,null),undefined)
    })

    it('Should return black', () => {
        let red = 0;
        let green = 0;
        let blue = 0;

        let expected = "#" +
                    ("0" + red.toString(16).toUpperCase()).slice(-2) +
                    ("0" + green.toString(16).toUpperCase()).slice(-2) +
                    ("0" + blue.toString(16).toUpperCase()).slice(-2);

        let actual = rgbToHexColor(0,0,0);
        
        assert.strictEqual(actual,expected);
    })

    
    it('Should return white', () => {
        let red = 255;
        let green = 255;
        let blue = 255;

        let expected = "#" +
                    ("0" + red.toString(16).toUpperCase()).slice(-2) +
                    ("0" + green.toString(16).toUpperCase()).slice(-2) +
                    ("0" + blue.toString(16).toUpperCase()).slice(-2);

        let actual = rgbToHexColor(255,255,255);
        
        assert.strictEqual(actual,expected);
    })

    it('Should work uncorrect', () => {
        let red = 1;
        let green = 2;
        let blue = 20;
        let expected = "#" +
                    ("0" + red.toString(16).toUpperCase()).slice(-2) +
                    ("0" + green.toString(16).toUpperCase()).slice(-2) +
                    ("0" + blue.toString(16).toUpperCase()).slice(-2);

        let actual = rgbToHexColor(2,2,2);
        
        assert.notEqual(actual,expected);
    })
})