const isSymmetric = require('./05.checkForSymmetry');
const assert = require('chai').assert;


describe('isSymmetric function tests',  () => {
    it('isSymmetric should work correctly', () => {
      let input = [1,2,2,1];
      let expectedResult = true;
      let actualResult = isSymmetric(input);

      assert.equal(actualResult,expectedResult);
    })

    it('isSymmetric should work correctly with an empty array', () => {
        let input = [];
        let expectedResult = true;
        let actualResult = isSymmetric(input);
  
        assert.equal(actualResult,expectedResult);
      })

    it('isSymmetric should return false', () => {
        let input = [1,2,2,3];
        let expectedResult = false;
        let actualResult = isSymmetric(input);
  
        assert.equal(actualResult,expectedResult);
    })

    it('isSymmetric should return false with difference value type', () => {
        let input = [2,'2'];
        let expectedResult = false;
        let actualResult = isSymmetric(input);
  
        assert.equal(actualResult,expectedResult);
    })

    it('isSymmetric should return false with uncorrect data types', () => {
        let expectedResult = false;
  
        assert.equal(isSymmetric({}),expectedResult);
        assert.equal(isSymmetric(2),expectedResult);
        assert.equal(isSymmetric(''),expectedResult);
        assert.equal(isSymmetric('Test 123'),expectedResult);
        assert.equal(isSymmetric(null),expectedResult);
        assert.equal(isSymmetric(undefined),expectedResult);
        assert.equal(isSymmetric(true),expectedResult);
    })
})