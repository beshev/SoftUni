import logControl from './logControl.js';
import recepiModule from './recepies.js';

let loginRef = document.getElementById('login-ref');
loginRef.addEventListener('click', loginNav);
let loginForm = document.getElementById('login-form');
loginForm.addEventListener('submit', onLogin);

document.getElementById('logoutBtn').addEventListener('click', () => {
    logControl.logout();
    setUpNavigationBar();
});

let register = document.getElementById('register-ref');
register.addEventListener('click', registerNav);
let registerForm = document.getElementById('register-form');
registerForm.addEventListener('submit', onRegister);

let catalogRef = document.getElementById('catalog-ref');
catalogRef.addEventListener('click', setUpNavigationBar);
setUpNavigationBar();

let createRef = document.getElementById('create-ref');
createRef.addEventListener('click', createNav);
let createForm = document.getElementById('create-form');
createForm.addEventListener('submit', createRecepie);

let root = document.querySelector('body main div.root');

validateIfUserLoggin();

function createRecepie(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);
    recepiModule.create(formData);
    e.currentTarget.reset();
    setUpNavigationBar();
}

function createNav(e) {
    hideAllElementsInRoot();
    removeAllActiveClass();
    e.currentTarget.classList.add('active');
    let createArtcle = document.getElementById('create-article');
    createArtcle.classList.remove('hidden');
}

async function onRegister(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);
    await logControl.register(formData.get('email'), formData.get('password'), formData.get('rePass'));
    registerForm.reset();
    setUpNavigationBar();
}

async function setUpNavigationBar() {
    hideAllElementsInRoot();
    removeAllActiveClass();
    validateIfUserLoggin();
    let recepies = await recepiModule.getRecepies();

    Array.from(document.querySelectorAll('.preview'))
        .forEach(x => x.remove());

    catalogRef.classList.add('active');
    let cards = recepies.map((x) => {
        let currenRecepie = recepiModule.loadRecepies(x);
        currenRecepie.addEventListener('click', recipeInfo.bind(null, x._id));
        return currenRecepie;
    });
    cards.map(x => root.appendChild(x));
}

async function onLogin(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);
    await logControl.login(formData.get('email'), formData.get('password'));
    loginForm.reset();
    setUpNavigationBar();
}

async function recipeInfo(recepieId) {
    let result = recepiModule.createRecipeInfo(await recepiModule.getRecipeById(recepieId));

    Array.from(document.querySelectorAll('.recipeInfo')).forEach(x => x.remove());
    hideAllElementsInRoot();
    root.appendChild(result);
}

function loginNav(e) {
    hideAllElementsInRoot();
    removeAllActiveClass();

    document.getElementById('login-article').classList.remove('hidden');
    e.currentTarget.classList.add('active');
}

function registerNav(e) {
    hideAllElementsInRoot();
    removeAllActiveClass();

    document.getElementById('register-article').classList.remove('hidden');
    e.currentTarget.classList.add('active');
}

function hideAllElementsInRoot() {
    Array.from(document.querySelector('div.root').children)
        .forEach(x => {
            x.classList.add('hidden');
        });
}

function removeAllActiveClass() {
    Array.from(document.querySelectorAll('.active'))
        .forEach(x => x.classList.remove('active'));
}

function validateIfUserLoggin() {
    let userDiv = document.getElementById('user');
    let guestDiv = document.getElementById('guest');

    if (logControl.isAuthenticated()) {
        guestDiv.style.display = 'none';
        userDiv.style.display = 'inline';
    } else {
        guestDiv.style.display = 'inline';
        userDiv.style.display = 'none';
    }
}

export default {
    document,
    setUpNavigationBar,
    recipeInfo,
}