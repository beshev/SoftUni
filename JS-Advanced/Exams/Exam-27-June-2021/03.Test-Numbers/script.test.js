let testNumbers = require('./script');
let assert = require('chai').assert;

describe("testNumbers", function () {
    describe("sumNumbers", function () {
        it("Should retunr undefined if firstNumber is not a number", function () {
            assert.equal(testNumbers.sumNumbers('asd', 2), undefined);
            assert.equal(testNumbers.sumNumbers(undefined, 2), undefined);
            assert.equal(testNumbers.sumNumbers(true, 2), undefined);
        });

        it("Should retunr undefined if secondNumber is not a number", function () {
            assert.equal(testNumbers.sumNumbers(2, 'asd'), undefined);
            assert.equal(testNumbers.sumNumbers(2, undefined), undefined);
            assert.equal(testNumbers.sumNumbers(2, true), undefined);
        });

        it("Should retunr sum of numbers", function () {
            assert.equal(testNumbers.sumNumbers(1, 2), '3.00');
            assert.equal(testNumbers.sumNumbers(-15, -10), '-25.00');
            assert.equal(testNumbers.sumNumbers(-10, 10), '0.00');
            assert.equal(testNumbers.sumNumbers(2.35, 2.10), '4.45');
        });
    });

    describe("numberChecker", function () {
        it("Should thow exeption if input is not a number", function () {
            assert.throw(() => {
                testNumbers.numberChecker('Uss');
                testNumbers.numberChecker(undefined);
                testNumbers.numberChecker({});
            });
        });

        it("Should return message for even number", function () {
            assert.equal(testNumbers.numberChecker(6), 'The number is even!');
            assert.equal(testNumbers.numberChecker(-2), 'The number is even!');
        });

        it("Should return message for odd number", function () {
            assert.equal(testNumbers.numberChecker(3), 'The number is odd!');
            assert.equal(testNumbers.numberChecker(-5), 'The number is odd!');
            assert.equal(testNumbers.numberChecker(2.2), 'The number is odd!');
        });
    });

    describe("averageSumArray", function () {
        it("Should retunr avg sum of array", function () {
            assert.equal(testNumbers.averageSumArray([1, 2, 3, 10, 20]), 7.2);
            assert.equal(testNumbers.averageSumArray([2.3, 4.6, 5.5]),(2.3 + 4.6 + 5.5) / 3);
            assert.equal(testNumbers.averageSumArray([1,2,3]),2);
        });
    });
});
