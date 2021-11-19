const token = sessionStorage.getItem('auth_token');
isAuthenticated(token !== null);

let baseUrl = 'http://localhost:3030/data/catches/';

let catchDiv = document.getElementById('catches');
let loadButton = document.querySelector('button.load');

loadButton.addEventListener('click', onLoadHandler)

let logout = document.getElementById('logout');
logout.addEventListener('click', onLogoutHandler);

let form = document.getElementById('addForm');
form.addEventListener('submit', onSubmitHandler);


function onSubmitHandler(e) {
    e.preventDefault();
    let formData = new FormData(form);

    let angler = formData.get('angler');
    let weight = formData.get('weight');
    let species = formData.get('species');
    let location = formData.get('location');
    let bait = formData.get('bait');
    let captureTime = formData.get('captureTime');


    if (angler.trim() === ''
        || weight.trim() === ''
        || isNaN(weight)
        || species.trim() === ''
        || location.trim() === ''
        || bait.trim() === ''
        || captureTime.trim() === ''
        || !Number.isInteger(Number(captureTime))) {
        return;
    }

    let body = JSON.stringify({
        _ownerId: sessionStorage.getItem('userId'),
        angler,
        weight,
        species,
        location,
        bait,
        captureTime
    });

    fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': token
        },
        body
    })
        .then(() => form.reset())
        .catch((err) => alert(err.message));
}

async function onLoadHandler() {
    let catches = await fetch(baseUrl).then(res => res.json());
    Array.from(catchDiv.children).map(x => x.remove());

    catches.forEach(obj => {
        loadCatch(obj.angler, obj.weight, obj.species, obj.location, obj.bait, obj.captureTime, obj._ownerId, obj._id);
    });
}

function loadCatch(angler, weight, species, location, bait, captureTime, ownerId, catchId) {
    let isDisabled = sessionStorage.getItem('userId') === ownerId ? false : true;

    let updateButton = e('button', { class: 'update', 'data-id': catchId }, 'Update');
    updateButton.addEventListener('click', onUpdateHandler);

    let deleteButton = e('button', { class: 'delete', 'data-id': catchId }, 'Delete');
    deleteButton.addEventListener('click', onDeleteHandler);

    updateButton.disabled = isDisabled;
    deleteButton.disabled = isDisabled;

    let div = e('div', { class: 'catch' },
        e('label', {}, 'Angler'),
        e('input', { type: "text", class: "angler", value: angler, disabled: isDisabled }, 'Angler'),
        e('label', {}, 'Weight'),
        e('input', { type: "text", class: "weight", value: weight, disabled: isDisabled }, 'Weight'),
        e('label', {}, 'Species'),
        e('input', { type: "text", class: "species", value: species, disabled: isDisabled }, 'Species'),
        e('label', {}, 'Location'),
        e('input', { type: "text", class: "location", value: location, disabled: isDisabled }, 'Location'),
        e('label', {}, 'Bait'),
        e('input', { type: "text", class: "bait", value: bait, disabled: isDisabled }, 'Bait'),
        e('label', {}, 'Capture Time'),
        e('input', { type: "number", class: "captureTime", value: captureTime, disabled: isDisabled }, 'Capture Time'),
        updateButton,
        deleteButton,
    )

    catchDiv.appendChild(div);
}

function onUpdateHandler(e) {
    let dataId = e.target.getAttribute('data-id');
    let fields = e.target.parentElement.querySelectorAll('input');

    let angler = fields[0].value;
    let weight = fields[1].value;
    let species = fields[2].value;
    let location = fields[3].value;
    let bait = fields[4].value;
    let captureTime = fields[5].value;

    
    if (angler.trim() === ''
        || weight.trim() === ''
        || isNaN(weight)
        || species.trim() === ''
        || location.trim() === ''
        || bait.trim() === ''
        || captureTime.trim() === ''
        || !Number.isInteger(Number(captureTime))) {
        return;
    }

    let body = JSON.stringify({
        angler,
        weight,
        species,
        location,
        bait,
        captureTime
    })

    fetch(baseUrl + dataId, {
        method: 'PUT',
        headers: { 'X-Authorization': token },
        body
    });
}

function onDeleteHandler(e) {
    let dataId = e.target.getAttribute('data-id');

    fetch(baseUrl + dataId, {
        method: 'DELETE',
        headers: { 'X-Authorization': token }
    })
        .then(() => e.target.parentElement.remove());
}

function isAuthenticated(isAuth) {
    let userDiv = document.getElementById('user');
    let guestDiv = document.getElementById('guest');
    let addButton = document.querySelector('button.add');
    let spanGuest = document.getElementById('guestSpan');

    if (isAuth) {
        userDiv.style.display = 'inline';
        guestDiv.style.display = 'none';
        addButton.disabled = false;
        spanGuest.textContent = sessionStorage.getItem('userEmail');

    } else {
        userDiv.style.display = 'none';
        guestDiv.style.display = 'inline';
        addButton.disabled = true;
        spanGuest.textContent = 'guest';
    }
}

async function onLogoutHandler() {
    try {
        let response = await fetch('http://localhost:3030/users/logout', {
            method: 'GET',
            headers: { 'X-Authorization': token }
        });

        if (response.status !== 204) {
            throw new Error('User session does not exist');
        }

        sessionStorage.removeItem('auth_token');
        sessionStorage.removeItem('userId');
        sessionStorage.removeItem('userEmail');
    } catch (error) {
        alert(error.message);
    }

    window.location.pathname = '05.Fisher-Game/src/index.html';
}

function e(type, attr, ...content) {
    const element = document.createElement(type);

    for (const prop in attr) {
        if (prop === 'class') {
            element.classList.add(attr[prop])
        } else if (prop === 'disabled') {
            element.disabled = attr[prop];
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