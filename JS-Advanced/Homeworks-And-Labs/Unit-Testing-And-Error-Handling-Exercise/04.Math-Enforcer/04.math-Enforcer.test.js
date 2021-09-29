const mathEnforcer = require('./04.math-Enforcer');
const assert = require('chai').assert;

describe('Tests for mathEnforcer object functions', () => {
    describe('Test for addFive() function', () => {
        it('Add five should return undefined If the parameter is NOT a number', () => {
            assert.equal(mathEnforcer.addFive([]), undefined);
            assert.equal(mathEnforcer.addFive({}), undefined);
            assert.equal(mathEnforcer.addFive('string'), undefined);
            assert.equal(mathEnforcer.addFive(null), undefined);
            assert.equal(mathEnforcer.addFive(true), undefined);
            assert.equal(mathEnforcer.addFive(undefined), undefined);
        })

        it('Add five should add 5 to intiger number', () => {
            let number = 10;
            let expected = 15;
            let actual = mathEnforcer.addFive(number);

            assert.equal(expected, actual);
        })

        it('Add five should add 5 to float number', () => {
            let number = 5.07;
            let expected = 10.07;
            let actual = mathEnforcer.addFive(number);

            assert.closeTo(actual,expected,0.01);
            //assert.equal(expected, actual);
        })

        it('Add five should add 5 to negative number', () => {
            let number = -15;
            let expected = -10;
            let actual = mathEnforcer.addFive(number);

            assert.equal(expected, actual);
        })
    })
    describe('Test for subtractTen() function', () => {
        it('Subtract ten should return undefined If the parameter is NOT a number', () => {
            assert.equal(mathEnforcer.subtractTen([]), undefined);
            assert.equal(mathEnforcer.subtractTen({}), undefined);
            assert.equal(mathEnforcer.subtractTen('string'), undefined);
            assert.equal(mathEnforcer.subtractTen(null), undefined);
            assert.equal(mathEnforcer.subtractTen(true), undefined);
            assert.equal(mathEnforcer.subtractTen(undefined), undefined);
        })

        it('Subtract ten should subtract 10 from intiger number', () => {
            let number = 60;
            let expected = 50;
            let actual = mathEnforcer.subtractTen(number);

            assert.equal(expected, actual);
        })

        it('Subtract ten should subtract 10 from float number', () => {
            let number = 22.03;
            let expected = 12.03;
            let actual = mathEnforcer.subtractTen(number);

            assert.closeTo(actual,expected,0.01);
            //assert.equal(expected, actual);
        })

        it('Subtract ten should subtract 10 from negative number', () => {
            let number = -10;
            let expected = -20;
            let actual = mathEnforcer.subtractTen(number);

            assert.equal(expected, actual);
        })
    })

    describe('Test for sum() function', () => {
        it('Sum should return undefined If first parameter is NOT a number', () => {
            assert.equal(mathEnforcer.sum([], 2), undefined);
            assert.equal(mathEnforcer.sum({}, 2), undefined);
            assert.equal(mathEnforcer.sum('string', 2), undefined);
            assert.equal(mathEnforcer.sum(null, 2), undefined);
            assert.equal(mathEnforcer.sum(true, 2), undefined);
            assert.equal(mathEnforcer.sum(undefined, 2), undefined);
        })

        it('Sum should return undefined If second parameter is NOT a number', () => {
            assert.equal(mathEnforcer.sum(2, []), undefined);
            assert.equal(mathEnforcer.sum(2, {}), undefined);
            assert.equal(mathEnforcer.sum(2, 'string'), undefined);
            assert.equal(mathEnforcer.sum(2, null), undefined);
            assert.equal(mathEnforcer.sum(2, true), undefined);
            assert.equal(mathEnforcer.sum(2, undefined), undefined);
        })

        it('Sum should work with intiger numbers', () => {
            let firstNumber = 13;
            let secondNumber = 17;
            let expected = 30;
            let actual = mathEnforcer.sum(firstNumber, secondNumber);

            assert.equal(expected, actual);
        })

        it('Sum should work with float numbers', () => {
            let firstNumber = 12.5;
            let secondNumber = 12.08;
            let expected = 24.58;
            let actual = mathEnforcer.sum(firstNumber, secondNumber);

            assert.closeTo(actual,expected,0.01);
           // assert.equal(expected, actual);
        })

        it('Sum should work with negative numbers', () => {
            let firstNumber = -15;
            let secondNumber = -10;
            let expected = -25;
            let actual = mathEnforcer.sum(firstNumber, secondNumber);

            assert.equal(expected, actual);
        })
    })
})