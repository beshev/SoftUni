function main(params) {
    var playersMarks = { true: 'X', false: 'O'};
    let playerOnMove = false;

    for (let i = 0; i < 10; i++) {
        console.log(playersMarks[playerOnMove]);

        playerOnMove = !playerOnMove;
    }

}


main();