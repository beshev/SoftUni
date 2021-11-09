import { showNavBar } from './app.js';
import { viewDashboard } from './dashboard.js';

let main = undefined;
let section = undefined;


function setHome(tagName, targetSection) {
    main = tagName;
    section = targetSection;
}

export async function viewHome() {
    main.innerHTML = '';

    if (localStorage.getItem('token') !== null) {
        viewDashboard();
    } else {
        main.appendChild(section);
        showNavBar();
    }
}

export default {
    setHome,
    viewHome,
}