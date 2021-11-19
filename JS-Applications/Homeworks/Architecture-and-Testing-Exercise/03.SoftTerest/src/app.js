import home from './home.js';
import register from './register.js';
import login from './login.js';
import dashboard from './dashboard.js';
import create from './create.js';
import details from './details.js';

const links = {
    login: login.viewLogin,
    register: register.viewRegister,
    home: home.viewHome,
    logout: logout,
    dashboard: dashboard.viewDashboard,
    create: create.viewCreate,
}

initModules();
setNavBar();
solve();

function solve() {
    home.viewHome();

    document.getElementById('getStarted').addEventListener('click', (e) => {
        e.preventDefault();
        register.viewRegister();
    });

}

function initModules() {
    const main = document.getElementById('main');
    home.setHome(main, document.getElementById('homeView'));
    register.setRegister(main, document.getElementById('registerView'));
    login.setLogin(main, document.getElementById('loginView'));
    dashboard.setDashboard(main, document.getElementById('dashboard-holder'));
    create.setCreate(main, document.getElementById('createView'));
    details.setDetails(main, document.getElementById('detailsView'));

    document.getElementById('views').remove();
}

function setNavBar() {
    let navAncers = document.querySelectorAll('nav a');

    navAncers.forEach(a => {
        let handler = links[a.getAttribute('data-name')];
        a.addEventListener('click', (e) => {
            e.preventDefault();
            handler();
        })
    });
}

export function showNavBar() {
    const navLi = document.querySelectorAll('#navbarResponsive li');

    navLi.forEach(li => {
        if (localStorage.getItem('token') !== null) {
            li.style.display = li.getAttribute('data-user') == 'user' ? 'inline-block' : 'none';
        } else {
            li.style.display = li.getAttribute('data-user') == 'guest' ? 'inline-block' : 'none';
        }
    })

    let dash = document.querySelector('li[data-dashboard="dashboard"]')
    dash.style.display = 'inline-block';
}

async function logout() {
    await fetch('http://localhost:3030/users/logout', {
        method: 'get',
        headers: { 'X-Authorization': localStorage.getItem('token') },
    });
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    home.viewHome();
}