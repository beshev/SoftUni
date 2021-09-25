function add(number) {
    let sum = 0;

    function inner (x) {
        sum += x;
        return inner;
    }

    inner.toString = () => sum; 
    return inner(number);
}

console.log(add(1)(5)(10).toString());