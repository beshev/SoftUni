function solve(numbers, sortType) {
    if (sortType == 'asc') {
        return numbers.sort((a, b) => a - b);
    } else {
        return numbers.sort((a, b) => b - a);
    }
}


console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));