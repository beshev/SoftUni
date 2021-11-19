import { loadHomePage } from "./app.js";

export async function deleteMovie(targetId) {
    await fetch('http://localhost:3030/data/movies/' + targetId,{
        method: 'DELETE',
        headers: {'X-Authorization': sessionStorage.getItem('token')}
    })

    loadHomePage();
}