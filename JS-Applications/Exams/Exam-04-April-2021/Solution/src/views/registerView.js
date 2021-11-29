import { registerAsync } from "../api/data.js";
import { html } from "../lib.js";


const registerTemplate = () => html`
<section id="register-page" class="content auth">
    <h1>Register</h1>
    <form id="register" action="#" method="">
        <fieldset>
            <blockquote>Knowledge is not simply another commodity. On the contrary. Knowledge is never used up.
                It
                increases by diffusion and grows by dispersion.</blockquote>
            <p class="field email">
                <label for="register-email">Email:</label>
                <input type="email" id="register-email" name="email" placeholder="maria@email.com">
            </p>
            <p class="field password">
                <label for="register-pass">Password:</label>
                <input type="password" name="password" id="register-pass">
            </p>
            <p class="field password">
                <label for="register-rep-pass">Repeat password:</label>
                <input type="password" name="rep-pass" id="register-rep-pass">
            </p>
            <p class="field submit">
                <input class="btn submit" type="submit" value="Register">
            </p>
            <p class="field">
                <span>If you already have profile click <a href="/login">here</a></span>
            </p>
        </fieldset>
    </form>
</section>`;


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

        if (data.password !== data['rep-pass']) {
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