function solve() {
    const onScreenButton = document.querySelector('#container button');
    onScreenButton.addEventListener('click', onScreenHandler);

    const archiveButtonElement = document.querySelector('#archive button')
    archiveButtonElement.addEventListener('click', (e) => {
        e.currentTarget.parentElement.querySelector('ul').innerHTML = '';
    });


    function onScreenHandler(e) {
        e.preventDefault();
        let inputNameElement = document.querySelector('#container input[placeholder="Name"]');
        let inputHallElement =  document.querySelector('#container input[placeholder="Hall"]')
        let inputPriceElement = document.querySelector('#container input[placeholder="Ticket Price"]');

        let name = inputNameElement.value;
        let hall =inputHallElement.value;
        let price = Number(inputPriceElement.value);

        inputNameElement.value = '';
        inputHallElement.value = '';
        inputPriceElement.value = '';
       
        if (name == '' 
        || hall == '' 
        || isNaN(price)
        || price <= 0) {
            return;
        }

        let ul = document.querySelector('#movies ul');
        let li = document.createElement('li');
        let span = document.createElement('span');
        let strongHall = document.createElement('strong');

        span.textContent = name;
        strongHall.textContent = `Hall: ${hall}`;
        li.appendChild(span);
        li.appendChild(strongHall);
        
        let div = document.createElement('div');
        let strongPriceElement = document.createElement('strong');
        let inputElement = document.createElement('input');
        let archiveButtonElement = document.createElement('button');

        archiveButtonElement.addEventListener('click', onArchive);
        strongPriceElement.textContent = price.toFixed(2);
        inputElement.setAttribute('placeholder','Tickets Sold');
        archiveButtonElement.textContent = 'Archive';

        div.appendChild(strongPriceElement);
        div.appendChild(inputElement);
        div.appendChild(archiveButtonElement);
        li.appendChild(div);
        ul.appendChild(li);

        
        function onArchive(event) {
            let archiveUl = document.querySelector('#archive ul');
            let ticketsSold = event.target.parentElement.querySelector('input').value;

            if (isNaN(ticketsSold) || ticketsSold == '') {
                return;
            }

            let li = document.createElement('li');
            let span = document.createElement('span');
            let strong = document.createElement('strong');
            let deleteButton = document.createElement('button');

            span.textContent = name;
            strong.textContent = `Total amount: ${(ticketsSold * price).toFixed(2)}`;
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', onDelete);

            li.appendChild(span);
            li.appendChild(strong);
            li.appendChild(deleteButton);
            archiveUl.appendChild(li);
            event.target.parentElement.parentElement.remove();


            function onDelete(event) {
                event.target.parentElement.remove();
            }
        }
    }
}