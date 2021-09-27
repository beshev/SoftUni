const sum = require('./04.sumOfNumbers');
const assert = require('chai').assert;

describe('Sum numbers tests',  () => {
    it('Sum should work currect with possitive numbers', () => {
        let input = [1,2,3,4,5];
        let expectedResult = sum(input);
        let actualResult = 15;

        assert.equal(actualResult,expectedResult);
    })

    it('Sum should work currect with negative numbers', () => {
        let input = [-1,-2,-3,-4,-5];
        let expectedResult = sum(input);
        let actualResult = -15;

        assert.equal(actualResult,expectedResult);
    })

    it('Sum should false', () => {
        let input = [1,2,3,4,5];
        let expectedResult = sum(input);
        let actualResult = 12;

        assert.notEqual(actualResult,expectedResult);
    })
})