let dealership = require('./script');
let assert = require('chai').assert;


describe("Tests …", function () {
    describe("newCarCost", function () {
        it("Should deduct price for Audi A4", function () {
            assert.equal(dealership.newCarCost('Audi A4 B8', 20000), 5000);
        });

        it("Should deduct price for Audi A6", function () {
            assert.equal(dealership.newCarCost('Audi A6 4K', 30000), 10000);
        });

        it("Should deduct price for Audi A8", function () {
            assert.equal(dealership.newCarCost('Audi A8 D5', 50000), 25000);
        });

        it("Should deduct price for Audi TT", function () {
            assert.equal(dealership.newCarCost('Audi TT 8J', 18000), 4000);
        });

        it("Should not deduct price", function () {
            assert.equal(dealership.newCarCost('', 18000), 18000);
            assert.equal(dealership.newCarCost('BWM', 8000), 8000);
            assert.equal(dealership.newCarCost('Dacia', 30000), 30000);
        });

    });

    describe("carEquipment", function () {
        it('Should return selected extras', () => {
            assert.deepEqual(dealership.carEquipment(['Test1', 'Test2', 'Test3', 'Test4', 'Test5'], [0, 2, 4]), ['Test1', 'Test3', 'Test5'])
            assert.deepEqual(dealership.carEquipment(['Test1', 'Test2', 'Test3'], [0]), ['Test1'])
            assert.deepEqual(dealership.carEquipment(['Test1', 'Test2', 'Test3'], [0, 1, 2]), ['Test1', 'Test2', 'Test3'])
        })
    });

    describe("euroCategory", function () {
        it('Should made discount for category equal or bigger than 4', () => {
           assert.equal(dealership.euroCategory(4),'We have added 5% discount to the final price: 14250.');
           assert.equal(dealership.euroCategory(10),'We have added 5% discount to the final price: 14250.');
        })

        it('Should not do discount for category below 4', () => {
            assert.equal(dealership.euroCategory(3),'Your euro category is low, so there is no discount from the final price!');
            assert.equal(dealership.euroCategory(0),'Your euro category is low, so there is no discount from the final price!');
            assert.equal(dealership.euroCategory(-2),'Your euro category is low, so there is no discount from the final price!');
         })
    });
});
