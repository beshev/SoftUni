'use strict'

function solve(input) {
    let obj = {};
    for (let i = 0; i < input.length / 2; i++) {
        let key = input[i + i];
        let value = input[i + i +1];
        obj[key] = Number(value);
    }

    return obj;
}

console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));

console.log(solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));