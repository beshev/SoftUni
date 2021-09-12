function main(n,k) {
    n -= 1;
    let result = [1];

    for (let i = 0; i < n; i++) {
        let sum = lastKElementsSum(result,k);
        result.push(sum);
    }

    return result;

    function lastKElementsSum(array,k) {
        let sum = 0;
        let getLast = array.length - k;
        for (let i = getLast; i < array.length; i++) {
            if (i >= 0 && i < array.length) {
                sum += array[i];
            }
        }

        return sum;
    }
}

console.log(main(6, 3));
console.log(main(8, 2));