function main(matrix) {
    
    for (let rowColumn = 0; rowColumn < matrix.length; rowColumn++) {
        let rowsSum = 0;

        for (let row = 0; row < matrix.length; row++) {
            
            rowsSum += matrix[row][rowColumn];
        }
        
        for (let row = 0; row < matrix.length; row++) {
            let colsSum = 0;

            for (let col = 0; col < matrix[row].length; col++) {
                colsSum += matrix[row][col];
            }

            if (colsSum != rowsSum) {
                return false;
            }
        }
        
    }

    return true;
}

console.log(main([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   ));

   console.log((main([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
   )));

   console.log((main([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
   )));