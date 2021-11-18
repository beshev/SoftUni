import { createNavigator } from "./navigator.js";
import page from '../node_modules/page/page.mjs';
import { setupHome } from "./views/homeView.js";
import { onLogin, setupLogin } from "./views/loginView.js";
import { onRegister, setupRegister } from "./views/register.js";
import { removeUserData } from "./dom.js";
import api from "./api/api.js";
import { setupBrowse } from "./views/browseView.js";
import { onCreate, setupCreate } from "./views/createTeamView.js";
import { setupDetails, onJoin, onApprove, onRemove } from "./views/detailsView.js";
import { onEdit, setupEdit } from "./views/editView.js";
import { setupMyTeams } from "./views/myTeamsView.js";




const main = document.getElementById('main');
const navBar = document.getElementById('navBar');

const navigator = createNavigator(navBar, main);
navigator.setUserNav();

const views = {
    homeView: navigator.registerView('home', setupHome),
    loginView: navigator.registerView('login', setupLogin),
    registerView: navigator.registerView('register', setupRegister),
    browseView: navigator.registerView('browse', setupBrowse),
    createView: navigator.registerView('create', setupCreate),
    detailsView: navigator.registerView('details', setupDetails),
    editView: navigator.registerView('edit', setupEdit),
    myTeamView: navigator.registerView('my-teams', setupMyTeams),
}

page('/', views.homeView);
page('/logout', logout);
page('/details/:teamId', views.detailsView);
page('/browse-teams', views.browseView);
page('/my-teams', views.myTeamView);

page('/login', views.loginView);
navigator.registerForm('login-form', onLogin, () => { page.redirect('/my-teams'); navigator.setUserNav(); })

page('/register', views.registerView);
navigator.registerForm('register-form', onRegister, () => { page.redirect('/my-teams'); navigator.setUserNav(); })

page('/create', views.createView);
navigator.registerForm('create-form', onCreate, (teamId) => { page.redirect(`/details/${teamId}`); })

page('/edit/:teamId', views.editView);
navigator.registerForm('edit-form', onEdit, (teamId) => { page.redirect(`/details/${teamId}`); })

page('/join-team/:teamId', onJoin);
page('/approve/:memberId', onApprove);
page('/remove/:memberId', onRemove);

page.start();


async function logout() {
    await api.logout();
    removeUserData();
    navigator.setUserNav();
    page.redirect('/login');
}