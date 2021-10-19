class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        for (const productInfo of products) {
            let [name, quantity, totalPrice] = productInfo.split(' ').filter(x => x.length > 0);
            quantity = Number(quantity);

            if (totalPrice <= this.budgetMoney) {
                if (!this.stockProducts.hasOwnProperty(name)) {
                    this.stockProducts[name] = 0;
                }

                this.stockProducts[name] += quantity;
                this.budgetMoney -= totalPrice;
                this.history.push(`Successfully loaded ${quantity} ${name}`);
            } else {
                this.history.push(`There was not enough money to load ${quantity} ${name}`);
            }
        }

        return this.history.join('\n');
    }

    addToMenu(meal, products, price) {
        if (this.menu.hasOwnProperty(meal)) {
            return `The ${meal} is already in the our menu, try something different.`;
        }
        this.menu[meal] = {
            products,
            price,
        }

        let meals = Object.keys(this.menu);

        if (meals.length == 1) {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        }

        return `Great idea! Now with the ${meal} we have ${meals.length} meals in the menu, other ideas?`;
    }

    showTheMenu(){
        let menu = Object.keys(this.menu);

        if (menu.length == 0) {
            return `Our menu is not ready yet, please come later...`;
        }

        let result = [];

        for (const key of menu) {
            result.push(`${key} - $ ${this.menu[key].price}`);
        }

         return result.join('\n');
    }

    makeTheOrder(meal) {
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`
        }

        let currentMeal = this.menu[meal];

        for (const productInfo of currentMeal.products) {
            let [name, quantity] = productInfo.split(' ').filter(x => x.length > 0);
            quantity = Number(quantity);
            if (!this.stockProducts[name] || this.stockProducts[name] < quantity) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        }

        for (const productInfo of currentMeal.products) {
            let [name, quantity] = productInfo.split(' ').filter(x => x.length > 0);
            quantity = Number(quantity);
            this.stockProducts[name] -= quantity;
        }

        this.budgetMoney += currentMeal.price;
        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${currentMeal.price}.`;
    }
}