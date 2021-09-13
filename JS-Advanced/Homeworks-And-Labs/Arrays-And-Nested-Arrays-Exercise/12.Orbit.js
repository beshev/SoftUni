function main(input) {
    let [width, height, row, col] = input;

    let matrix = [];

    for(var i=0; i < height; i++) {
        matrix[i] = new Array(width).fill(0);
    }

    matrix[row][col] = 1;
    let filledCells = 1;
    let startPoint = 1;
    while (filledCells < width * height) {
        filledCells += fillMatrix(matrix,row - startPoint, row + startPoint, col - startPoint, col + startPoint, 1 + startPoint);
        startPoint++;
    }
    
    printField(matrix);

    function printField(field) {
        for (let row = 0; row < field.length; row++) {
            console.log(field[row].join(' '));
        }
    }


    function fillMatrix(matrix, startRow, endRow, startCol, endCol, number) {
        let filledCells = 0;
        for (let row = startRow; row <= endRow; row++) {

            for (let col = startCol; col <= endCol; col++) {
                
                if (isSave(matrix,row,col) && matrix[row][col] == 0) {
                    matrix[row][col] = number;
                    filledCells++;
                }
            }
           
        }

        return filledCells;

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
}

main([10, 10, 3, 0]);