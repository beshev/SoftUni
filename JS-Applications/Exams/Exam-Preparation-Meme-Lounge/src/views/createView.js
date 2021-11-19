import { createResource } from "../api/data.js";
import { html } from "../lib.js";


const createTemplate = () => html`
<!-- Create Meme Page ( Only for logged users ) -->
<section id="create-meme">
    <form id="create-form">
        <div class="container">
            <h1>Create Meme</h1>
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title">
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description"></textarea>
            <label for="imageUrl">Meme Image</label>
            <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
            <input type="submit" class="registerbtn button" value="Create Meme">
        </div>
    </form>
</section>
`;


export function setupCreate() {
    return showCreate;

    async function showCreate() {
        return createTemplate();
    }
}

export async function onCreate(data, onSuccses, errorBox) {
    try {

        if (data.title === '') {
            throw Error('Title is required!');
        }

        if (data.description === '') {
            throw Error('Description is required!');
        }

        if (data.imageUrl === '') {
            throw Error('ImageUrl is required!');
        }

        const result = await createResource(data);
        onSuccses();
    } catch (err) {
        const span = errorBox.querySelector('span')
        span.textContent = err.message;
        errorBox.style.display = 'block';
        setTimeout(() => errorBox.style.display = 'none', 3000);
    }
}