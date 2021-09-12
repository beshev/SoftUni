function main(array) {
    let result = [];
    for (let i = 0; i < array.length; i++) {
        
        if (i % 2 == 0) {
            result.push(array[i]);
        }
    }

    return result.join(' ');
}


console.log(main(['20', '30', '40', '50', '60']));