import api from "../api/api.js";
import { html } from "../dom.js"


const myTeamsTemplate = (teams) => html`
    <section id="my-teams">
        <article class="pad-med">
            <h1>My Teams</h1>
        </article>
        ${teams.length > 0 ? html`
        <article class="layout narrow">
            <div class="pad-small"><a href="/create" class="action cta">Create Team</a></div>
        </article>
        ` 
        : ''}
        ${teams.length > 0 ? 
            teams.map(teamTemplate) 
            : noTeamsTemplate()}
    </section>
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

const noTeamsTemplate = () => html`
    <article class="layout narrow">
        <div class="pad-med">
            <p>You are not a member of any team yet.</p>
            <p><a href="/browse-teams">Browse all teams</a> to join one, or use the button bellow to cerate your own
                team.</p>
        </div>
        <div class=""><a href="/create" class="action cta">Create Team</a></div>
    </article>
`

export function setupMyTeams() {
    return showMyTeams;

    async function showMyTeams() {
        const userId = sessionStorage.getItem('userId');
        const teams = (await api.getMyTeams(userId)).map(x => x.team);
        const members = await api.getAllMembers();

        teams.forEach(t => {
            const teamMembers = members.filter(x => x.teamId == t._id)
            t.members = teamMembers;
        });

        return myTeamsTemplate(teams);
    }
}