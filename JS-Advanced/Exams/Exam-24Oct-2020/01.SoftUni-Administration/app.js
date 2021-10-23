function solve() {
    let sections = document.querySelectorAll('body main.container section');
    let addButton = sections[1].querySelector('button');
    let modules = {};
    addButton.addEventListener('click', onAdd);

    function onAdd(ev) {
        ev.preventDefault();
        let trainings = sections[0].querySelector('div');
        let nameInput = sections[1].querySelector('form input[name="lecture-name"]');
        let dateInput = sections[1].querySelector('form input[name="lecture-date"]');
        let sectionInput = sections[1].querySelector('form select[name="lecture-module"]');

        let name = nameInput.value
        let date = dateInput.value
        let module = sectionInput.value

        if (name.trim() === '' || date.trim() === '' || module === 'Select module') {
            return;
        }

        let divModule = e('div', { class: 'module' },
            e('h3', {}, `${module.toUpperCase()}-MODULE`),
            e('ul', {}, ''),
        )

        if (!modules[module.toLowerCase()]) {
            modules[module.toLowerCase()] = divModule;
            trainings.appendChild(divModule);
        }

        date = date.split('-').join('/').split('T').join(' - ');

        let delButton = e('button', { class: 'red' }, 'Del');
        delButton.addEventListener('click', onDelete.bind(null, module.toLowerCase()))

        let li = e('li', { class: 'flex' },
            e('h4', {}, `${name} - ${date}`),
            delButton,
        )

        let ul = modules[module.toLowerCase()].querySelector('ul')
        ul.appendChild(li);

        Array.from(ul.children)
            .sort((a, b) => {
                let aDate = a.textContent.split(' - ')[1];
                let bDate = b.textContent.split(' - ')[1];

                return aDate.localeCompare(bDate);
            })
            .forEach(li => ul.appendChild(li));
    }

    function onDelete(module, e) {
        let ulParent = e.target.parentElement.parentElement;
        e.target.parentElement.remove();

        if (ulParent.children.length == 0) {
            delete modules[module];
            ulParent.parentElement.remove();
        }
    }

    function e(type, attr, ...content) {
        const element = document.createElement(type);

        for (const prop in attr) {
            if (prop === 'class') {
                element.classList.add(attr[prop])
            } else {
                element.setAttribute(prop, attr[prop]);
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
};