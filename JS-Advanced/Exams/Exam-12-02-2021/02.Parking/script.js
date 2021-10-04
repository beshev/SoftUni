class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.vehicles.length == this.capacity) {
            throw new Error('Not enough parking space.');
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
        let car = this.vehicles.filter(c => c.carNumber == carNumber)[0];
        if (!car) {
            throw new Error('The car, you\'re looking for, is not found.');
        }

        if (!car.payed) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }
        let indexOf = this.vehicles.indexOf(car);
        this.vehicles.splice(indexOf, 1);

        return `${carNumber} left the parking lot.`;
    }

    pay(carNumber) {
        let car = this.vehicles.filter(c => c.carNumber == carNumber)[0];
        if (!car) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }

        if (car.payed) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }

        car.payed = true;

        return `${carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber) {
        let car = this.vehicles.filter(c => c.carNumber == carNumber)[0];

        if (car) {
            return `${car.carModel} == ${car.carNumber} - ${car.payed ? 'Has payed' : 'Not payed'}`;
        }

        let result = `The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.\n`;
        let carsInfo = this.vehicles.sort((a, b) => a.carModel.localeCompare(b.carModel)).map(c => `${c.carModel} == ${c.carNumber} - ${c.payed ? 'Has payed' : 'Not payed'}\n`).join('');
        result += carsInfo.trimEnd('\n');

        return result;
    }

}



const parking = new Parking(12);

console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.addCar("BMW X5", "PB888CR"));
console.log(parking.addCar("MCEDEC MM", "TT9999CR"));
console.log(parking.getStatistics('PB888CR'));

console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));
