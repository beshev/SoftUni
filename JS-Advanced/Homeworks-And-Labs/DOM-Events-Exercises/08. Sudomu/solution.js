function solve() {
    let tableElement = document.querySelector('#exercise table');
    let tableRowsElements = Array.from(tableElement.querySelectorAll('tbody tr'));
    let footerButtonsElements = tableElement.querySelectorAll('tfoot tr td button');
    let checkElement = document.querySelector('#check p');
    
    let checkButton = footerButtonsElements[0];
    let clearButton = footerButtonsElements[1];
    
    checkButton.addEventListener('click', () => {
        let field = [];
        let initialFieldSize = 0;

        tableRowsElements.forEach(row => {
            let cells = Array.from(row.querySelectorAll('td input')).map(x => Number(x.value));
            field.push(cells);
            initialFieldSize += cells.length;
        });

        for (let row = 0; row < field.length; row++) {
            let currentColSize = new Set(field[row]).size;
            if (currentColSize < field[row].length) {
                notDoneState();
                return;
            }
        }

        for (let col = 0; col < field.length; col++) {
            let currentRowSize = new Set();

            for (let row = 0; row < field[col].length; row++) {
                currentRowSize.add(field[row][col]);
            }

            if (currentRowSize.size < field.length) {
                notDoneState();
                return;
            }
        }
        doneState();


        function notDoneState() {
            checkElement.textContent = 'NOP! You are not done yet...';
            checkElement.style.color = 'red';
            tableElement.style.border = '2px solid red';
        }

        function doneState() {
            checkElement.textContent = 'You solve it! Congratulations!';
            checkElement.style.color = 'green';
            tableElement.style.border = '2px solid green';
        }
    })

    clearButton.addEventListener('click', () => {
        checkElement.textContent = '';
        checkElement.style.color = 'none';
        tableElement.style.border = '';

        Array.from(document.querySelectorAll('#exercise table tr td input')).forEach(e => {
            e.value = '';
        });
    })
}