import { deleteResourceById, getResourceById } from "../api/data.js";
import { html } from "../lib.js";
import auth from '../auth.js'


const detailsTemplate = (meme, isOwner, context) => html`
<!-- Details Meme Page (for guests and logged users) -->
<section id="meme-details">
    <h1>
        Meme Title: ${meme.title}
    </h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src=${meme.imageUrl}>
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>
                ${meme.description}
            </p>
            ${isOwner ? html`
            <!-- Buttons Edit/Delete should be displayed only for creator of this meme  -->
            <a class="button warning" href="/edit/${meme._id}">Edit</a>
            <button class="button danger" @click=${onDelete.bind(null, meme._id, context)}>Delete</button>
            ` : ''}
        </div>
    </div>
</section>
`;


export function setupDetails() {
    return showDetails;

    async function showDetails(context) {
        const meme = await getResourceById(context.params.id);
        const isOwner = auth.getUserId() == meme._ownerId;

        return detailsTemplate(meme, isOwner, context);
    }
}


async function onDelete(id, context) {
    try {
        const confirm = window.confirm('Are you sure wanna delete this meme!?');

        if (confirm) {
            await deleteResourceById(id);
            context.page.redirect('/allMeme');
        }
    } catch (err) {
        alert(err.message);
    }
}