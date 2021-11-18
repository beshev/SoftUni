import { render } from './dom.js'


export function createNavigator(navBar, main) {
    const views = {};
    const forms = {};

    setupForms();

    const navigator = {
        registerForm,
        registerView,
        setUserNav,
    }

    return navigator;

    function registerView(name, setup) {
        const execute = setup();

        views[name] = (...params) => {
            return execute(...params);
        }

        return async (...params) => render(await views[name](...params), main);
    }

    function registerForm(name, handler, onSuccess) {
        forms[name] = {
            handler,
            onSuccess,
        }
    }

    function setupForms() {
        document.body.addEventListener('submit', onSubmit)
    }

    function onSubmit(ev) {
        const { handler, onSuccess } = forms[ev.target.id];
        if (typeof handler === 'function') {
            ev.preventDefault();
            const formData = new FormData(ev.target);
            const body = [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v.trim() }), {});
            handler(body, onSuccess);
        }
    }

    function setUserNav() {
        const guestsA = navBar.querySelectorAll('a[data-user="guest"]');
        const usersA = navBar.querySelectorAll('a[data-user="user"]');

        if (sessionStorage.getItem('token') != null) {
            guestsA.forEach(a => {
                a.style.display = 'none';
            });
            usersA.forEach(a => {
                a.style.display = 'inline-block';
            });
        } else {
            guestsA.forEach(a => {
                a.style.display = 'inline-block';
            });
            usersA.forEach(a => {
                a.style.display = 'none';
            });
        }
    }
}