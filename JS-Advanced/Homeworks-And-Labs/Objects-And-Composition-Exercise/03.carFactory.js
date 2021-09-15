function solve(carInfo) {
    let car = {model: carInfo.model};
    car.engine = setcarEngine(carInfo.power);
    car.carriage = {type: carInfo.carriage, color: carInfo.color};
    car.wheels = setCarWheels(carInfo.wheelsize);

    return car;

    function setCarWheels(wheelsize) {
        if (wheelsize % 2 == 0) {
            wheelsize--;
        }
        
        return[wheelsize,wheelsize,wheelsize,wheelsize];
    }

    function setcarEngine(power) {
        if (power <= 90) {
            return {power: 90, volume: 1800};
        } else if (power <= 120) {
            return {power: 120, volume: 2400};
        } else if (power <= 200) {
            return {power: 200, volume: 3500};
        }
    }
}

console.log(solve({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
));

console.log(solve({ model: 'Opel Vectra',
power: 110,
color: 'grey',
carriage: 'coupe',
wheelsize: 17 }
));