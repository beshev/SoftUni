import { loadHomePage } from './app.js'

let main;
let section;
let baseUrl = 'http://localhost:3030/data/movies/';

function setCreate(tagName, targetSection) {
    main = tagName;
    section = targetSection;

    const form = section.querySelector('form');
    form.addEventListener('submit', onSubmit);
}

function showCreate() {
    main.innerHTML = '';
    main.appendChild(section);
}

async function onSubmit(e) {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let title = formData.get('title');
    let description = formData.get('description');
    let img = formData.get('imageUrl');

    if (title.trim() === '' || description.trim() === '' || img.trim() === '') {
        alert('All fields are required!!');
        return;
    }

    try {
        let response = await fetch(baseUrl, {
            method: "POST",
            headers: {
                'Content-Type': 'application.json',
                'X-Authorization': sessionStorage.getItem('token'),
            },
            body: JSON.stringify({
                title,
                description,
                img,
                _ownerId: sessionStorage.getItem('userId')
            })
        });

        if (!response.ok) {
            throw Error('The server does not respond, please, try again later');
        }

        if (response.status == 401) {
            throw Error('Unauthorized! You must be login to do that action!');
        }

        e.target.reset();
        loadHomePage();
    } catch (error) {
        alert(error.message);
    }
}

export default {
    setCreate,
    showCreate,
}