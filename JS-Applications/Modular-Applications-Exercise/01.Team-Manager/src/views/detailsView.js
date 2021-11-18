import { html } from "../dom.js"
import api from '../api/api.js'


const detailsTemplate = (team, members, pendingMembers ,auth,currentMember) => html`
    <section id="team-home">
        <article class="layout">
            <img src="${team.logoUrl}" class="team-logo left-col">
            <div class="tm-preview">
                <h2>${team.name}</h2>
                <p>${team.description}</p>
                <span class="details">${members.length} Members</span>
                <div>
                    ${auth.isOwner ? html`<a href="/edit/${team._id}" class="action">Edit team</a>` : ''}
                    ${auth.isUser ? html`<a href="/join-team/${team._id}" class="action">Join team</a>` : ''}
                    ${auth.isMember ? html`<a href="/remove/${currentMember._id}" class="action invert">Leave team</a>` : ''}
                    ${auth.isPending ? html`Membership pending. <a href="/remove/${currentMember._id}">Cancel request</a>` : ''}
                </div>
                <div class="pad-large">
                    <h3>Members</h3>
                    <ul class="tm-members">
                        ${members.map(x => memberLiTemplate(x, auth))}
                    </ul>
                </div>
                ${auth.isOwner ? html`
                    <div class="pad-large">
                        <h3>Membership Requests</h3>
                        <ul class="tm-members">
                            ${pendingMembers.map(pendingTemplate)}
                        </ul>
                    </div>
                ` : ''}
        </article>
    </section>
`

const memberLiTemplate = (member, auth) => html`
    <li>
        ${member.user.username}${auth.isOwner && member._ownerId !== sessionStorage.getItem('userId') 
        ? html`<a href="/remove/${member._id}" class="tm-control action">Remove from team</a>` 
        : ''}
    </li>
`

const pendingTemplate = (member) => html`
    <li>
        ${member.user.username}
        <a href="/approve/${member._id}" class="tm-control action">Approve</a>
        <a href="/remove/${member._id}" class="tm-control action">Decline</a>
    </li>
`

let currentTeamId;

export function setupDetails() {
    return showDetails

    async function showDetails(context) {
        const id = context.params.teamId;
        currentTeamId = id;
        const team = await api.getTeam(id);
        const allMembers = await api.getTeamMembers(id);

        const currentMember = allMembers.find(x => x.user._id == sessionStorage.getItem('userId'));

        const members = allMembers.filter(x => x.status == 'member');
        const pendingMembers = allMembers.filter(x => x.status == 'pending');

        const isOwner = sessionStorage.getItem('userId') == team._ownerId;
        const isMember = members.some(x => x.user._id == sessionStorage.getItem('userId')) && !isOwner;
        const isPending = pendingMembers.some(x => x.user._id == sessionStorage.getItem('userId'));
        const isUser = sessionStorage.getItem('token') !== null && !isOwner && !isMember && !isPending;

        const auth = {
            isOwner,
            isUser,
            isMember,
            isPending,
        }

        return detailsTemplate(team, members,pendingMembers,auth,currentMember);
    }
}

export async function onJoin(context){
    try {
        const body = {
            teamId: context.params.teamId
        }
        await api.pendingMember(JSON.stringify(body));
        context.page.redirect(`/details/${context.params.teamId}`);
    } catch (err) {
        alert(err.message);
    }
}

export async function onApprove(context){
    try {
        const memberId = context.params.memberId
        const body = {
            status: 'member',
        }

        let member =  await api.approveMember(memberId,JSON.stringify(body));

        context.page.redirect(`/details/${member.teamId}`);
    } catch (err) {
        alert(err.message);
    }
}

export async function onRemove(context){
    try {
        const memberId = context.params.memberId
        await api.removeMember(memberId);
        context.page.redirect(`/details/${currentTeamId}`);
    } catch (err) {
        alert(err.message);
    }
}