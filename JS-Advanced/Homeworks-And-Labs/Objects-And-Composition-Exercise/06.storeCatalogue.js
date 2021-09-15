function solve(input) {
    let categories = {};

    for (const inputInfo of input) {
        let [product,price] = inputInfo.split(' : ');
        let category = product[0];

        if (!categories.hasOwnProperty(category)) {
            categories[category] = {};
        }

        categories[category][product] = price;
    }
    let result = '';
    let sortedcategories = Object.entries(categories).sort((a, b) => a[0].localeCompare(b[0]));
    for (const category of sortedcategories) {
        
        result += category[0] + '\n';
        let sortedNames = Object.entries(category[1]).sort((a, b) => a[0].localeCompare(b[0]))
        for (const nameAndPrice of sortedNames) {
            result += ` ${nameAndPrice[0]}: ${nameAndPrice[1]}\n`
        }
    }
    console.log(result);
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);

solve(['Banana : 2',
'Rubic\'s Cube : 5',
'Raspberry P : 4999',
'Rolex : 100000',
'Rollon : 10',
'Rali Car : 2000000',
'Pesho : 0.000001',
'Barrel : 10']
);