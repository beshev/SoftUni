function main(array) {
    array.sort(function(a, b){return a-b});

    return [array[0], array[1]];
}


console.log(main([30, 15, 50, 5]));
console.log(main([3, 0, 10, 4, 7, 3]));