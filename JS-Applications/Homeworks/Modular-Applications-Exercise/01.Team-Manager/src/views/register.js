import api from "../api/api.js";
import { getElementById, html, setUserData } from "../dom.js"


const registerTemplate = () => html`
<section id="register">
    <article class="narrow">
        <header class="pad-med">
            <h1>Register</h1>
        </header>
        <form id="register-form" class="main-form pad-large">
            <div class="error" id="error" style="display: none">Error message.</div>
            <label>E-mail: <input type="text" name="email"></label>
            <label>Username: <input type="text" name="username"></label>
            <label>Password: <input type="password" name="password"></label>
            <label>Repeat: <input type="password" name="repass"></label>
            <input class="action cta" type="submit" value="Create Account">
        </form>
        <footer class="pad-small">Already have an account? <a href="/login" class="invert">Sign in here</a>
        </footer>
    </article>
</section>
`


export function setupRegister() {
    return showRegister;

    function showRegister() {
        return registerTemplate();
    }
}


export async function onRegister(data, onSuccess) {
    try {
        if (data.email === '') {
            throw new Error('Email required');
        }

        if (data.username.length < 3) {
            throw new Error('Username must be at least 3 characters');
        }

        if (data.password.length < 3) {
            throw new Error('Password must be at least 3 characters');
        }

        if (data.password != data.repass) {
            throw new Error('Passwords don\'t match');
        }

        let userData = await api.register(JSON.stringify(data));
        setUserData(userData);
        onSuccess();
    } catch (err) {
        let errDiv = getElementById('error');
        errDiv.textContent = err.message;
        errDiv.style.display = 'block';
    }

}