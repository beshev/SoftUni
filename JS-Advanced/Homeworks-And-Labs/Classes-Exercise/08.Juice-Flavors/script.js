function solve(input) {
    let bottles = new Map();
    let juices = {};

    for (const juiceInfo of input) {
        let [juice, quantity] = juiceInfo.split(' => ');
        quantity = Number(quantity);

        if (!juices[juice]) {
            juices[juice] = 0;
        }
        juices[juice] += quantity;

        if (juices[juice] >= 1000) {
            let currentBottles = Math.floor(juices[juice] / 1000);
            if (!bottles.has(juice)) {
                bottles.set(juice, 0);
            }
            bottles.set(juice, bottles.get(juice) + currentBottles)
            juices[juice] -= currentBottles * 1000;
        }
    }

    let result = '';

    for (const [key, value] of bottles) {
       result += `${key} => ${value}\n`;
    }

    return result.trimEnd('\n');
}


console.log(solve(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
));

console.log(solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
));