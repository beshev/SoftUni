function solve() {
    let allSections = document.querySelectorAll('section');
    let button  = document.getElementById('add');

    button.addEventListener('click', onAdd)

    function onAdd(event) {
        event.preventDefault();

        let taskInput = document.getElementById('task');
        let descInput = document.getElementById('description');
        let dateInput = document.getElementById('date');
    
        if (taskInput.value.trim() == '' || descInput.value.trim() == '' || dateInput.value.trim() == '') {
            return;
        }
        let startButton = e('button',{class: 'green'},'Start');
        startButton.addEventListener('click', onStart);

        let deleteButton = e('button',{class: 'red'},'Delete');
        deleteButton.addEventListener('click', (e) => {
            e.target.parentElement.parentElement.remove();
        })

        let article = e('article',{},
            e('h3',{},taskInput.value),
            e('p',{},`Description: ${descInput.value}`),
            e('p',{},`Due Date: ${dateInput.value}`),
            e('div',{class: 'flex'},
                startButton,
                deleteButton
            )
        )
        
        allSections[1].querySelectorAll('div')[1].appendChild(article);
    }

    function onStart(event) {
        let parent = event.target.parentElement;
        parent.innerHTML = '';
        let deleteButton = e('button',{class: 'red'},'Delete');
        deleteButton.addEventListener('click',() => {
            parent.parentElement.remove();
        })

        let finishButton = e('button',{class: 'orange'},'Finish');
        finishButton.addEventListener('click', onFinish)

        parent.appendChild(deleteButton);
        parent.appendChild(finishButton);

        allSections[2].querySelector('#in-progress').appendChild(parent.parentElement);
    }

    function onFinish(e) {
        let article = e.target.parentElement.parentElement;
        e.target.parentElement.remove();

        allSections[3].querySelectorAll('div')[1].appendChild(article);
    }

    function e(type, attr, ...content) {
        const element = document.createElement(type);
    
        for (const prop in attr) {
            if (prop == 'class') {
                element.classList.add(attr[prop]);
            } else {
                element[prop] = attr[prop];
            }
        }
    
        for (let item of content) {
            if (typeof item == 'string' || typeof item == 'number') {
                item = document.createTextNode(item);
            }
    
            element.appendChild(item);
        }
    
        return element;
    }
}