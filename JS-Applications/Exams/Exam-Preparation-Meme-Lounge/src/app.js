import { createNavigator } from "./navigator.js";
import page from '../node_modules/page/page.mjs'
import { onLogin, setupLogin } from "./views/loginView.js";
import { onRegister, setupRegister } from "./views/registerView.js";
import { setupHome } from "./views/homeView.js";
import { logout } from "./api/data.js";
import { onEdit, setupEdit } from "./views/editView.js";
import { onCreate, setupCreate } from "./views/createView.js";
import { setupAllMeme } from "./views/allMemeView.js";
import { setupDetails } from "./views/detailsView.js";
import { setupProfile } from "./views/profileView.js";


const navBar = document.querySelector('#nav-bar');
const main = document.getElementById('root');
const errorBox = document.querySelector('#errorBox');

const navigator = createNavigator(main, navBar,errorBox);

const views = {
    homeView: navigator.registerView('home', setupHome, 'homeNav'),
    loginView: navigator.registerView('login', setupLogin, 'loginNav'),
    registerView: navigator.registerView('register', setupRegister, 'registerNav'),
    editView: navigator.registerView('edit', setupEdit),
    createView: navigator.registerView('create', setupCreate, 'createMemeNav'),
    allMemeView: navigator.registerView('allMeme', setupAllMeme, 'allMemeNav'),
    detailsView: navigator.registerView('details', setupDetails),
    profileView: navigator.registerView('profile', setupProfile)
}
page('index.html', '/');
page('/', views.homeView);
// page('/delete/:id', onDelete);
page('/allMeme', views.allMemeView);
page('/details/:id', views.detailsView);
page('/profile', views.profileView);

page('/login', views.loginView);
navigator.registerForm('login-form', onLogin, () => { page.redirect('/allMeme'); navigator.setUserNav() });

page('/register', views.registerView);
navigator.registerForm('register-form', onRegister, () => { page.redirect('/allMeme'); navigator.setUserNav() });

page('/create', views.createView);
navigator.registerForm('create-form', onCreate, () => { page.redirect('/allMeme'); });

page('/edit/:id', views.editView);
navigator.registerForm('edit-form', onEdit, (id) => { page.redirect(`/details/${id}`); });

page('/logout', onLogout);

page.start();

async function onLogout() {
    try {
        await logout();

        navigator.setUserNav();
        page.redirect('/');
    } catch (err) {
        alert(err.message);
    }

}
