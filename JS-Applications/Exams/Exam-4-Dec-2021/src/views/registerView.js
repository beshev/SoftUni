import { registerAsync } from "../api/data.js";
import { html } from "../lib.js";


const registerTemplate = () => html`
<!--Registration-->
<section id="registerPage">
    <form id="register-form">
        <fieldset>
            <legend>Register</legend>

            <label for="email" class="vhide">Email</label>
            <input id="email" class="email" name="email" type="text" placeholder="Email">

            <label for="password" class="vhide">Password</label>
            <input id="password" class="password" name="password" type="password" placeholder="Password">

            <label for="conf-pass" class="vhide">Confirm Password:</label>
            <input id="conf-pass" class="conf-pass" name="conf-pass" type="password" placeholder="Confirm Password">

            <button type="submit" class="register">Register</button>

            <p class="field">
                <span>If you already have profile click <a href="/login">here</a></span>
            </p>
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

        [...Object.values(data)].forEach(x => {
            if (x == '') {
                throw new Error('All fields are required!!')
            }
        })

        if (data.password !== data['conf-pass']) {
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