function main(array,rotations) {
    for (let i = 0; i < rotations; i++) {
        array.unshift(array.pop());
    }

    return array.join(' ');
}

console.log(main(['1', 
'2', 
'3', 
'4'], 
2
));
console.log(main(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15
));