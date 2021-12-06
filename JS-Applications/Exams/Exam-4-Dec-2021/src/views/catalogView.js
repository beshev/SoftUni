import { getAllResourcesAsync } from "../api/data.js";
import authService from "../authService.js";
import { html } from "../lib.js";


const catalogTemplate = (albums = [], isLogin) => html`
<!--Catalog-->
<section id="catalogPage">
    <h1>All Albums</h1>
    ${albums.length > 0 
    ? albums.map(x => albumTemplate(x, isLogin))
    : html`<p>No Albums in Catalog!</p>`}
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
</div>
`

export function setupCatalog() {
    return showCatalog;

    async function showCatalog() {
        const albums = await getAllResourcesAsync();
        const isLogin = authService.getToken() !== null;

        return catalogTemplate(albums, isLogin);
    }
}