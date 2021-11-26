import { createNavigator } from "./navigator.js";
import page from '../node_modules/page/page.mjs'
import { onLogin, setupLogin } from "./views/loginView.js";
import { onRegister, setupRegister } from "./views/registerView.js";
import { setupHome } from "./views/homeView.js";
import { logoutAsync } from "./api/data.js";
import { onEdit, setupEdit } from "./views/editView.js";
import { onCreate, setupCreate } from "./views/createView.js";
import { setupDetails, onComment } from "./views/detailsViews.js";
import { setupAllGames } from "./views/allGamesView.js";


const navBar = document.getElementById('nav-bar');
const main = document.getElementById('main-content');

const navigator = createNavigator(main, navBar);

const views = {
    homeView: navigator.registerView('home', setupHome),
    loginView: navigator.registerView('login', setupLogin),
    registerView: navigator.registerView('register', setupRegister),
    editView: navigator.registerView('edit', setupEdit),
    createView: navigator.registerView('create', setupCreate),
    detailsView: navigator.registerView('details', setupDetails),
    allGamesView: navigator.registerView('all-games', setupAllGames)
}

page('/index.html', '/');
page('/', views.homeView);
page('/all-games', views.allGamesView);
page('/details/:id', views.detailsView)

page('/login', views.loginView);
navigator.registerForm('login', onLogin, () => { page.redirect('/'); navigator.setUserNav() });

page('/register', views.registerView);
navigator.registerForm('register', onRegister, () => { page.redirect('/'); navigator.setUserNav() });

page('/create', views.createView);
navigator.registerForm('create', onCreate, () => { page.redirect('/'); });

page('/edit/:id', views.editView);
navigator.registerForm('edit', onEdit, (form, gameId) => { page.redirect(`/details/${gameId}`); });

navigator.registerForm('comment-form', onComment, (form, gameId) => { page.redirect(`/details/${gameId}`); form.reset(); });

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