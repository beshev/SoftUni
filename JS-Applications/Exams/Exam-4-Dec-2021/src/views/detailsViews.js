import { deleteResourceByIdAsync, getResourceByIdAsync } from "../api/data.js";
import authService from "../authService.js";
import { html } from "../lib.js";


const detailsTemplate = (album, isOwner, onDelete) => html`
<!--Details Page-->
<section id="detailsPage">
    <div class="wrapper">
        <div class="albumCover">
            <img src=${album.imgUrl}>
        </div>
        <div class="albumInfo">
            <div class="albumText">

                <h1>Name: ${album.name}</h1>
                <h3>Artist: ${album.artist}</h3>
                <h4>Genre: ${album.genre}</h4>
                <h4>Price: $${album.price}</h4>
                <h4>Date: ${album.releaseDate}</h4>
                <p>Description: ${album.description}</p>
            </div>

            ${isOwner 
                ? html`
                <!-- Only for registered user and creator of the album-->
                <div class="actionBtn">
                    <a href="/edit/${album._id}" class="edit">Edit</a>
                    <a href="javascript:void(0)" class="remove" @click=${onDelete}>Delete</a>
                </div>`
                : null}
            
        </div>
    </div>
</section>
`;


export function setupDetails() {
    return showDetails;

    async function showDetails(context) {
        const id = context.params.id;
        const album = await getResourceByIdAsync(id);
        const isOwner = authService.getUserId() === album._ownerId;

        return detailsTemplate(album, isOwner, onDelete);


        
        async function onDelete() {
            try {
                const confirm = window.confirm('Are you sure you wanna delete this album!?!')

                if (confirm) {
                    await deleteResourceByIdAsync(id);
                    context.page.redirect('/catalog');
                }
            } catch (err) {
                alert(err.message);
            }
        }
    }
}