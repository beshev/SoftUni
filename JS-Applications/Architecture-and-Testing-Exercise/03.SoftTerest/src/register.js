import { viewLogin } from './login.js';
import { viewHome } from './home.js';

let main = undefined;
let section = undefined;


function setRegister(tagName, targetSection) {
    main = tagName;
    section = targetSection;

    targetSection.querySelector('a[data-singIn="singIn"]').addEventListener('click', e => {
        e.preventDefault();
        viewLogin();
    })

    let form = targetSection.querySelector('form');
    form.addEventListener('submit', onSubmit)
}

async function onSubmit(e) {
    e.preventDefault();
    let formData = new FormData(e.target);

    let email = formData.get('email');
    let password = formData.get('password');
    let rePass = formData.get('repeatPassword');

    if (email.length < 3) {
        alert('The email should be at least 3 characters long, have digits and special characters');
        return;
    }

    if (password.length < 3) {
        alert('The password should be at least 3 characters long');
        return;
    }

    if (password !== rePass) {
        alert('The repeat password should be equal to the password');
        return;
    }


    let body = JSON.stringify({
        email,
        password,
        rePass,
    });

    try {
        let response = await fetch('http://localhost:3030/users/register', {
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

export function viewRegister() {
    main.innerHTML = '';
    main.appendChild(section);
}

export default {
    setRegister,
    viewRegister,
}