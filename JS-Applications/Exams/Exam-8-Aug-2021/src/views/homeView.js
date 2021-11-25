import { getAllResourcesAsync } from "../api/data.js";
import { html } from "../lib.js";


const homeTemplate = (books = []) => html`
<!-- Dashboard Page ( for Guests and Users ) -->
<section id="dashboard-page" class="dashboard">
    <h1>Dashboard</h1>
    <!-- Display ul: with list-items for All books (If any) -->
    ${books.length > 0 
        ? html`
            <ul class="other-books-list">
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


export function setupHome() {
    return showHome;

    async function showHome() {
        const books = await getAllResourcesAsync();

        return homeTemplate(books);
    }
}