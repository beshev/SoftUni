import { loginAsync } from '../api/data.js';
import { html } from '../lib.js'

const loginTemplate = () => html`
<!--Login-->
<section id="loginPage">
    <form id="login-form">
        <fieldset>
            <legend>Login</legend>

            <label for="email" class="vhide">Email</label>
            <input id="email" class="email" name="email" type="text" placeholder="Email">

            <label for="password" class="vhide">Password</label>
            <input id="password" class="password" name="password" type="password" placeholder="Password">

            <button type="submit" class="login">Login</button>

            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </fieldset>
    </form>
</section>
`


export function setupLogin() {
    return showLogin;

    async function showLogin() {
        return loginTemplate();
    }
}

export async function onLogin(data, onSuccess) {
    try {
        if (data.email === '' || data.password === '') {
            throw new Error('Email or password don\'t match!!')
        }

        const body = {
            email: data.email,
            password: data.password,
        }

        await loginAsync(body);
        onSuccess();
    } catch (err) {
        alert(err.message);
    }
}