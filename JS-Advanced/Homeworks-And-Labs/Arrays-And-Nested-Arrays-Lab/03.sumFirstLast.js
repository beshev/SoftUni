function main(array) {
    return Number(array[0]) + Number(array[array.length - 1]);
}

console.log(main(['20', '30', '40']));