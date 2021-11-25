import { createNavigator } from "./navigator.js";
import page from '../node_modules/page/page.mjs'
import { onLogin, setupLogin } from "./views/loginView.js";
import { onRegister, setupRegister } from "./views/registerView.js";
import { setupHome } from "./views/homeView.js";
import { deleteResourceByIdAsync, logoutAsync } from "./api/data.js";
import { onEdit, setupEdit } from "./views/editView.js";
import { onCreate, setupCreate } from "./views/createView.js";
import { setupDetails } from "./views/detailsViews.js";
import { setupMyBooks } from "./views/myBooksView.js";


const navBar = document.getElementById('nav-bar');
const main = document.getElementById('site-content');

const navigator = createNavigator(main, navBar);

const views = {
    homeView: navigator.registerView('home', setupHome),
    loginView: navigator.registerView('login', setupLogin),
    registerView: navigator.registerView('register', setupRegister),
    editView: navigator.registerView('edit', setupEdit),
    createView: navigator.registerView('create', setupCreate),
    detailsView: navigator.registerView('details', setupDetails),
    myBooksView: navigator.registerView('my-books', setupMyBooks),
}

page('index.html', '/');
page('/', views.homeView);
page('/my-books', views.myBooksView);
page('/details/:id', views.detailsView)

page('/login', views.loginView);
navigator.registerForm('login-form', onLogin, () => { page.redirect('/'); navigator.setUserNav() });

page('/register', views.registerView);
navigator.registerForm('register-form', onRegister, () => { page.redirect('/'); navigator.setUserNav() });

page('/create', views.createView);
navigator.registerForm('create-form', onCreate, () => { page.redirect('/'); });

page('/edit/:id', views.editView);
navigator.registerForm('edit-form', onEdit, (bookId) => { page.redirect(`/details/${bookId}`); });

page.start();

window.onLogout = onLogout;
async function onLogout() {
    try {
        await logoutAsync();
        navigator.setUserNav();
        page.redirect('/');
    } catch (err) {
        alert(err.message);
    }

}