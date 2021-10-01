const PaymentPackage = require('./script');
const assert = require('chai').assert;

describe('paymentCheck', function () {
    let payCheck;
    this.beforeEach(() => {
        payCheck = new PaymentPackage('Test', 20);
    })

    describe('Testing "name" accessor', function () {
        it('Getter should work correct', () => {
            assert.equal(payCheck.name, 'Test')
        })

        it('Setter should work correct', () => {
            let expected = 'Next test';
            payCheck.name = 'Next test';

            assert.equal(payCheck.name, expected)
        })

        it('Setter should throw exception if name is not a string', () => {
            assert.throw(() => {
                payCheck.name = 0;
            })

            assert.throw(() => {
                payCheck.name = null;
            })

            assert.throw(() => {
                payCheck.name = undefined;
            })
        })

        it('Setter should throw exception if name is empty', () => {
            assert.throw(() => {
                payCheck.name = '';
            })
        })
    });

    describe('Testing "value" accessor', function () {
        it('Getter should work correct', () => {
            assert.equal(payCheck.value, 20)
        })

        it('Setter should work correct', () => {
            let expected = 300;
            payCheck.value = 300;

            assert.equal(payCheck.value, expected)
        })

        it('Setter should throw exception if value is not a number', () => {
            assert.throw(() => {
                payCheck.value = 'gosho';
            })

            assert.throw(() => {
                payCheck.value = null;
            })

            assert.throw(() => {
                payCheck.value = undefined;
            })
        })

        it('Setter should throw exception if value is negative number', () => {
            assert.throw(() => {
                payCheck.value = -25;
            })

            assert.throw(() => {
                payCheck.value = -30;
            })
        })
    });

    describe('Testing "VAT" accessor', function () {
        it('Getter should work correct', () => {
            assert.equal(payCheck.VAT, 20)
        })

        it('Setter should work correct', () => {
            let expected = 256;
            payCheck.VAT = 256;

            assert.equal(payCheck.VAT, expected)
        })

        it('Setter should throw exception if VAT is not a number', () => {
            assert.throw(() => {
                payCheck.VAT = 'gosho';
            })

            assert.throw(() => {
                payCheck.VAT = null;
            })

            assert.throw(() => {
                payCheck.VAT = undefined;
            })
        })

        it('Setter should throw exception if VAT is negative number', () => {
            assert.throw(() => {
                payCheck.VAT = -25;
            })

            assert.throw(() => {
                payCheck.VAT = -30;
            })
        })
    });

    describe('Testing "active" accessor', function () {
        it('Getter should work correct', () => {
            assert.equal(payCheck.active, true);
        })

        it('Setter should work correct', () => {
            let expected = false;
            payCheck.active = false;

            assert.equal(payCheck.active, expected)
        })

        it('Setter should throw exception if active is not boolean', () => {
            assert.throw(() => {
                payCheck.active = 'gosho';
            })

            assert.throw(() => {
                payCheck.active = null;
            })

            assert.throw(() => {
                payCheck.active = undefined;
            })

            assert.throw(() => {
                payCheck.active = 20;
            })
        })
    });

    describe('Testing "toString()" method', function () {
        it('Should work with active paycheck', () => {
            let newObj = new PaymentPackage('HR Services', 1500);
            assert.equal(newObj.toString(),'Package: HR Services\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800');
        })

        it('Should work with inactive paycheck', () => {
            let newObj = new PaymentPackage('HR Services', 1500);
            newObj.active = false;
            assert.equal(newObj.toString(),'Package: HR Services (inactive)\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800');
        })

        it("test toString", () => {
            let newObj = new PaymentPackage('HR Services', 1500);
            newObj.VAT = 0;
            assert.equal(newObj.toString(),'Package: HR Services\n- Value (excl. VAT): 1500\n- Value (VAT 0%): 1500');
        });

        it("test toString", () => {
            let newObj = new PaymentPackage('HR Services', 0);
            newObj.VAT = 0;
            assert.equal(newObj.toString(),'Package: HR Services\n- Value (excl. VAT): 0\n- Value (VAT 0%): 0');
        });
    });
});
