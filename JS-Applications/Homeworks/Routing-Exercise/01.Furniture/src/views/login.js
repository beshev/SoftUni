import { html } from "../dom.js";
import api from "../api/api.js";

const loginTemplate = () => html`
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Login User</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form id="loginForm">
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
                    <input type="submit" class="btn btn-primary" value="Login" />
                </div>
            </div>
        </form>
    </div>
`

export function setupLogin() {
    return loginView;

    function loginView() {
        return loginTemplate();
    }
}

export async function onLogin(data, onSuccess) {
    try {
        if (data.email === '' || data.password === '') {
            throw new Error('All field are required!');
        }

        await api.login(JSON.stringify(data));
        onSuccess();
    } catch (err) {
        alert(err.message);
    }
}