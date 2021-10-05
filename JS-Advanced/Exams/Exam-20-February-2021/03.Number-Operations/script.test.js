let numberOperations = require('./script');
let assert = require('chai').assert;


describe("numberOperations", () => {
    describe("powNumber", () => {
        it("Should work", () => {
            assert.equal(numberOperations.powNumber(2), 4);
            assert.equal(numberOperations.powNumber(4), 16);
            assert.equal(numberOperations.powNumber(10), 100);
        });

        it("Should work with negative number", () => {
            assert.equal(numberOperations.powNumber(-8), 64);
            assert.equal(numberOperations.powNumber(-20), 400);
        });
    });
    describe("numberChecker", () => {
        it("Should throw error if non-number is passet", () => {
            assert.throw(() => {
                numberOperations.numberChecker('Im go');
            })
            assert.throw(() => {
                numberOperations.numberChecker(undefined);
            })
        });

        it("Should return massege for number greater or equal than 100", () => {
            assert.equal(numberOperations.numberChecker(100), `The number is greater or equal to 100!`)
            assert.equal(numberOperations.numberChecker(150), `The number is greater or equal to 100!`)
            assert.equal(numberOperations.numberChecker(1000), `The number is greater or equal to 100!`)
        });

        it("Should return massege for number lower than 100", () => {
            assert.equal(numberOperations.numberChecker(-1), `The number is lower than 100!`)
            assert.equal(numberOperations.numberChecker(20), `The number is lower than 100!`)
            assert.equal(numberOperations.numberChecker(99), `The number is lower than 100!`)
        });
    });
    describe("sumArrays", () => {
        it("Should work", () => {
            let arr1 = [1, 2, 3, 4];
            let arr2 = [1, 2, 3, 4];
            let result = [2, 4, 6, 8];

            assert.deepEqual(numberOperations.sumArrays(arr1, arr2), result)
        });

        it("Should work when firstArray is longer", () => {
            let arr1 = [5, 8, 20, 30,40,50];
            let arr2 = [1, 2, 3, 4];
            let result = [6, 10, 23, 34,40,50];

            assert.deepEqual(numberOperations.sumArrays(arr1, arr2), result)
        });

        it("Should work when secondArray is longer", () => {
            let arr1 = [1, 2, 3, 4];
            let arr2 = [5, 8, 20, 30,100,-50];
            let result = [6, 10, 23, 34,100,-50];

            assert.deepEqual(numberOperations.sumArrays(arr1, arr2), result)
        });

        it("Should work with float numbers", () => {
            let arr1 = [5.6, 8.7, 1.3, 3.5];
            let arr2 = [0.4, 0.3, 1.4, 3.6];
            let result = [6, 9, 2.7, 7.1];

            assert.deepEqual(numberOperations.sumArrays(arr1, arr2), result)
        });
    });
});
