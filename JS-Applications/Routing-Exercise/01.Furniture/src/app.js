import page from '../node_modules/page/page.mjs'
import api from './api/api.js';

import { createNav } from './navigator.js'
import { setupCreate, onCreate } from './views/create.js';
import { setupDetails,deleteF } from './views/details.js';
import { setupEdit, onEdit } from './views/edit.js';
import { setupHome } from './views/home.js';
import { onLogin, setupLogin } from './views/login.js';
import { setupMyFurnitures } from './views/myFurnitures.js';
import { setupRegister, onRegister } from './views/register.js';


const main = document.getElementById('main');
const navBar = document.getElementById('navbar');
const navigator = createNav(main, navBar);

console.log(main);

const views = {
    loginView: navigator.registerView('login', setupLogin, 'loginLink'),
    registerView: navigator.registerView('register', setupRegister, 'registerLink'),
    homeView: navigator.registerView('home', setupHome, 'catalogLink'),
    createView: navigator.registerView('create', setupCreate, 'createLink'),
    detailsView: navigator.registerView('details', setupDetails),
    editView: navigator.registerView('edit', setupEdit),
    myFuView: navigator.registerView('myFurnitures',setupMyFurnitures,'profileLink'),
}

page('/', views.homeView);
page('/my-furniture', views.myFuView);
page('/logout', logout);
page('/delete/:id', deleteF);
page('/details/:id', views.detailsView);

page('/login', views.loginView);
navigator.registerForm('loginForm', onLogin, () => { page.redirect('/'); navigator.setUserNav() });

page('/register', views.registerView);
navigator.registerForm('registerForm', onRegister, () => { page.redirect('/'); navigator.setUserNav() });

page('/create', views.createView);
navigator.registerForm('createForm', onCreate, () => { page.redirect('/') });

page('/edit/:id', views.editView);
navigator.registerForm('editForm', onEdit, (id) => { page.redirect(`/details/${id}`) });

page.start();

async function logout() {
    await api.logout();
    page.redirect('/login');
    navigator.setUserNav();
}
