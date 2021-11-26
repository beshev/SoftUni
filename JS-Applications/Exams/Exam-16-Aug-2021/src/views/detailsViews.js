import { addComment, deleteResourceByIdAsync, getCommentsForGame, getResourceByIdAsync, getThreeMostGames } from "../api/data.js";
import authService from "../authService.js";
import { html } from "../lib.js";


const detailsTemplate = (game, comments = [],isOwner, isUser,onDelete) => html`
<!--Details Page-->
<section id="game-details">
    <h1>Game Details</h1>
    <div class="info-section">

        <div class="game-header">
            <img class="game-img" src=${game.imageUrl} />
            <h1>${game.title}</h1>
            <span class="levels">MaxLevel: ${game.maxLevel}</span>
            <p class="type">${game.category}</p>
        </div>

        <p class="text">${game.summary}</p>

        <!-- Bonus ( for Guests and Users ) -->
        <div class="details-comments">
            <h2>Comments:</h2>
            <ul>
                ${comments.length > 0 
                    ? comments.map(commentTemplate)
                    : html`<p class="no-comment">No comments.</p>`}
                <!-- list all comments for current game (If any) -->
            </ul>
            <!-- Display paragraph: If there are no games in the database -->
            
        </div>

        ${isOwner 
            ? html`
            <div class="buttons">
                <a href="/edit/${game._id}" class="button">Edit</a>
                <a href="javascript:void(0)" class="button" @click=${onDelete}>Delete</a>
            </div>`
            : null}
        <!-- Edit/Delete buttons ( Only for creator of this game )  -->
        
    </div>

    <!-- Bonus -->
    <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
   
    ${isUser
        ? html`
         <article class="create-comment">
            <label>Add new comment:</label>
            <form class="form" id="comment-form">
                <textarea name="comment" placeholder="Comment......"></textarea>
                <input class="btn submit" type="submit" value="Add Comment">
                <input type="hidden" name="gameId" .value=${game._id}>
            </form>
        </article>
        ` 
        : null}

</section>
`;

const commentTemplate = (comment) => html`
<li class="comment">
    <p>Content: ${comment.comment}</p>
</li>
`

let page;

export function setupDetails() {
    return showDetails;

    async function showDetails(context) {
        page = context.page;
        const id = context.params.id;

        const [game,comments] = await Promise.all([
            getResourceByIdAsync(id),
            getCommentsForGame(id)
        ])

        const isOwner = authService.getUserId() === game._ownerId;
        const isUser = !isOwner && authService.getToken() !== null;

        return detailsTemplate(game,comments, isOwner, isUser,onDelete);

        async function onDelete() {
            try {
                const conf = confirm('Are you sure you wanna delete this game?!');
                
                if (conf) {
                    deleteResourceByIdAsync(id);
                    context.page.redirect('/');  
                }
               
            } catch (err) {
                alert(err.message);
            }
        }
    }
}

export async function onComment(data, onSuccess) {
    addComment(data);
    onSuccess(data.gameId);
}
