import { registerAsync } from "../api/data.js";
import { html } from "../lib.js";


const registerTemplate = () => html`
<!-- Register Page -->
<section id="register">
    <div class="container">
        <form id="register-form">
            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <hr>

            <p>Username</p>
            <input type="text" placeholder="Enter Username" name="username" required>

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password" required>

            <p>Repeat Password</p>
            <input type="password" placeholder="Repeat Password" name="repeatPass" required>
            <hr>

            <input type="submit" class="registerbtn" value="Register">
        </form>
        <div class="signin">
            <p>Already have an account?
                <a href="/login">Sign in</a>.
            </p>
        </div>
    </div>
</section>
`;


export function setupRegister() {
    return showRegister;

    async function showRegister() {
        return registerTemplate();
    }
}

export async function onRegister(data, onSuccess) {
    try {
        if (data.username === '') {
            throw new Error('Email field is required!!')
        }

        if (data.password === '') {
            throw new Error('Password field is required!!')
        }

        if (data.password !== data.repeatPass) {
            throw new Error('Passwords dont\'t match!!')
        }

        const body = {
            username: data.username,
            password: data.password,
        }

        await registerAsync(body);
        onSuccess();
    } catch (err) {
        alert(err.message);
    }

}