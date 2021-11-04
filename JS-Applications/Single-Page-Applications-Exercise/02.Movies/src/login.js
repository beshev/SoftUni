import { loadHomePage } from './app.js';

let main;
let section;

function setLogin(tagName, targetSection) {
    main = tagName;
    section = targetSection;

    const form = targetSection.querySelector('form');
    form.addEventListener('submit', onSubmit);
}

async function onSubmit(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);

    let email = formData.get('email');
    let password = formData.get('password');

    if (email.trim() == '' || password.trim() == '') {
        alert('All fields are required!');
        return;
    }

    try {
        let response = await fetch('http://localhost:3030/users/login',{
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({
                email,
                password,
            })
        });

        let data = await response.json();

        if (data.code) {
            throw Error();
        }

        sessionStorage.setItem('token', data.accessToken);
        sessionStorage.setItem('userId', data._id);
        sessionStorage.setItem('email', data.email);

    } catch (error) {
        alert('Invalid Email or password!');
        return;
    }

    loadHomePage();
}

function showLogin() {
    main.innerHTML = '';
    main.appendChild(section);
}

function logout() {
    fetch('http://localhost:3030/users/logout',{
        method: 'GET',
        headers:{'X-Authorization': sessionStorage.getItem('token')}
    });

    sessionStorage.removeItem('token');
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('userId');

    loadHomePage();
}

export default {
    setLogin,
    showLogin,
    logout,
}