import { getAllResourcesAsync, getArticleByCategory } from "../api/data.js";
import { html } from "../lib.js";


const homeTemplate = (jsArticle, pythonArticle, javaArticle, cSharpArticle) => html`
<section id="home-page" class="content">
    <h1>Recent Articles</h1>

    <section class="recent js">
        <h2>JavaScript</h2>
        ${jsArticle ? html`<article>
            <h3>${jsArticle.title}</h3>
            <p>${jsArticle.content}</p>
            <a href="/details/${jsArticle._id}" class="btn details-btn">Details</a>
        </article>` : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>

    <section class="recent csharp">
        <h2>C#</h2>
        ${cSharpArticle ? html`<article>
            <h3>${cSharpArticle.title}</h3>
            <p>${cSharpArticle.content}</p>
            <a href="/details/${cSharpArticle._id}" class="btn details-btn">Details</a>
        </article>` : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>

    <section class="recent java">
        <h2>Java</h2>
        ${javaArticle ? html`<article>
            <h3>${javaArticle.title}</h3>
            <p>${javaArticle.content}</p>
            <a href="/details/${javaArticle._id}" class="btn details-btn">Details</a>
        </article>` : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>

    <section class="recent python">
        <h2>Python</h2>
        ${pythonArticle ? html`<article>
            <h3>${pythonArticle.title}</h3>
            <p>${pythonArticle.content}</p>
            <a href="/details/${pythonArticle._id}" class="btn details-btn">Details</a>
        </article>` : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
</section>`;


export function setupHome() {
    return showHome;

    async function showHome() {
        const result = await getArticleByCategory();
        
        const js = result.find(a => a.category == 'JavaScript');
        const py = result.find(a => a.category == 'Python');
        const java = result.find(a => a.category == 'Java');
        const csharp = result.find(a => a.category == 'C#');

        return homeTemplate(js, py, java, csharp);
    }
}