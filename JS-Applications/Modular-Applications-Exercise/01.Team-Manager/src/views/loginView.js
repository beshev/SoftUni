import api from "../api/api.js";
import { getElementById, html, setUserData } from "../dom.js"


const loginTemplate = () => html`
    <section id="login">
        <article class="narrow">
            <header class="pad-med">
                <h1>Login</h1>
            </header>
            <form id="login-form" class="main-form pad-large">
                <div class="error" id="error" style="display: none">Error message.</div>
                <label>E-mail: <input type="text" name="email"></label>
                <label>Password: <input type="password" name="password"></label>
                <input class="action cta" type="submit" value="Sign In">
            </form>
            <footer class="pad-small">Don't have an account? <a href="/register" class="invert">Sign up here</a>
            </footer>
        </article>
    </section>
`


export function setupLogin() {
    return showLogin;

    function showLogin() {
        return loginTemplate();
    }
}


export async function onLogin(data, onSuccess) {
    try {
        let userData = await api.login(JSON.stringify(data));
        setUserData(userData);
        onSuccess();
    } catch (err) {
        let errDiv = getElementById('error');
        errDiv.textContent = err.message;
        errDiv.style.display = 'block';
    }

}