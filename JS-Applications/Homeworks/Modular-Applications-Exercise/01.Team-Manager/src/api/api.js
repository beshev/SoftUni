import { removeUserData } from "../dom.js";

const host = 'http://localhost:3030';
const endPoints = {
    LOGIN: host + '/users/login',
    REGISTER: host + '/users/register',
    LOGOUT: host + '/users/logout',
    TEAMS: host + '/data/teams',
    ALL_MEMBERS: host + '/data/members?where=status%3D%22member%22',
    MEMBERS: host + '/data/members/'
}

async function login(body) {
    const response = await fetch(endPoints.LOGIN, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body
    });

    if (response.ok == false) {
        let data = await response.json();
        throw Error(data.message);
    }

    return response.json();
}

async function register(body) {
    const response = await fetch(endPoints.REGISTER, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body
    });

    if (response.ok == false) {
        let data = await response.json();
        throw Error(data.message);
    }

    return response.json();
}

async function create(body) {
    const response = await fetch(endPoints.TEAMS, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('token'),
        },
        body
    });

    if (response.ok == false) {
        let data = await response.json();
        throw Error(data.message);
    }

    return response.json();
}

async function edit(teamId, body) {
    const response = await fetch(endPoints.TEAMS + `/${teamId}`, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('token'),
        },
        body
    });

    if (response.ok == false) {
        let data = await response.json();
        throw Error(data.message);
    }

    return response.json();
}

async function logout() {
    await fetch(endPoints.LOGOUT, {
        method: 'post',
        headers: {
            'X-Authorization': sessionStorage.getItem('token'),
        }
    })

    removeUserData();
}

async function getAllTeams() {
    let response = await fetch(endPoints.TEAMS);
    return response.json();
}

async function getTeamMembers(teamId) {
    const response = await fetch(host + `/data/members?where=teamId%3D%22${teamId}%22&load=user%3D_ownerId%3Ausers`);
    return await response.json();
}

async function getTeam(id) {
    const response = await fetch(endPoints.TEAMS + `/${id}`);
    return response.json();
}

async function getAllMembers() {
    const response = await fetch(endPoints.ALL_MEMBERS);
    return response.json();
}

async function pendingMember(body) {
    let response = await fetch(endPoints.MEMBERS, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('token'),
        },
        body,
    })

    return response.json();
}

async function approveMember(memberId, body) {
    let response = await fetch(endPoints.MEMBERS + memberId, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('token'),
        },
        body,
    })

    return response.json();
}

async function removeMember(memberId) {
    let response = await fetch(endPoints.MEMBERS + memberId, {
        method: 'DELETE',
        headers: {
            'X-Authorization': sessionStorage.getItem('token'),
        }
    })

    return response.json();
}

async function getMyTeams(userId) {
    let response = await fetch(host + `/data/members?where=_ownerId%3D%22${userId}%22%20AND%20status%3D%22member%22&load=team%3DteamId%3Ateams`)
    return await response.json();
}

export default {
    login,
    register,
    logout,
    getAllTeams,
    getAllMembers,
    create,
    getTeam,
    getTeamMembers,
    pendingMember,
    approveMember,
    removeMember,
    edit,
    getMyTeams,
}