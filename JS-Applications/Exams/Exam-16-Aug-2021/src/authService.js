
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

export default {
    isAuth,
    getToken,
    getUserId,
    getUserEmail,
}