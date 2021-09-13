function main(rows, cols) {
    let matrix = new Array(rows).fill(0).map(() => new Array(cols).fill(0));
    let startNumber = 1;
    let row = 0;
    let col = 0;
    let direction = 'right';
    let filledCount = 0;
    while(filledCount < rows * cols) {
        if (direction == 'right') {
            while (isSave(matrix,row,col) && matrix[row][col] == 0) {
                matrix[row][col] = startNumber++;
                col++;
                filledCount++;
            }
            col--;
            row++;
            direction = 'down';
        }

        if (direction == 'down') {
            while (isSave(matrix,row,col) && matrix[row][col] == 0) {
                matrix[row][col] = startNumber++;
                row++;
                filledCount++;
            }
            row--;
            col--;
            direction = 'left';
        }

        if (direction == 'left') {
            while (isSave(matrix,row,col) && matrix[row][col] == 0) {
                matrix[row][col] = startNumber++;
                col--;
                filledCount++;
            }
            col++;
            row--;
            direction = 'up';
        }

        if (direction == 'up') {
            while (isSave(matrix,row,col) && matrix[row][col] == 0) {
                matrix[row][col] = startNumber++;
                row--;
                filledCount++;
            }
            row++;
            col++;
            direction = 'right';
        }
   }



    printField(matrix);
    function printField(field) {
        for (let row = 0; row < field.length; row++) {
            console.log(field[row].join(' '));
        }
    }

    function isSave(matrix,row,col) {
        if (row < 0 || row >= matrix.length) {
            return false;
        }

        if (col < 0 || col >= matrix[row].length) {
            return false;
        }

        return true;
    }
}

main(4, 4);