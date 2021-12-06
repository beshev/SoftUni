import { render } from "./lib.js";
import auth from './authService.js'



export function createNavigator(main, navBar) {
    const views = {};
    const forms = {};

    setupForm();
    setUserNav();

    const navigator = {
        registerView,
        registerForm,
        setUserNav,
    }

    return navigator;


    function registerView(name, setup, navId) {
        const executor = setup();

        views[name] = (...params) => {
            return executor(...params);
        }

        return async (...params) => render(await views[name](...params), main);
    }

    function registerForm(name, handler, onSuccess) {
        forms[name] = {
            handler,
            onSuccess,
        }
    }

    function setupForm() {
        window.addEventListener('submit', onSubmit);
    }

    function setUserNav() {
        const guestDiv = navBar.querySelector('#guest');
        const userDiv = navBar.querySelector('#user');

        if (auth.isAuth()) {
            guestDiv.style.display = 'none';
            userDiv.style.display = 'inline-block';
        } else {
            guestDiv.style.display = 'inline-block';
            userDiv.style.display = 'none';
        }
    }

    function onSubmit(ev) {
        const { handler, onSuccess } = forms[ev.target.id]
        if (typeof (handler) === 'function') {
            ev.preventDefault();
            const formData = new FormData(ev.target);
            const body = [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {});
            handler(body, onSuccess);
        }
    }
}