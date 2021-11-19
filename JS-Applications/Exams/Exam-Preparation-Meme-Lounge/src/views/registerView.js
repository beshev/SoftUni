import { register } from "../api/data.js";
import { html } from "../lib.js";


const registerTemplate = () => html`
<!-- Register Page ( Only for guest users ) -->
<section id="register">
    <form id="register-form">
        <div class="container">
            <h1>Register</h1>
            <label for="username">Username</label>
            <input id="username" type="text" placeholder="Enter Username" name="username">
            <label for="email">Email</label>
            <input id="email" type="text" placeholder="Enter Email" name="email">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <label for="repeatPass">Repeat Password</label>
            <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
            <div class="gender">
                <input type="radio" name="gender" id="female" value="female">
                <label for="female">Female</label>
                <input type="radio" name="gender" id="male" value="male" checked>
                <label for="male">Male</label>
            </div>
            <input type="submit" class="registerbtn button" value="Register">
            <div class="container signin">
                <p>Already have an account?<a href="/login">Sign in</a>.</p>
            </div>
        </div>
    </form>
</section>
`;


export function setupRegister() {
    return showRegister;

    async function showRegister() {
        return registerTemplate();
    }
}

export async function onRegister(data, onSuccess, errorBox) {
    try {
        if (data.username === '') {
            throw new Error('Username is required!');
        }

        if (data.email === '') {
            throw new Error('Email is required!');
        }

        if (data.password === '') {
            throw new Error('Passwords is required!');
        }

        if (data.password !== data.repeatPass) {
            throw new Error('Passwords don\'t match');
        }

        const body = {
            email: data.email,
            password: data.password,
            username: data.username,
            gender: data.gender
        }

        await register(body);
        onSuccess();
    } catch (err) {
        const span = errorBox.querySelector('span')
        span.textContent = err.message;
        errorBox.style.display = 'block';
        setTimeout(() => errorBox.style.display = 'none', 3000);
    }

}