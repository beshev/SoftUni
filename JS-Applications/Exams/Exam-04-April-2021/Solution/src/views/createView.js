import { createResourceAsync } from "../api/data.js";
import { html } from "../lib.js";


const createTemplate = () => html`
<section id="create-page" class="content">
    <h1>Create Article</h1>
    <form id="create" action="#" method="">
        <fieldset>
            <p class="field title">
                <label for="create-title">Title:</label>
                <input type="text" id="create-title" name="title" placeholder="Enter article title">
            </p>
            <p class="field category">
                <label for="create-category">Category:</label>
                <input type="text" id="create-category" name="category" placeholder="Enter article category">
            </p>
            <p class="field">
                <label for="create-content">Content:</label>
                <textarea name="content" id="create-content"></textarea>
            </p>
            <p class="field submit">
                <input class="btn submit" type="submit" value="Create">
            </p>
        </fieldset>
    </form>
</section>
`;


export function setupCreate() {
    return showCreate;

    async function showCreate() {
        return createTemplate();
    }
}

export async function onCreate(data, onSuccses) {
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

        const result =  await createResourceAsync(data);
        console.log(result);
        onSuccses();
    } catch (err) {
        alert(err.message);
    }
}