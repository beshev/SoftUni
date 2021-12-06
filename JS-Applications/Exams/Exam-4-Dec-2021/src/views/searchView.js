import { searchAlbum } from "../api/data.js";
import authService from "../authService.js";
import { html } from "../lib.js";


const searchTemplate = (albums, isLogin, onSearch) => html`
<!--Search Page-->
<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
        <button class="button-list" @click=${onSearch}>Search</button>
    </div>

    <h2>Results:</h2>

    <!--Show after click Search button-->
    <div class="search-result">
        <!--If have matches-->
        ${albums.length > 0 
            ? albums.map(x => albumTemplate(x, isLogin))
            : html` <p class="no-result">No result.</p>`}
    </div>
</section>
`;

const albumTemplate = (album, isLogin) => html`
<div class="card-box">
    <img src=${album.imgUrl}>
    <div>
        <div class="text-center">
            <p class="name">Name: ${album.name}</p>
            <p class="artist">Artist: ${album.artist}</p>
            <p class="genre">Genre: ${album.genre}</p>
            <p class="price">Price: $${album.price}</p>
            <p class="date">Release Date: ${album.releaseDate}</p>
        </div>
        ${isLogin 
            ?  html`
            <div class="btn-group">
                <a href="/details/${album._id}" id="details">Details</a>
            </div>
            `
            : null}
        
    </div>
</div>`


export function setupSearch() {
    return showSearch;

    async function showSearch(context) {
        const albumName = context.querystring.split('=')[1]
        let albums = []

        if (albumName) {
            albums = await searchAlbum(albumName);
        }

        const isLogin = authService.getToken() !== null;
        return searchTemplate(albums, isLogin, onSearch);


        async function onSearch(e) {
            const input = e.target.parentElement.querySelector('input');
            const searchValue = input.value;

            if(searchValue.trim() === '') {
                alert('Search field is required!!');
                return;
            }

            input.value = '';
            context.page.redirect(`/search?name=${searchValue}`)
        }
    }
}