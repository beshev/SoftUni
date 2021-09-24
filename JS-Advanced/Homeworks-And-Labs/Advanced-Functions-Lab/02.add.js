function solution(firstNumber) {
    return function(secondNumber) {
        return firstNumber + secondNumber;
    }
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
