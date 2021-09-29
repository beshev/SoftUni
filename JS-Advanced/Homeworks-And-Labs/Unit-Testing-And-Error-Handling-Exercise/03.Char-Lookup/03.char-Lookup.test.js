const lookupChar = require('./03.char-Lookup');
const assert = require('chai').assert;

describe('Tests for lookupChar function', () => {
    it('Should return undifende if first parameter is NOT a string', () => {
        assert.equal(lookupChar([],2),undefined);
        assert.equal(lookupChar({},2),undefined);
        assert.equal(lookupChar(true,2),undefined);
        assert.equal(lookupChar(undefined,2),undefined);
        assert.equal(lookupChar(2,2),undefined);
        assert.equal(lookupChar(null,2),undefined);
    })

    it('Should return undifende if second parameter is NOT a number', () => {
        assert.equal(lookupChar('test1','test1'),undefined);
        assert.equal(lookupChar('test1',null),undefined);
        assert.equal(lookupChar('test1',undefined),undefined);
        assert.equal(lookupChar('test1',[]),undefined);
        assert.equal(lookupChar('test1',{}),undefined);
        assert.equal(lookupChar('test1',true),undefined);
        assert.equal(lookupChar('test1',2.2),undefined);
    })

    it('Should return "Incorrect index" if index is out of range', () => {
        let expected = "Incorrect index";

        assert.equal(lookupChar('test1',5),expected);
        assert.equal(lookupChar('test1',10),expected);
        assert.equal(lookupChar('test1',-5),expected);
    })

    it('Should work correctly', () => {
        let string = 'test1';
        let index = 4;
        let expected = '1';
        let actual = lookupChar(string,index)

        assert.equal(expected,actual);
    })
})