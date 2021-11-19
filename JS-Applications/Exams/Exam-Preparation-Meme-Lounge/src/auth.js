
function isAuth() {
    return sessionStorage.getItem('token') !== null;
}

function getToken() {
    return sessionStorage.getItem('token');
}

function getUserId() {
    return sessionStorage.getItem('userId');
}

function getUserEmail() {
    return sessionStorage.getItem('email');
}

function getUsername() {
    return sessionStorage.getItem('username');
}

function getGender() {
    return sessionStorage.getItem('gender');
}

export default {
    isAuth,
    getToken,
    getUserId,
    getUserEmail,
    getUsername,
    getGender
}