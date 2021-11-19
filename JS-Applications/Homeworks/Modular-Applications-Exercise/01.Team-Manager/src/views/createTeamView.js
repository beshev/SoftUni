import { html } from "../dom.js"
import api from "../api/api.js";
import { getElementById } from "../dom.js";


const createTemplate = () => html`
    <section id="create">
        <article class="narrow">
            <header class="pad-med">
                <h1>New Team</h1>
            </header>
            <form id="create-form" class="main-form pad-large">
                <div class="error" id="error" style="display: none">Error message.</div>
                <label>Team name: <input type="text" name="name"></label>
                <label>Logo URL: <input type="text" name="logoUrl"></label>
                <label>Description: <textarea name="description"></textarea></label>
                <input class="action cta" type="submit" value="Create Team">
            </form>
        </article>
    </section>
`

export function setupCreate() {
    return showCreate

    function showCreate() {
        return createTemplate();
    }
}


export async function onCreate(data, onSuccess) {
    try {

        if (data.name.length < 4) {
            throw Error('Name is required, at least 4 characters');
        }

        if (data.logoUrl === '') {
            throw Error('LogoUrl is required');
        }

        if (data.description.length < 10) {
            throw Error('Description is required, at least 10 characters');
        }

        let teamData = await api.create(JSON.stringify(data));
        let member = await api.pendingMember(JSON.stringify({ teamId: teamData._id }))

        await api.approveMember(member._id, JSON.stringify({
            status: 'member',
        }));

        onSuccess(teamData._id);
    } catch (err) {
        let errDiv = getElementById('error');
        errDiv.textContent = err.message;
        errDiv.style.display = 'block';
    }
}