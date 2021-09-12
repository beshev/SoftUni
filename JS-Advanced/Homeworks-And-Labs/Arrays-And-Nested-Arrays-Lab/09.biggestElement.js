function main(matrix) {
    let maxNumber = matrix[0][0];
    for (let row = 0; row < matrix.length; row++) {
       for (let col = 0; col < matrix[row].length; col++) {
           if (matrix[row][col] > maxNumber) {
               maxNumber = matrix[row][col];
           }
       }
    }

    return maxNumber;
}