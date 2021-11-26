import { loginAsync } from '../api/data.js';
import { html } from '../lib.js'

const loginTemplate = () => html`
<!-- Login Page ( Only for Guest users ) -->
<section id="login-page" class="auth">
    <form id="login">
        <div class="container">
            <div class="brand-logo"></div>
            <h1>Login</h1>
            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="Sokka@gmail.com">

            <label for="login-pass">Password:</label>
            <input type="password" id="login-password" name="password">
            <input type="submit" class="btn submit" value="Login">
            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </div>
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