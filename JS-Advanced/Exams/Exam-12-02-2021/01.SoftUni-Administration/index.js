function solve() {
    let modulesElement = document.querySelector('.modules');
    let addButton = document.querySelector('div.form-control button');
    let lectureName = document.querySelector('div.form-control input[name="lecture-name"]');
    let lectureDate = document.querySelector('div.form-control input[name="lecture-date"]');
    let lectureModule = document.querySelector('div.form-control select[name="lecture-module"]');

    let modules = {};

    addButton.addEventListener('click', (e) => {
        e.preventDefault();
        let name = lectureName.value;
        let date = lectureDate.value;
        let module = lectureModule.value;
        console.log(lectureDate.value);

        if (module == 'Select module' || name.length <= 0 || date == '') {
            return;
        }

        if (!modules[module]) {
            let divModule = document.createElement(`div`);
            divModule.classList.add('module');
            let h3 = document.createElement('h3');
            h3.textContent = `${module.toUpperCase()}-MODULE`;
            divModule.appendChild(h3);
            divModule.appendChild(document.createElement('ul'));
            modules[module] = divModule;
        }

        let ul = modules[module].querySelector('ul');
        let li = document.createElement('li');
        li.classList.add('flex');

        let h4 = document.createElement('h4');
        h4.textContent = `${name} - ${date.split('-').join('/').split('T').join(' - ')}`;

        let deleteButton = document.createElement('Button');
        deleteButton.textContent = 'Del';
        deleteButton.classList.add('red');

        deleteButton.addEventListener('click', (e) => {
            let parent = e.target.parentElement.parentElement;

            e.target.parentElement.remove();
            if (parent.children.length == 0) {
                parent.parentElement.remove();
            }
        })

        li.appendChild(h4);
        li.appendChild(deleteButton);
        ul.appendChild(li);

        var elements = Array.from(ul.children);
                
        elements.sort((a, b) => {
            let firstDate = a.textContent.split(' - ')[1];
            let secondDate = b.textContent.split(' - ')[1];
            return firstDate.localeCompare(secondDate);
        });
        
        elements.forEach(el => {
            ul.appendChild(el);
        });
        
        modulesElement.appendChild(modules[module]);
    })
};