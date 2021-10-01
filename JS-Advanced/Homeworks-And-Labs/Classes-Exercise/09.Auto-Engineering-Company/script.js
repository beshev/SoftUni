function solve(input) {
    let cars = {};

    for (const carInfo of input) {
        let [brand, model, quantity] = carInfo.split(' | ');
        quantity = Number(quantity);

        if (!cars[brand]) {
            cars[brand] = new Map();
        }

        if (!cars[brand].has(model)) {
            cars[brand].set(model, 0);
        }

        cars[brand].set(model, cars[brand].get(model) + quantity);
    }

    for (const car in cars) {
        console.log(car);
        for (const [key, value] of cars[car]) {
            console.log(`###${key} -> ${value}`);
        }
    }
}


console.log(solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'])
);