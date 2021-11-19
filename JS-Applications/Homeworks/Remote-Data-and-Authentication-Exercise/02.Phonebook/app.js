function attachEvents() {
    let baseUrl = 'http://localhost:3030/jsonstore/phonebook';
    let loadButton = document.getElementById('btnLoad');
    loadButton.addEventListener('click', onLoadHandler.bind(null, baseUrl));

    let createButton = document.getElementById('btnCreate');
    createButton.addEventListener('click', onCreateHandler.bind(null, baseUrl, loadButton))
}

function onCreateHandler(url, loadButton) {
    let personInput = document.getElementById('person');
    let phoneInput = document.getElementById('phone');

    if (personInput.value.trim() === '' || phoneInput.value.trim() === '') {
        return;
    }

    let body = JSON.stringify({
        person: personInput.value,
        phone: phoneInput.value,
    })

    fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application.json' },
        body
    })
        .then(() => loadButton.click())


    personInput.value = '';
    phoneInput.value = '';
}

async function onLoadHandler(baseUrl) {
    let phonebook = await fetch(baseUrl).then(res => res.json());
    let ul = document.getElementById('phonebook');
    Array.from(ul.children).map(x => x.remove());

    Object.values(phonebook).forEach(value => {
        let li = document.createElement('li');
        li.textContent = `${value.person}: ${value.phone}`;

        let deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', onDeleteHandler.bind(null, `${baseUrl}/${value._id}`))
        li.appendChild(deleteButton);

        ul.appendChild(li);
    })
}

function onDeleteHandler(url, e) {
    fetch(url, {
        method: 'DELETE'
    });

    e.target.parentElement.remove();
}

attachEvents();