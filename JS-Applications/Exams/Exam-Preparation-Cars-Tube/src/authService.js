
function isAuth() {
    return sessionStorage.getItem('token') !== null;
}

function getToken() {
    return sessionStorage.getItem('token');
}

function getUserId() {
    return sessionStorage.getItem('userId');
}

function getUsername() {
    return sessionStorage.getItem('username');
}

export default {
    isAuth,
    getToken,
    getUserId,
    getUserEmail: getUsername,
}