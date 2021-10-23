class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.vehicles.length == this.capacity) {
            throw Error('Not enough parking space.');
        }

        let newCar = {
            carModel,
            carNumber,
            payed: false,
        }

        this.vehicles.push(newCar);
        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {
        let car = this.vehicles.find(x => x.carNumber == carNumber);

        if (!car) {
            throw Error("The car, you're looking for, is not found.");
        }

        if (!car.payed) {
            throw Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }

        this.vehicles.splice(this.vehicles.indexOf(car), 1);
        return `${carNumber} left the parking lot.`;
    }

    pay(carNumber) {
        let car = this.vehicles.find(x => x.carNumber == carNumber);

        if (!car) {
            throw Error(`${carNumber} is not in the parking lot.`);
        }

        if (car.payed) {
            throw Error(`${carNumber}'s driver has already payed his ticket.`);
        }

        car.payed = true;
        return `${carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber) {
        let car = this.vehicles.find(x => x.carNumber == carNumber);
        if (car) {
            return `${car.carModel} == ${car.carNumber} - ${car.payed ? 'payed' : 'Not payed'}`;
        }

        let result = [
            `The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.`
        ];

        this.vehicles
            .sort((a, b) => a.carModel.localeCompare(b.carModel))
            .forEach(car => result.push(`${car.carModel} == ${car.carNumber} - ${car.payed ? 'payed' : 'Not payed'}`));
        
        return result.join('\n');

    }
}
