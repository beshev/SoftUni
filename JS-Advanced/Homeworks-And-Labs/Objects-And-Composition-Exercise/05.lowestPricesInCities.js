function solve(input) {
    let products = {};

    for (const inputInfo of input) {
        let [town,product,price] = inputInfo.split(' | ');
        price = Number(price);

        if (!products.hasOwnProperty(product)) {
            products[product] = {};
        }

        products[product][town] = price;
    }
    
    for (const product in products) {
        let townsSorted = Object.entries(products[product]).sort((a, b) => a[1] - b[1]);
        console.log(`${product} -> ${townsSorted[0][0]} (${townsSorted[0][1]})`);
    }
}


solve(['Sofia City | Audi | 100000', 'Mexico City | Audi | 1000', 'Mexico City | Audi | 100000']
);

solve(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
);