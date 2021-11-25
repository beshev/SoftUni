import { loginAsync } from '../api/data.js';
import { html } from '../lib.js'

const loginTemplate = () => html`
<!-- Login Page ( Only for Guest users ) -->
<section id="login-page" class="login">
    <form id="login-form" action="" method="">
        <fieldset>
            <legend>Login Form</legend>
            <p class="field">
                <label for="email">Email</label>
                <span class="input">
                    <input type="text" name="email" id="email" placeholder="Email">
                </span>
            </p>
            <p class="field">
                <label for="password">Password</label>
                <span class="input">
                    <input type="password" name="password" id="password" placeholder="Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Login">
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