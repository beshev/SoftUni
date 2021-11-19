import { showNavBar } from './app.js';
import { viewDashboard } from './dashboard.js';

let main = undefined;
let section = undefined;


function setCreate(tagName, targetSection) {
    main = tagName;
    section = targetSection;

    let form = section.querySelector('form');
    form.addEventListener('submit', onSubmit);
}

async function onSubmit(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);

    let title = formData.get('title').trim();
    let description = formData.get('description').trim();
    let img = formData.get('imageURL').trim();

    if (title.length < 6) {
        alert('The title should be at least 6 characters long.');
        return;
    }

    if (description.length < 10) {
        alert('The description should be at least 10 characters long.');
        return;
    }

    if (img.length < 5) {
        alert('The image should be at least 5 characters long');
        return;
    }

    let body = JSON.stringify({
        title,
        description,
        img,
    });

    await fetch('http://localhost:3030/data/ideas', {
        method: 'post',
        headers: {
            'Content-type': 'application/json',
            'X-Authorization': localStorage.getItem('token'),
        },
        body
    });

    e.target.reset();
    viewDashboard();
}

export async function viewCreate() {
    main.innerHTML = '';
    main.appendChild(section);
    showNavBar();
}

export default {
    setCreate,
    viewCreate,
}