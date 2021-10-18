class VeterinaryClinic {
    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = [];
        this.totalProfit = 0;
        this.currentWorkload = 0;
    }

    newCustomer(ownerName, petName, kind, procedures) {
        if (this.currentWorkload == this.capacity) {
            throw Error('Sorry, we are not able to accept more patients!');
        }

        let currentOwner = this.clients.find(x => x.ownerName == ownerName);

        if (!currentOwner) {
            currentOwner = {
                ownerName: ownerName,
                pets: [],
            };
            this.clients.push(currentOwner);
        }

        let currentPet = currentOwner.pets.find(x => x.petName == petName);

        if (!currentPet) {
            currentPet = {
                petName,
                kind,
                petProcedures: [],
            }
            currentOwner.pets.push(currentPet);
        }
        
        if (currentPet && currentPet.petProcedures.length > 0) {
            throw Error(`This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${currentPet.petProcedures.join(', ')}.`);
        } else {
            this.currentWorkload++;
            currentPet.petProcedures.push(...procedures)
             return `Welcome ${petName}!`;
        }
    }

    onLeaving (ownerName, petName) {
        let currentOwner = this.clients.find(x => x.ownerName == ownerName);

        if (!currentOwner) {
            throw Error('Sorry, there is no such client!');
        }

        let currentPet = currentOwner.pets.find(x => x.petName == petName);

        if (!currentPet || currentPet.petProcedures.length == 0) {
            throw Error(`Sorry, there are no procedures for ${petName}!`);
        }

        this.currentWorkload--;
        this.totalProfit += currentPet.petProcedures.length * 500;
        currentPet.petProcedures = [];

        return `Goodbye ${petName}. Stay safe!`;
    }

    toString() {
        let result = [];
        result.push(`${this.clinicName} is ${Math.floor((this.currentWorkload / this.capacity) * 100)}% busy today!`);
        result.push(`Total profit: ${this.totalProfit.toFixed(2)}$`);

        for (const owner of this.clients.sort((a, b) => a.ownerName.localeCompare(b.ownerName))) {
            result.push(`${owner.ownerName} with:`);

            for (const pet of owner.pets.sort((a, b) => a.petName.localeCompare(b.petName))) {
                result.push(`---${pet.petName} - a ${pet.kind.toLowerCase()} that needs: ${pet.petProcedures.join(', ')}`);
            }
        }

        return result.join('\n');
    }
}


let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B'])); 
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.toString());
clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']); 
console.log(clinic.toString());

