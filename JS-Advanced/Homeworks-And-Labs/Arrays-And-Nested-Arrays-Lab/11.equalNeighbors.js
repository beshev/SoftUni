function main(matrix) {
    let counter = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
           if (isSave(matrix, row, col + 1) && matrix[row][col] === matrix[row][col + 1]) {
               counter++;
           }
           if (isSave(matrix,row + 1, col) && matrix[row][col] === matrix[row + 1][col]) {
               counter++;
           }
        }
    }

    
    function isSave(matrix, row, col) {
        let isSave = true;

        if (row < 0 || row >= matrix.length) {
            isSave = false;
        }

        if ( isSave && col < 0 || col >= matrix[row]) {
            isSave = false;
        }
        return isSave;
    }
    return counter;
}

console.log(main([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '4']]
));

console.log(main([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
));