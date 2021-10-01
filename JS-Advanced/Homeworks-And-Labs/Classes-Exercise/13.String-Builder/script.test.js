const StringBuilder = require('./script');
const assert = require('chai').assert;

describe('stringBuilder', () => {

    describe('constructor', () => {
        it('Should throw exception for invalid input is not string', () => {
            assert.throw(() => {
                new StringBuilder(2);
            })

            assert.throw(() => {
                new StringBuilder([]);
            })
        })

        it('Should create builder with give string', () => {
            let sb = new StringBuilder('test');
            assert.deepEqual(sb._stringArray,['t','e','s','t']);
        })

        it('Should create builder without parameters', () => {
            let sb = new StringBuilder();
            assert.deepEqual(sb._stringArray,[]);
        })
    })

    describe('append', () => {
        it('Should work correct', () => {
            let sb = new StringBuilder();
            sb.append('Test');
            sb.append(' 123')

            assert.equal(sb.toString(),'Test 123');
        })

        it('Should throw exception if argument is not string', () => {
            let sb = new StringBuilder();
            
            assert.Throw(() => {
                sb.append(2);
            })

            assert.Throw(() => {
                sb.append(null);
            })
        })
    })

    describe('prepend', () => {
        it('Should work correct', () => {
            let sb = new StringBuilder();
            sb.append('Test');
            sb.prepend('Befor-')
            assert.equal(sb.toString(),'Befor-Test');
        })

        it('Should throw exception if argument is not string', () => {
            let sb = new StringBuilder();
            sb.append('Test');

            assert.Throw(() => {
                sb.prepend(2);
            })

            assert.Throw(() => {
                sb.prepend(null);
            })
        })
    })

    describe('insertAt', () => {
        it('Should work correct', () => {
            let sb = new StringBuilder();
            sb.append('ad');
            sb.insertAt('bc',1);
            sb.insertAt('!',0);
            sb.insertAt('!',4);
            assert.equal(sb.toString(),'!abc!d');
        })

        it('Should throw exception if argument is not string', () => {
            let sb = new StringBuilder();
            sb.append('Test');

            assert.Throw(() => {
                sb.insertAt(2,2);
            })

            assert.Throw(() => {
                sb.insertAt(null,2);
            })
        })
    })

    describe('remove', () => {
        it('Should work correct', () => {
            let sb = new StringBuilder();
            sb.append('123456789');
            sb.remove(2,3);
            assert.equal(sb.toString(),'126789');
        })

        it('Should work correct', () => {
            let sb = new StringBuilder();
            sb.append('Hello');
            sb.remove(3,2);
            assert.equal(sb.toString(),'Hel');
        })
    })

    describe('toString', () => {
        it('Should work correct', () => {
            let sb = new StringBuilder('Hello');

            assert.equal(sb.toString(),'Hello');
        })

        it('Should work correct', () => {
            let sb = new StringBuilder('Hello');
            sb.append(' World')
            assert.equal(sb.toString(),'Hello World');
        })

        it('Should work correct', () => {
            let sb = new StringBuilder();
            sb.append('World')
            sb.prepend('Hello ')
            assert.equal(sb.toString(),'Hello World');
        })

        it('Should work correct', () => {
            let sb = new StringBuilder();
            assert.equal(sb.toString(),'');
        })

    })
})