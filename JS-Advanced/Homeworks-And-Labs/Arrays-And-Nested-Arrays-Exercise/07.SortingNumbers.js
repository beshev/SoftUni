function main(array) {
    let result = []
    array.sort((a, b) => a - b);

    for (let i = 0; i < array.length / 2; i++) {
        result.push(array[i]);
        result.push(array[array.length - 1 - i]);
    }
    result.length -= array.length % 2 == 0 ? 0 : 1;
    return result;
}

console.log(main([1, 65, 3, 52, 48, 63, 31, -3, 18, 48]));
console.log(main([1, 65, 3, 52, 48, 63, 31, -3, 18]));