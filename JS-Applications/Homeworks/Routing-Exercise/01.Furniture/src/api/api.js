const endpoints = {
    LOGIN_USER: 'http://localhost:3030/users/login',
    REGISTER_USER: 'http://localhost:3030/users/register',
    LOGOUT_USER: 'http://localhost:3030/users/logout',
    CATALOG: 'http://localhost:3030/data/catalog/',
}


async function login(body) {
    const response = await fetch(endpoints.LOGIN_USER, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body
    })

    if (response.ok == false) {
        throw await response.json();
    }

    const userData = await response.json();
    setUserData(userData);
}

async function register(body) {
    const response = await fetch(endpoints.REGISTER_USER, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body
    });

    if (response.ok == false) {
        throw await response.json();
    }

    const userData = await response.json();
    setUserData(userData);
}

async function logout() {
    await fetch(endpoints.LOGOUT_USER, {
        method: 'get',
        headers: { 'X-Authorization': localStorage.getItem('userToken') }
    })

    removeUserData();
}

async function getAllFurniture() {
    let response = await fetch(endpoints.CATALOG);
    let data = await response.json();
    return data;
}

async function createFurniture(body) {
    await fetch(endpoints.CATALOG, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('userToken'),
        },
        body,
    })
}

async function getFurniture(id) {
    const response = await fetch(endpoints.CATALOG + id);
    const data = await response.json();
    return data;
}

async function editFurniture(id, body) {
    await fetch(endpoints.CATALOG + id, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('userToken'),
        },
        body
    })
}

async function deleteFurniture(id) {
    await fetch(endpoints.CATALOG + id, {
        method: 'delete',
        headers: { 'X-Authorization': localStorage.getItem('userToken') }
    });
}

async function myFurnitures() {
    const url = `http://localhost:3030/data/catalog?where=_ownerId%3D%22${localStorage.getItem('userId')}%22`
    const response = await fetch(url);
    const data = await response.json();
    return data;
}

function setUserData(userData) {
    localStorage.setItem('userToken', userData.accessToken);
    localStorage.setItem('email', userData.email);
    localStorage.setItem('userId', userData._id);
}

function removeUserData() {
    localStorage.removeItem('userToken');
    localStorage.removeItem('email');
    localStorage.removeItem('userId');
}



export default {
    login,
    logout,
    register,
    getAllFurniture,
    createFurniture,
    getFurniture,
    editFurniture,
    deleteFurniture,
    myFurnitures,
}