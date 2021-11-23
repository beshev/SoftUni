import { createNavigator } from "./navigator.js";
import page from '../node_modules/page/page.mjs'
import { onLogin, setupLogin } from "./views/loginView.js";
import { onRegister, setupRegister } from "./views/registerView.js";
import { setupHome } from "./views/homeView.js";
import { deleteResourceByIdAsync, logoutAsync } from "./api/data.js";
import { onEdit, setupEdit } from "./views/editView.js";
import { onCreate, setupCreate } from "./views/createView.js";
import { setupDetails } from "./views/detailsViews.js";
import { setupAllCars } from "./views/allCarsView.js";
import { setupMyList } from "./views/myListView.js";
import { setupSearch } from "./views/searchView.js";


const navBar = document.getElementById('nav-bar');
const main = document.getElementById('site-content');

const navigator = createNavigator(main, navBar);

const views = {
    homeView: navigator.registerView('home', setupHome, 'home-nav'),
    loginView: navigator.registerView('login', setupLogin, 'login-nav'),
    registerView: navigator.registerView('register', setupRegister, 'register-nav'),
    editView: navigator.registerView('edit', setupEdit),
    createView: navigator.registerView('create', setupCreate, 'create-car-nav'),
    detailsView: navigator.registerView('details', setupDetails),
    allCarasView: navigator.registerView('all-cars', setupAllCars, 'all-cars-nav'),
    myCarsView: navigator.registerView('my-cars', setupMyList, 'my-cars-nav'),
    searchView: navigator.registerView('search-cars', setupSearch, 'search-nav'),
}

page('/index.html', '/');
page('/', views.homeView);
page('/my-cars', views.myCarsView);
page('/search-cars', views.searchView);
page('/search-cars/:year', views.searchView);
page('/all-cars', views.allCarasView);
page('/details/:id', views.detailsView);

page('/login', views.loginView);
navigator.registerForm('login-form', onLogin, () => { page.redirect('/all-cars'); navigator.setUserNav() });

page('/register', views.registerView);
navigator.registerForm('register-form', onRegister, () => { page.redirect('/all-cars'); navigator.setUserNav() });

page('/create', views.createView);
navigator.registerForm('create-form', onCreate, () => { page.redirect('/all-cars'); });

page('/edit/:id', views.editView);
navigator.registerForm('edit-form', onEdit, (carId) => { page.redirect(`/details/${carId}`); });

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

async function onDelete(context) {
    try {
        const id = context.params.id;
        await deleteResourceByIdAsync(id);
        context.page.redirect('/');
    } catch (err) {
        alert(err.message);
    }
}