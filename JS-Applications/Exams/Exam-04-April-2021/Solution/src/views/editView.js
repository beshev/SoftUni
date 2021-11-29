import { editResourceByIdAsync, getResourceByIdAsync } from "../api/data.js";
import { html } from "../lib.js";


const editTemplate = (article) => html`
<section id="edit-page" class="content">
    <h1>Edit Article</h1>
    <form id="edit" action="#" method="">
        <fieldset>
            <p class="field title">
                <label for="title">Title:</label>
                <input type="text" name="title" id="title" placeholder="Enter article title" .value=${article.title} />
            </p>
            <p class="field category">
                <label for="category">Category:</label>
                <input type="text" name="category" id="category" placeholder="Enter article category"
                    .value=${article.category} />
            </p>
            <p class="field">
                <label for="content">Content:</label>
                <textarea name="content" id="content" .value=${article.content}></textarea>
            </p>
            <p class="field submit">
                <input class="btn submit" type="submit" value="Save Changes">
            </p>
            <input type="hidden" name="articleId" value=${article._id} />
        </fieldset>
    </form>
</section>`;


export function setupEdit() {
    return showEdit;

    async function showEdit(context) {
        try {
            const id = context.params.id;
            const article = await getResourceByIdAsync(id);
            return editTemplate(article);
        } catch (err) {
            alert(err.message);
        }
    }
}

export async function onEdit(data, onSuccess) {
    try {
        const categories = [
            'JavaScript',
            'C#',
            'Java',
            'Python',
        ];

        [...Object.values(data)].forEach(x => {
            if (x == '') {
                throw new Error('All fields are required!!')
            }
        })

        if (!categories.includes(data.category)) {
            throw new Error('This category don\'t exist!')
        }



        editResourceByIdAsync(data.articleId, data);

        onSuccess(data.articleId);
    } catch (err) {
        alert(err.message)
    }
}