import api from "../api/api.js";
import { html } from "../dom.js"


const browseTemplate = (teams, isAuth) => html`
    <section id="browse">
        <article class="pad-med">
            <h1>Team Browser</h1>
        </article>
        ${isAuth ? createButtonTemplate() : ''}
        ${teams.map(teamTemplate)}
    </section>
`

const createButtonTemplate = () => html`
    <article class="layout narrow">
        <div class="pad-small"><a href="/create" class="action cta">Create Team</a></div>
    </article>
`

const teamTemplate = (team) => html`
<article class="layout">
    <img src="${team.logoUrl}" class="team-logo left-col">
    <div class="tm-preview">
        <h2>${team.name}</h2>
        <p>${team.description}</p>
        <span class="details">${team.members.length} Members</span>
        <div><a href="/details/${team._id}" class="action">See details</a></div>
    </div>
</article>
`

export function setupBrowse() {
    return showBrowse;

    async function showBrowse() {
        const isAuth = sessionStorage.getItem('token') !== null;
        const teams = await api.getAllTeams();
        const members = await api.getAllMembers();
        
        teams.forEach(t => {
            const teamMembers = members.filter(x => x.teamId == t._id)
            t.members = teamMembers;
        });

        return browseTemplate(teams, isAuth);
    }
}