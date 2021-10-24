class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {
            child: 150,
            student: 300,
            collegian: 500
        };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        if (!this.priceForTheCamp[condition]) {
            throw Error('Unsuccessful registration at the camp.');
        }

        if (this.listOfParticipants.some(x => x.name == name)) {
            return `The ${name} is already registered at the camp.`;
        }

        if (money < this.priceForTheCamp[condition]) {
            return `The money is not enough to pay the stay at the camp.`;
        }

        let newParticipant = {
            name,
            condition,
            power: 100,
            wins: 0,
        }

        this.listOfParticipants.push(newParticipant);
        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant(name) {
        let person = this.listOfParticipants.find(x => x.name == name);

        if (!person) {
            throw Error(`The ${name} is not registered in the camp.`);
        }

        let index = this.listOfParticipants.indexOf(person);
        this.listOfParticipants.splice(index, 1);
        return `The ${name} removed successfully.`;
    }

    timeToPlay(typeOfGame, participant1, participant2) {
        // WaterBalloonFights 
        // Battleship 
        let first = this.listOfParticipants.find(x => x.name == participant1);
        let second = this.listOfParticipants.find(x => x.name == participant2);

        if (!first) {
            throw Error('Invalid entered name/s.');
        }

        if (typeOfGame === 'Battleship') {
            first.power += 20;
            return `The ${first.name} successfully completed the game ${typeOfGame}.`;
        }
        
        if (!second) {
            throw Error('Invalid entered name/s.');
        }

        if (first.condition != second.condition) {
            throw Error('Choose players with equal condition.');
        }

        if (first.power == second.power) {
            return `There is no winner.`;
        }

        let winner = first.power > second.power ? first : second;
        winner.wins++;
        return `The ${winner.name} is winner in the game ${typeOfGame}.`;
    }

    toString() {
        let result = [
            `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`,
        ]

        for (const person of this.listOfParticipants.sort((a, b) => b.wins - a.wins)) {
            result.push(`${person.name} - ${person.condition} - ${person.power} - ${person.wins}`);
        }

        return result.join('\n');
    }
}


const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");

// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 200));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Leila Wolfe", "childd", 200));

// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.unregisterParticipant("Petar"));
// console.log(summerCamp.unregisterParticipant("Petar Petarson"));

console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
//console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));
console.log(summerCamp.toString());


