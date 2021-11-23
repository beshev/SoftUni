import { loginAsync } from '../api/data.js';
import { html } from '../lib.js'

const loginTemplate = () => html`
<!-- Login Page -->
<section id="login">
    <div class="container">
        <form id="login-form" action="#" method="post">
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>

            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="/register">Sign up</a>.
            </p>
        </div>
    </div>
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
        if (data.username === '' || data.password === '') {
            throw new Error('Email or password don\'t match!!')
        }

        const body = {
            username: data.username,
            password: data.password,
        }

        await loginAsync(body);
        onSuccess();
    } catch (err) {
        alert(err.message);
    }
}