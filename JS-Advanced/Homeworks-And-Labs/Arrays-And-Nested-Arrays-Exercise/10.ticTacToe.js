function main(params) {
    let field = [[false, false, false],[false, false, false],[false, false, false]];
    var marks = { true: 'X', false: 'O'};
    let playerOnMove = true;
    let finalStat = 'The game ended! Nobody wins :(';
    let freeSpaces = 9;
   
    for (const move of params) {
        let playerMove = move.split(' ');
        let row = Number(playerMove[0]);
        let col = Number(playerMove[1]);
        let mark = marks[playerOnMove];

        if (freeSpaces <= 0) {
            break;
        }

        if (field[row][col] !== false) {
            console.log('This place is already taken. Please choose another!');
            continue;
        } else {
            field[row][col] = mark
            if (isWinning(field,mark)) {
                finalStat = `Player ${mark} wins!`;
                break;
            }

            freeSpaces--; 
            playerOnMove = !playerOnMove;
        }
    }
    console.log(finalStat);
    printField(field);

    function printField(field) {
        for (let row = 0; row < field.length; row++) {
            console.log(field[row].join('\t'));
        }
    }

    function isWinning(field,mark) {
            let sequential = 0;

            // Cheking cols
            for (let row = 0; row < field.length; row++) {

                for (let col = 0; col < field[row].length; col++) {
                    if (field[row][col] == mark) {
                        sequential++;
                    }
                }
                if (sequential >= 3) {
                    return true;
                }
                sequential = 0;
            }

            // Cheking rows
            for (let col = 0; col < field.length; col++) {

                for (let row = 0; row < field[col].length; row++) {
                    if (field[row][col] == mark) {
                        sequential++;
                    }
                }
                
                if (sequential >= 3) {
                    return true;
                }
                sequential = 0;
            }

            // Cheking right diagonal
            for (let i = 0; i < field.length; i++) {

                if (field[i][i] == mark) {
                     sequential++;
                }
            }
            
            if (sequential >= 3) {
                return true;
            }
            sequential = 0;

            // Cheking left diagonal
            for (let i = 0; i < field.length; i++) {

                if (field[i][field.length - 1 - i] == mark) {
                    sequential++;
                }
            }

            if (sequential >= 3) {
                return true;
            }

            return false;
    }

}

main(["0 1",
"0 0",
"0 2", 
"2 0",
"1 0",
"1 1",
"1 2",
"2 2",
"2 1",
"0 0"]);

main(["0 0",
"0 0",
"1 1",
"0 1",
"1 2",
"0 2",
"2 2",
"1 2",
"2 2",
"2 1"]
);

main(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]
);