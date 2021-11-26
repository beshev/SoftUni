import { registerAsync } from "../api/data.js";
import { html } from "../lib.js";


const registerTemplate = () => html`
<!-- Register Page ( Only for Guest users ) -->
<section id="register-page" class="content auth">
    <form id="register">
        <div class="container">
            <div class="brand-logo"></div>
            <h1>Register</h1>

            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="maria@email.com">

            <label for="pass">Password:</label>
            <input type="password" name="password" id="register-password">

            <label for="con-pass">Confirm Password:</label>
            <input type="password" name="confirm-password" id="confirm-password">

            <input class="btn submit" type="submit" value="Register">

            <p class="field">
                <span>If you already have profile click <a href="/login">here</a></span>
            </p>
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

export async function onRegister(data, onSuccess) {
    try {

        [...Object.values(data)].forEach(x => {
            if (x == '') {
                throw new Error('All fields are required!!')
            }
        })

        if (data.password !== data['confirm-password']) {
            throw new Error('Passwords dont\'t match!!')
        }

        const body = {
            email: data.email,
            password: data.password,
        }

        await registerAsync(body);
        onSuccess();
    } catch (err) {
        alert(err.message);
    }

}