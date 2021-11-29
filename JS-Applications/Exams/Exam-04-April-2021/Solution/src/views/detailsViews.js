import { deleteResourceByIdAsync, getResourceByIdAsync } from "../api/data.js";
import authService from "../authService.js";
import { html } from "../lib.js";


const detailsTemplate = (article, isOwner, onDelete) => html`
<section id="details-page" class="content details">
    <h1>${article.title}</h1>
    <div class="details-content">
        <strong>Published in category ${article.category}</strong>
        <p>${article.content}</p>
        <div class="buttons">
            ${isOwner ? html`
            <a @click=${onDelete} href="javascript:void(0)" class="btn delete">Delete</a>
            <a href="/edit/${article._id}" class="btn edit">Edit</a>` : ''}
            <a href="/" class="btn edit">Back</a>
        </div>
    </div>
</section>`;


export function setupDetails() {
    return showDetails;

    async function showDetails(ctx) {
        const id = ctx.params.id;
        const article = await getResourceByIdAsync(id);
        const isOwner = authService.getUserId() === article._ownerId

        return detailsTemplate(article, isOwner, onDelete);



        async function onDelete() {
            try {
                const conf = confirm('Are you sure you wanna delete this article?!!');

                if (conf) {
                    await deleteResourceByIdAsync(id);
                    ctx.page.redirect('/');
                }

            } catch (err) {
                alert(err.message);
            }
        }
    }
}