function main(input,a,b,c,d,e) {
    let array = [a,b,c,d,e,];
    let number = Number(input);

    const operationsMap = {
        'chop': (x) => x / 2,
        'dice': (x) => Math.sqrt(x),
        'spice': (x) => x + 1,
        'bake': (x) => x * 3,
        'fillet': (x) => x - x * 0.2,
    }

    array.forEach(operation => {
        number = operationsMap[operation](number);
        console.log(number);
    });
    
}

main('9', 'dice', 'spice', 'chop', 'bake', 'fillet');