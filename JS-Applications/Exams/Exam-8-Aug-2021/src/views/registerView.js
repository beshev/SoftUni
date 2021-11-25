import { registerAsync } from "../api/data.js";
import { html } from "../lib.js";


const registerTemplate = () => html`
<!-- Register Page ( Only for Guest users ) -->
<section id="register-page" class="register">
    <form id="register-form" action="" method="">
        <fieldset>
            <legend>Register Form</legend>
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
            <p class="field">
                <label for="repeat-pass">Repeat Password</label>
                <span class="input">
                    <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Register">
        </fieldset>
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
        if (data.email === '') {
            throw new Error('Email field is required!!')
        }

        if (data.password === '') {
            throw new Error('Password field is required!!')
        }

        if (data.password !== data['confirm-pass']) {
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