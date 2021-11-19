import { login } from '../api/data.js';
import { html } from '../lib.js'

const loginTemplate = () => html`
<!-- Login Page ( Only for guest users ) -->
<section id="login">
    <form id="login-form">
        <div class="container">
            <h1>Login</h1>
            <label for="email">Email</label>
            <input id="email" placeholder="Enter Email" name="email" type="text">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn button" value="Login">
            <div class="container signin">
                <p>Dont have an account?<a href="/register">Sign up</a>.</p>
            </div>
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

export async function onLogin(data, onSuccess, errorBox) {
    try {
        if (data.email == '') {
            throw new Error('Email or password don\'t match');
        }

        if (data.password == '') {
            throw new Error('Email or password don\'t match');
        }

        const body = {
            email: data.email,
            password: data.password
        }

        await login(body);
        onSuccess();
    } catch (err) {
        const span = errorBox.querySelector('span')
        span.textContent = err.message;
        errorBox.style.display = 'block';
        setTimeout(() => errorBox.style.display = 'none', 3000);
    }
}