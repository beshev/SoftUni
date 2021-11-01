async function login(email, password) {
    try {
        let res = await fetch('http://localhost:3030/users/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                email,
                password,
            })
        });

        let data = await res.json();

        if (data.accessToken) {
            sessionStorage.setItem('token', data.accessToken);
            sessionStorage.setItem('userId', data._id);
        } else {
            throw data;
        }
    } catch (err) {
        alert(err.message);
    }

}

async function register(email, password, repeat) {
    if (password !== repeat) {
        return console.error('Passwords don\'t match');
    }

    try {
        let res = await fetch('http://localhost:3030/users/register', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                email,
                password,
            })
        });

        let data = await res.json();

        if (data.accessToken) {
            sessionStorage.setItem('token', data.accessToken);
            sessionStorage.setItem('userId', data._id);
        } else {
            throw data;
        }
    } catch (err) {
        console.error(err.message)
    }
}

function logout() {
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('userId');
}

function isAuthenticated() {
    return Boolean(sessionStorage.getItem('token'));
}

function getUserId() {
    return sessionStorage.getItem('userId');
}

function getSessionId() {
    return sessionStorage.getItem('token');
}

export default {
    login,
    register,
    isAuthenticated,
    logout,
    getUserId,
    getSessionId
}