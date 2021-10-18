function solve() {
    let addButtonElement = document.querySelector('#container button');
    let adoptionUlElement = document.querySelector('#adoption ul');
    let adoptedUlElement = document.querySelector('#adopted ul');

    addButtonElement.addEventListener('click', OnAddClick)

    function OnAddClick(e) {
        e.preventDefault();

        let nameInputElement = document.querySelector('#container input[placeholder="Name"]');
        let ageInputElement = document.querySelector('#container input[placeholder="Age"]');
        let kindInputElement = document.querySelector('#container input[placeholder="Kind"]');
        let ownerInputElement = document.querySelector('#container input[placeholder="Current Owner"]');

        let name = nameInputElement.value;
        let age = ageInputElement.value;
        let kind = kindInputElement.value;
        let owner = ownerInputElement.value;

        if (name.trim() === '' || (age.trim() === '' || isNaN(age)) || kind.trim() === '' || owner.trim() === '') {
            return;
        }

        nameInputElement.value = '';
        ageInputElement.value = '';
        kindInputElement.value = '';
        ownerInputElement.value = '';

        let p = document.createElement('p');
        p.innerHTML = `<strong>${name}</strong> is a <strong>${age}</strong> year old <strong>${kind}</strong>`;

        let span = document.createElement('span');
        span.textContent = `Owner: ${owner}`;

        let button = document.createElement('button');
        button.textContent = 'Contact with owner';
        button.addEventListener('click', onContactClick)

        let li = document.createElement('li');
        li.appendChild(p);
        li.appendChild(span);
        li.appendChild(button);

        adoptionUlElement.appendChild(li);
    }


    function onContactClick(e) {
        let parent = e.target.parentElement;
        e.target.remove();
        
        let div = document.createElement('div');
        let input = document.createElement('input');
        let button = document.createElement('button');
        
        input.setAttribute('placeholder','Enter your names');
        button.textContent = 'Yes! I take it!';

        button.addEventListener('click', (e) => {
            let name = input.value;
            
            if (name.trim() === '') {
                return;
            }
            
            e.target.parentElement.remove();
            let ownerSpan = parent.querySelector('span');
            ownerSpan.textContent = `New Owner: ${name}`;

            let checkButton = document.createElement('button');
            checkButton.textContent = 'Checked';
            checkButton.addEventListener('click', () => {
                checkButton.parentElement.remove();
            })

            parent.appendChild(checkButton);
            adoptedUlElement.appendChild(parent);

        });

        div.appendChild(input);
        div.appendChild(button);
        parent.appendChild(div);
    }
}

