class Vacationer {
    constructor(fullName, creditCard) {
        this.fullName = fullName;

        this.idNumber = this.generateIDNumber();

        this.creditCard = {
            cardNumber: 1111,
            expirationDate: '',
            securityNumber: 111,
        };

        if (creditCard) {
            this.addCreditCardInfo(creditCard);
        }

        this.wishList = [];
    }

    get fullName() {
        return this._fullName;
    }

    set fullName(input) {
        if (input.length != 3) {
            throw Error('Name must include first name, middle name and last name');
        }

        let regex = /^[A-Z][a-z]+$/;
        let firstName = input[0];
        let middleName = input[1];
        let lastName = input[2];

        if (!firstName.match(regex) || !middleName.match(regex) || !lastName.match(regex)) {
            throw Error('Invalid full name');
        }

        this._fullName = {
            firstName,
            middleName,
            lastName
        };
    }

    generateIDNumber() {
        let vowel = ['a', 'e', 'o', 'i', 'u'];

        let firsNameASCII = this.fullName.firstName.charCodeAt(0);

        let id = `${231 * firsNameASCII + 139 * this.fullName.middleName.length}`;
        let lastLetter = this.fullName.lastName.substr(this.fullName.lastName.length - 1);

        if (vowel.includes(lastLetter)) {
            id += '8';
        } else {
            id += '7';
        }

        return id;
    }

    addCreditCardInfo(input) {
        if (input.length != 3) {
            throw Error('Missing credit card information');
        }

        if (typeof input[0] !== 'number' || typeof input[2] !== 'number') {
            throw Error('Invalid credit card details');
        }

        this.creditCard.cardNumber = input[0];
        this.creditCard.expirationDate = input[1]
        this.creditCard.securityNumber = input[2];
    }

    addDestinationToWishList(destination) {
        if (this.wishList.includes(destination)) {
            throw Error('Destination already exists in wishlist');
        }

        this.wishList.push(destination);
        this.wishList.sort((a, b) => a.length - b.length);
    }

    getVacationerInfo() {
        let result = [
            `Name: ${this.fullName.firstName} ${this.fullName.middleName} ${this.fullName.lastName}`,
            `ID Number: ${this.idNumber}`,
            `Wishlist:`,
            `${this.wishList.length > 0 ? this.wishList.join(', ') : 'empty'}`,
            `Credit Card:`,
            `Card Number: ${this.creditCard.cardNumber}`,
            `Expiration Date: ${this.creditCard.expirationDate}`,
            `Security Number: ${this.creditCard.securityNumber}`,
        ];

        return result.join('\n');
    }
}




