const createCalculator = require('./07.addSubtract');
const assert = require('chai').assert;

describe('Tests for createCalculator function', () => {
    let calculator ;

    beforeEach(() => {
        calculator = createCalculator();
    })

    it('Should return an object', () => {
        let expected = JSON.stringify({add: function (num) {},subtract: function (num) {},get: function () {}})
        let actual = JSON.stringify(calculator);
        
        assert.equal(actual,expected);
    })

    
    it('Get should return 0', () => {
        let expected = 0;
        let actual = calculator.get();
        
        assert.equal(actual,expected);
    })

    it('Add should work with number', () => {
        calculator.add(2);
        calculator.add(2);
        let expected = 4;
        let actual = calculator.get();
        
        assert.equal(actual,expected);
    })

    it('Add should work with numberAsString', () => {
        calculator.add('5');
        calculator.add('4');
        let expected = 9;
        let actual = calculator.get();
        
        assert.equal(actual,expected);
    })

    it('Subtract should work with number', () => {
        calculator.add(5);
        calculator.add(10);
        calculator.subtract(3)
        
        let expected = 12;
        let actual = calculator.get();
        
        assert.equal(actual,expected);
    })

    it('Subtract should work with numberAsString', () => {
        calculator.subtract('15')
        
        let expected = -15;
        let actual = calculator.get();
        
        assert.equal(actual,expected);
    })
    
})