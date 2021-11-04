// import detailsModule from './details.js';

async function sendLike(movieId) {
    await fetch('http://localhost:3030/data/likes', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('token'),
        },
        body: JSON.stringify({
            movieId
        })
    });
}

async function getLikesForMovie(movieId) {
    let respone = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22&distinct=_ownerId&count`);
    let likes = await respone.json();

    return likes;
}

async function isUserLike(movieId) {
    let userId = sessionStorage.getItem('userId');
    let response = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${userId}%22`);

    let data = await response.json();

    return data.length !== 0;
}

export default {
    sendLike,
    getLikesForMovie,
    isUserLike,
}