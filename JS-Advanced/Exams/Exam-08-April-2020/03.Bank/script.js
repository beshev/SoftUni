class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
        this._transactions = {};
    }

    newCustomer(customer) {
        if (this.allCustomers.some(x => x.personalId == customer.personalId)) {
            throw Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }

        this.allCustomers.push(customer);
        return customer;
    }

    depositMoney(personalId, amount) {
        let customer = this.allCustomers.find(x => x.personalId == personalId);

        if (!customer) {
            throw Error('We have no customer with this ID!');
        }

        if (!customer['totalMoney']) {
            customer['totalMoney'] = 0
        }
        customer['totalMoney'] += amount;

        if (!this._transactions[customer.personalId]) {
            this._transactions[customer.personalId] = [];
        }

        this._transactions[customer.personalId].unshift(`${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`);
        return `${customer.totalMoney}$`;

    }

    withdrawMoney(personalId, amount) {
        let customer = this.allCustomers.find(x => x.personalId == personalId);

        if (!customer) {
            throw Error('We have no customer with this ID!');
        }

        if (customer.totalMoney < amount) {
            throw Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }

        customer.totalMoney -= amount;

        if (!this._transactions[customer.personalId]) {
            this._transactions[customer.personalId] = [];
        }

        this._transactions[customer.personalId].unshift(`${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);
        return `${customer.totalMoney}$`;
    }

    customerInfo(personalId) {
        let customer = this.allCustomers.find(x => x.personalId == personalId);

        if (!customer) {
            throw Error('We have no customer with this ID!');
        }

        let result = [
            `Bank name: ${this._bankName}`,
            `Customer name: ${customer.firstName} ${customer.lastName}`,
            `Customer ID: ${customer.personalId}`,
            `Total Money: ${customer.totalMoney}$`,
            'Transactions:'
        ]

        let tranCount = this._transactions[customer.personalId].length;

        for (const tran of this._transactions[customer.personalId]) {
            result.push( `${tranCount--}. ` + tran);
        }

        return result.join('\n');
    }
}

let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267}));
console.log(bank.newCustomer({firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));


