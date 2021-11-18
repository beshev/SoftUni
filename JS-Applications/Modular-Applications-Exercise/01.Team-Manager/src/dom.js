import { render, html } from '../node_modules/lit-html/lit-html.js'

function setUserData(userData) {
    sessionStorage.setItem('token',userData.accessToken);
    sessionStorage.setItem('email',userData.email);
    sessionStorage.setItem('username',userData.username);
    sessionStorage.setItem('userId',userData._id);
}

function removeUserData() {
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('username');
    sessionStorage.removeItem('userId');
}

function getElementById(id) {
    return document.getElementById(id);
}

export {
    render,
    html,
    setUserData,
    removeUserData,
    getElementById,
}


