let pizzUni = require('./script');
let assert = require('chai').assert;

describe("pizzUni", function () {
    let pizza;
    // the object includes {orderedPizza: ‘the name of the pizza’, orderedDrink: ‘the name of the drink’
    this.beforeEach(() => {
        pizza = {
            orderedPizza: 'Mocarela',
            orderedDrink: 'Coca-cola',
        }
    })

    describe("makeAnOrder", function () {
        it("Should throw error if no pizza ordered", function () {
            pizza.orderedPizza = '';
            assert.throws(() => {
                pizzUni.makeAnOrder(pizza);
            })

            pizza.orderedPizza = null;
            assert.throws(() => {
                pizzUni.makeAnOrder(pizza);
            })

            pizza.orderedPizza = undefined;
            assert.throws(() => {
                pizzUni.makeAnOrder(pizza);
            })
        });

        it("Should work only with pizza and without drink", function () {
            pizza.orderedDrink = undefined;
            let expected = 'You just ordered Mocarela';
            let actual = pizzUni.makeAnOrder(pizza);

            assert.equal(expected, actual);
        });

        it("Should work with pizza and drink", function () {
            let expected = 'You just ordered Mocarela and Coca-cola.';
            let actual = pizzUni.makeAnOrder(pizza);

            assert.equal(expected, actual);
        });
    });

    describe("getRemainingWork", function () {
        it('Should return all orders are completed.', () => {
            let arr = [{pizzaName: 'Margarita', status:'ready'},{pizzaName: 'Peperoni', status:'ready'},{pizzaName: 'Cabonara', status:'ready'}]

            let expected = 'All orders are complete!';
            let actual = pizzUni.getRemainingWork(arr);

            assert.equal(expected,actual);
        })

        it('Should return not completed orders', () => {
            let arr = [{pizzaName: 'Margarita', status:'preparing'},{pizzaName: 'Peperoni', status:'ready'},{pizzaName: 'Carbonara', status:'preparing'}]

            let expected = 'The following pizzas are still preparing: Margarita, Carbonara.';
            let actual = pizzUni.getRemainingWork(arr);

            assert.equal(expected,actual);
        })
    })

    describe("orderType", function() {
        it('Should discount', function() {
            let totalSum = 10;
            let orderType = 'Carry Out';

            let expected = totalSum * 0.9;
            let actual = pizzUni.orderType(totalSum,orderType);

            assert.equal(expected,actual);
            
        })

        it('Should not-discount', function() {
            let totalSum = 10;
            let orderType = 'Delivery';

            let actual = pizzUni.orderType(totalSum,orderType);

            assert.equal(totalSum,actual);
            
        })
    })

});
