import { loadHomePage } from './app.js';

let main;
let section;

function setRegister(tagName, targetSection) {
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
    let rePass = formData.get('repeatPassword');
    

    if (email.trim() == '' || password.trim() == '' || rePass.trim() == '') {
        alert('All fields are required!');
        return;
    }

    if (password !== rePass) {
        alert('Passwords don\'t match!');
        return;
    }

    if (password.length < 6) {
        alert('Passwords must be at least 6 symbols!');
        return;
    }

    try {
        let response = await fetch('http://localhost:3030/users/register',{
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({
                email,
                password,
            })
        });

        let data = await response.json();

        sessionStorage.setItem('token', data.accessToken);
        sessionStorage.setItem('userId', data._id);
        sessionStorage.setItem('email', data.email);

    } catch (error) {
        alert(error.message);
        return;
    }

    loadHomePage();
}

function showRegister() {
    main.innerHTML = '';
    main.appendChild(section);
}

export default {
    setRegister,
    showRegister,
}