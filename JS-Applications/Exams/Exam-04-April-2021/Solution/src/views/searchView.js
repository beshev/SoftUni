import { getByTitle } from "../api/data.js";
import { html } from "../lib.js";


const searchTemplate = (articles) => html`
<section id="search-page" class="content">
    <h1>Search</h1>
    <form id="search-form">
        <p class="field search">
            <input type="text" placeholder="Search by article title" name="search" }>
        </p>
        <p class="field submit">
            <input class="btn submit" type="submit" value="Search">
        </p>
    </form>
    <div class="search-container">
        ${articles.length <= 0 ? html`<h3 class="no-articles">No matching articles</h3>` :
            articles.map(articleTemplate)}
    </div>
</section>`;

const articleTemplate = (article) => html`
<a class="article-preview" href="/details/${article._id}">
    <article>
        <h3>Topic: <span>${article.title}</span></h3>
        <p>Category: <span>${article.category}</span></p>
    </article>
</a>`;


export function setupSearch() {
    return showSearch;

    async function showSearch(context) {
        const title = context.querystring.split('=')[1];
        let articles = [];

        if (title) {
            articles = await getByTitle(title);
        }

        return searchTemplate(articles);
    }
}

export function onSearch(data,onSuccess) {
    const title = data.search;
    onSuccess(title);
}

