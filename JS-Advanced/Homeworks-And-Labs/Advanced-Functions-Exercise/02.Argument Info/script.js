function solve(...input) {
    let typeValue = [];
    let typesCount = {};

    input.forEach(el => {
        let type = typeof el;
        if (!typesCount.hasOwnProperty(type)) {
            typesCount[type] = 0;
        }
        typesCount[type]++;

        let typeValueAsString = type === 'object' ? `${type}:` : `${type}: ${el}`;
        typeValue.push(typeValueAsString);
    });

    typeValue.forEach(el => {
        console.log(el);
    });

    let sortedTypes = Object.keys(typesCount).sort((a, b) => typesCount[b] - typesCount[a]);
    sortedTypes.forEach(key => {
        console.log(`${key} = ${typesCount[key]}`);
    });
}


// solve('cat', 42, function () { console.log('Hello world!'); });
solve({ name: 'bob'}, 3.333, 9.999);
