import { html } from "../dom.js";
import api from "../api/api.js";

const registerTemplate = () => html`
<div class="container">
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Register New User</h1>
            <p>Please fill all fields.</p>
        </div>
    </div>
    <form id="registerForm">
        <div class="row space-top">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="email">Email</label>
                    <input class="form-control" id="email" type="text" name="email">
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="password">Password</label>
                    <input class="form-control" id="password" type="password" name="password">
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="rePass">Repeat</label>
                    <input class="form-control" id="rePass" type="password" name="rePass">
                </div>
                <input type="submit" class="btn btn-primary" value="Register" />
            </div>
        </div>
    </form>
</div>`

export function setupRegister() {
    return registerView;

    function registerView() {
        return registerTemplate();
    }
}

export async function onRegister(data, onSuccess) {
    try {
        if (data.email === '' || data.password === '') {
            throw new Error('All field are required!');
        }

        if (data.password !== data.rePass) {
            throw new Error('Passwords don\'t match');
        }
        
        await api.register(JSON.stringify(data));
        onSuccess();
    } catch (err) {
        alert(err.message);
    }
}