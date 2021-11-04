import { e } from './dom.js'
import { deleteMovie } from './delete.js';
import editModule from './edit.js';
import likeModule from './like.js';
import like from './like.js';

let main;
let section;
let baseUrl = 'http://localhost:3030/data/movies/';
let targetId;
let isUserLike;

function setDetails(tagName, targetSection) {
    main = tagName;
    section = targetSection;
}

async function showDetails(id) {
    targetId = id;
    isUserLike = await likeModule.isUserLike(targetId);

    let detailsDiv = section.querySelector('div[data-details="details"]');
    detailsDiv.innerHTML = '';

    detailsDiv.appendChild(await createDetailsElement(await getMovie()));

    main.innerHTML = '';
    main.appendChild(section);
}

async function getMovie() {
    let respone = await fetch(baseUrl + targetId);
    let data = await respone.json();

    return data;
}

async function createDetailsElement(movie) {
    let fragment = document.createDocumentFragment();

    let h1 = e('h1', {}, `Movie title: ${movie.title}`);
    let divImg = e('div', { class: "col-md-8" });
    let img = e('img', { class: 'img-thumbnail', src: movie.img, alt: 'Movie' });
    divImg.appendChild(img);

    let deleteA = e('a', { class: "btn btn-danger", href: "#" }, 'Delete');
    deleteA.style.display = sessionStorage.getItem('userId') != movie._ownerId ? 'none' : 'inline';
    deleteA.addEventListener('click', () => deleteMovie(movie._id));

    let editA = e('a', { class: "btn btn-warning", href: "#" }, 'Edit');
    editA.style.display = sessionStorage.getItem('userId') != movie._ownerId ? 'none' : 'inline';
    editA.addEventListener('click', (e) => editModule.showEdit(movie));

    let likeA;
    if (!isUserLike) {
        likeA = e('a', { class: "btn btn-primary", href: "#" }, 'Like');
        likeA.style.display = sessionStorage.getItem('userId') == movie._ownerId ? 'none' : 'inline';
        likeA.addEventListener('click', onLike);
    } else {
        let likes = await likeModule.getLikesForMovie(targetId);
        likeA = e('span', { class: "enrolled-span" }, `Liked ${likes}`);
    }

    let div = e('div', { class: "col-md-4 text-center" },
        e('h3', { class: "my-3" }, 'Movie Description'),
        e('p', {}, movie.description),
        deleteA,
        editA,
        likeA
    )

    fragment.appendChild(h1);
    fragment.appendChild(divImg);
    fragment.appendChild(div);

    return fragment;
}

async function onLike(ev) {
    await likeModule.sendLike(targetId);

    let likes = await likeModule.getLikesForMovie(targetId);
    let liked = e('span', { class: "enrolled-span" }, `Liked ${likes}`);

    ev.target.replaceWith(liked);
}

export default {
    setDetails,
    showDetails,
}