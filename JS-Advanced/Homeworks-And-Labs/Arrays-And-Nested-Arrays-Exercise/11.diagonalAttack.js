function main(input) {
    let leftDiagonalSum = 0;
    let rightDiagonalSum = 0;
    let matrix = [];

    for (let i = 0; i < input.length; i++) {
        matrix[i] = (input[i].split(' ').map(x => Number(x)))
    }

    for (let i = 0; i < matrix.length; i++) {
        rightDiagonalSum += matrix[i][i];
        leftDiagonalSum += matrix[i][matrix.length - 1 - i];
    }

    if (rightDiagonalSum == leftDiagonalSum) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                
                if (row != col && col != matrix.length - 1 - row) {
                    matrix[row][col] = rightDiagonalSum;
                }
                
            }
            
        }
    }

    printField(matrix);

    function printField(field) {
        for (let row = 0; row < field.length; row++) {
            console.log(field[row].join(' '));
        }
    }
}

main(['5 3 12 3 1',
      '11 4 23 2 5',
      '101 12 3 21 10',
      '1 4 5 2 2',
      '5 22 33 11 1']
);

main(['1 1 1',
'1 1 1',
'1 1 0']
);