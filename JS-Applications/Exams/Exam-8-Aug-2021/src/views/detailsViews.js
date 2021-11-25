import { deleteResourceByIdAsync, getBookLikes, getResourceByIdAsync, getUserLikesForBook, sendLikeToBook } from "../api/data.js";
import authService from "../authService.js";
import { html } from "../lib.js";


const detailsTemplate = (detailsInfo) => html`
<!-- Details Page ( for Guests and Users ) -->
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${detailsInfo.book.title}</h3>
        <p class="type">Type: ${detailsInfo.book.type}</p>
        <p class="img"><img src=${detailsInfo.book.imageUrl}></p>
        <div class="actions">
            ${detailsInfo.isOwner 
                ? html`<a class="button" href="/edit/${detailsInfo.book._id}">Edit</a>
                    <a class="button" href="javascript:void(0)" @click=${detailsInfo.onDelete}>Delete</a>`
                  :null}
            <!-- Edit/Delete buttons ( Only for creator of this book )  -->
            

            <!-- Bonus -->
            <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
            ${detailsInfo.isUser && !detailsInfo.isUserLikeBook 
                ? html`<a class="button" href="javascript:void(0)" @click=${detailsInfo.onLike}>Like</a>` 
                : null}
            
            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${detailsInfo.bookLikesCount}</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${detailsInfo.book.description}</p>
    </div>
</section>
`;


export function setupDetails() {
    return showDetails;

    async function showDetails(context) {
        const id = context.params.id;
        const book = await getResourceByIdAsync(id);
        const isOwner = authService.getUserId() == book._ownerId;
        const isUser = authService.getToken() !== null && !isOwner;
        const bookLikesCount = await getBookLikes(id);

        let	 userLikeCount = 0;
        if (isUser) {
            userLikeCount = await getUserLikesForBook(id, authService.getUserId())
        }

        const isUserLikeBook = userLikeCount > 0

        const detailsInfo = {
            book, 
            isOwner,
            isUser,
            bookLikesCount,
            isUserLikeBook,
            onDelete: onDelete.bind(null,id,context.page),
            onLike: onLike.bind(null,id,context.page)
        }

        return detailsTemplate(detailsInfo);
    }
}


async function onDelete(bookId,page) {
    try {
        const confirm = window.confirm('Are you sure you wanna delete this book?!')

        if (confirm) {
            await deleteResourceByIdAsync(bookId);
            page.redirect('/');
        }

    } catch (err) {
        alert(err.message);
    }
}

async function onLike(bookId,page) {
    await sendLikeToBook(bookId);
    page.redirect(`/details/${bookId}`);
}


