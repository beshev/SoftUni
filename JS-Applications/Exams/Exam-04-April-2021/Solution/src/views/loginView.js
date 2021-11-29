import { loginAsync } from '../api/data.js';
import { html } from '../lib.js'

const loginTemplate = () => html`
<section id="login-page" class="content auth">
    <h1>Login</h1>
    <form id="login" action="#" method="">
        <fieldset>
            <blockquote>Knowledge is like money: to be of value it must circulate, and in circulating it can
                increase in quantity and, hopefully, in value</blockquote>
            <p class="field email">
                <label for="email">Email:</label>
                <input type="email" id="email" name="email" placeholder="maria@email.com">
            </p>
            <p class="field password">
                <label for="login-pass">Password:</label>
                <input type="password" id="login-pass" name="password">
            </p>
            <p class="field submit">
                <input class="btn submit" type="submit" value="Log in">
            </p>
            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </fieldset>
    </form>
</section>`;


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