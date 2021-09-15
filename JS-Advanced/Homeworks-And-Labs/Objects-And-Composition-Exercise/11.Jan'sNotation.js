function solve(input) {
    let operands = [];

    for (const value of input) {
        if (!isNaN(value)) {
            operands.push(value);
        } else{
            let secondNum = operands.pop();
            let firstNum = operands.pop();

            if (firstNum == undefined || secondNum == undefined) {
                return 'Error: not enough operands!'
            }

            let operations = {
                '+': (a,b) => a + b,
                '-': (a,b) => a - b,
                '*': (a,b) => a * b,
                '/': (a,b) => a / b,
            }

            operands.push(operations[value](firstNum,secondNum));
        }
    }
    if (operands.length > 1) {
        return 'Error: too many operands!';
    }

    return operands[0];
}

console.log(solve([3,
    4,
    '+']
   ));

console.log(solve([5,
 3,
 4,
 '*',
 '-']
   ));

console.log(solve([7,
    33,
    8,
    '-']
   ));

console.log(solve([15,
 '/']
   ));