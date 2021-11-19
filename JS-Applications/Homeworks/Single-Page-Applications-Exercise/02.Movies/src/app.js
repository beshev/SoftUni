import movieModule from './movie.js';
import loginModule from './login.js';
import registerModule from './register.js';
import createModule from './create.js';
import detailsModule from './details.js';
import editModule from './edit.js';

const main = document.getElementById('main');
const homePage = document.getElementById('home-page');
const h1 = document.querySelector('h1.text-center');
const movieSection = document.getElementById('movie');
const loginSection = document.getElementById('form-login');
const registerSection = document.getElementById('form-sign-up');
const createSecion = document.getElementById('add-movie');
const detailsSection = document.getElementById('movie-example');
const editSection = document.getElementById('edit-movie');

const navBar = document.querySelector('body div nav');
navBar.addEventListener('click', onNav);

const addButton = document.getElementById('add-movie-button');
addButton.addEventListener('click', () => links.Create());

loginModule.setLogin(main, loginSection);
registerModule.setRegister(main, registerSection);
movieModule.setMovie(main, movieSection);
createModule.setCreate(main, createSecion);
detailsModule.setDetails(main,detailsSection);
editModule.setEdit(main,editSection);

loadHomePage();

const links = {
    Login: loginModule.showLogin,
    Register: registerModule.showRegister,
    Movies: loadHomePage,
    Logout: loginModule.logout,
    Create: createModule.showCreate,
}

document.getElementById('views').remove();

export function loadHomePage() {
    let welcomeA = document.querySelector('a[data-welcome="welcome"]');
    welcomeA.textContent = 'Welcome, ' + sessionStorage.getItem('email');
    addButton.style.display = sessionStorage.getItem('token') ? 'block' : 'none';

    main.innerHTML = '';
    setNavBar();

    main.appendChild(homePage);
    main.appendChild(h1);
    main.appendChild(addButton);
    movieModule.showMovies();
}

function onNav(e) {
    let a = e.target;
    if (a.tagName !== 'A') {
        return;
    }
    links[a.textContent]();
}

function setNavBar() {
    const token = sessionStorage.getItem('token');
    let ancers = Array.from(navBar.querySelectorAll('a.nav-link'));
    if (token === null) {
        ancers.forEach(x => {
            if (x.getAttribute('data-user') == 'guest') {
                x.style.display = 'inline';
            } else {
                x.style.display = 'none';
            }
        })
    } else {
        ancers.forEach(x => {
            if (x.getAttribute('data-user') == 'user') {
                x.style.display = 'inline';
            } else {
                x.style.display = 'none';
            }
        })
    }
}


