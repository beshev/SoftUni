import { e } from './dom.js'
import detailsModule from './details.js'

let main;
let section;
let baseUrl = 'http://localhost:3030/data/movies/';

function setMovie(tagName, targetSection) {
    main = tagName;
    section = targetSection;
}

async function showMovies() {
    let movieDiv = section.querySelector('div[data-movie="movieDiv"]');
    movieDiv.innerHTML = '';

    let movies = await getMovies();

    let cards = movies.map(createMovieElement);

    movieDiv.append(...cards);
    main.appendChild(section);
}

function createMovieElement(movie) {
    let button = e('button', { type: "button", class: "btn btn-info" },'Details');
    button.addEventListener('click', () => detailsModule.showDetails(movie._id));
   
    let a = e('a', {},button);

    if (sessionStorage.getItem('token') === null) {
        a.style.display = 'none';
    }
    let movieElement = e('div', { class: 'card mb-4' },
        e('img', { class: 'card-img-top', src: movie.img, alt: 'Card image cap', width: "400" }),
        e('div', { class: 'card-body' },
            e('h4', { class: 'card-title' }, movie.title)
        ),
        e('div', { class: "card-footer" },
            a,
        )
    )
    return movieElement;
}

async function getMovies() {
    let response = await fetch(baseUrl);
    let data = await response.json();
    return data;
}


export default {
    showMovies,
    setMovie,
}