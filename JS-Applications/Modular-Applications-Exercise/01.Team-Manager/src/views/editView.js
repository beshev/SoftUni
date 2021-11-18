import { html, getElementById } from "../dom.js"
import api from "../api/api.js"


const editTemplate = (team) => html`
    <section id="edit">
        <article class="narrow">
            <header class="pad-med">
                <h1>Edit Team</h1>
            </header>
            <form id="edit-form" class="main-form pad-large">
                <input type="hidden" name="teamId" .value=${team._id} />
                <div class="error" id="error" style="display: none">Error message.</div>
                <label>Team name: <input type="text" name="name" .value=${team.name}></label>
                <label>Logo URL: <input type="text" name="logoUrl" .value=${team.logoUrl}></label>
                <label>Description: <textarea name="description" .value=${team.description}></textarea></label>
                <input class="action cta" type="submit" value="Save Changes">
            </form>
        </article>
    </section>
`

export function setupEdit() {
    return showEdit;

    async function showEdit(context) {
        const id = context.params.teamId;
        const team = await api.getTeam(id);

        return editTemplate(team);
    }
}

export async function onEdit(data, onSuccess) {
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

        let teamData = await api.edit(data.teamId, JSON.stringify(data));
        onSuccess(teamData._id);
    } catch (err) {
        let errDiv = getElementById('error');
        errDiv.textContent = err.message;
        errDiv.style.display = 'block';
    }
}