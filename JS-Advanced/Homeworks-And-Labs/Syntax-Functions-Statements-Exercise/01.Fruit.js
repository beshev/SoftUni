function main(fruit, weight, money){
    let kilograms= weight / 1000;

    console.log(`I need $${(kilograms * money).toFixed(2)} to buy ${kilograms.toFixed(2)} kilograms ${fruit}.`);
}

main('apple', 1563, 2.35);