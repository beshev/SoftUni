import { getMyBooks } from "../api/data.js";
import authService from "../authService.js";
import { html } from "../lib.js";


const myBookTemplate = (books) => html`
<!-- My Books Page ( Only for logged-in users ) -->
<section id="my-books-page" class="my-books">
    <h1>My Books</h1>
    <!-- Display ul: with list-items for every user's books (if any) -->
    ${books.length > 0 
        ? html`
            <ul class="my-books-list">
                ${books.map(bookTamplate)}
            </ul>` 
        : html`<p class="no-books">No books in database!</p>`}
</section>
`;

const bookTamplate = (book) => html`
<li class="otherBooks">
    <h3>${book.title}</h3>
    <p>Type: ${book.type}</p>
    <p class="img"><img src=${book.imageUrl}></p>
    <a class="button" href="/details/${book._id}">Details</a>
</li>
`


export function setupMyBooks() {
    return showMyBooks;

    async function showMyBooks() {
        const userId = authService.getUserId();
        const myBooks = await getMyBooks(userId);

        return myBookTemplate(myBooks);
    }
}