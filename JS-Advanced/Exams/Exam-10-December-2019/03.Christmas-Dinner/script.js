class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget() {
        return this._budget;
    }

    set budget(value) {
        if (value < 0) {
            throw Error('The budget cannot be a negative number');
        }
        this._budget = value;
    }

    shopping(product) {
        if (this.budget < product[1]) {
            throw Error('Not enough money to buy this product');
        }

        this.products.push(product[0]);
        this.budget -= product[1];
        return `You have successfully bought ${product[0]}!`
    }

    recipes(recipe) {
        recipe.productsList.forEach(x => {
            if (!this.products.includes(x)) {
                throw Error('We do not have this product');
            }
        });

        this.dishes.push(recipe);
        return `${recipe.recipeName} has been successfully cooked!`;
    }

    inviteGuests(name, dish) {
        if (!this.dishes.some(x => x.recipeName == dish)) {
            throw Error('We do not have this dish');
        }

        if (this.guests[name]) {
            throw Error('This guest has already been invited');
        }

        this.guests[name] = dish;
        return `You have successfully invited ${name}!`;
    }

    showAttendance() {
        let result = [];

        for (const guest in this.guests) {
            let dish = this.dishes.find(x => x.recipeName == this.guests[guest]);

            result.push(`${guest} will eat ${this.guests[guest]}, which consists of ${dish.productsList.join(', ')}`);
        }

        return result.join('\n');
    }
}


let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);


console.log(dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
}));

dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});


console.log(dinner.inviteGuests('Ivan', 'Oshav'));
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());


