import { viewRegister } from './register.js';
import { viewHome } from './home.js';

let main = undefined;
let section = undefined;


function setLogin(tagName, targetSection) {
    main = tagName;
    section = targetSection;

    targetSection.querySelector('a[data-singUp="singUp"]').addEventListener('click', e => {
        e.preventDefault();
        viewRegister();
    })

    let form = targetSection.querySelector('form');
    form.addEventListener('submit', onSubmit)
}

async function onSubmit(e) {
    e.preventDefault();
    let formData = new FormData(e.target);

    let email = formData.get('email');
    let password = formData.get('password');

    let body = JSON.stringify({
        email,
        password,
    });

    try {
        let response = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body
        });

        if (response.ok == false) {
            throw new Error('Server error please try again later');
        }

        let data = await response.json();

        localStorage.setItem('token', data.accessToken);
        localStorage.setItem('userId', data._id);
        e.target.reset();
        viewHome();

    } catch (err) {
        alert(err.message);
    }
}

export function viewLogin() {
    main.innerHTML = '';
    main.appendChild(section);
}

export default {
    setLogin,
    viewLogin,
}