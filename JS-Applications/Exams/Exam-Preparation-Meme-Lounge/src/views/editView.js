import { editResourceById, getResourceById } from "../api/data.js";
import { html } from "../lib.js";


const editTemplate = (meme) => html`
<!-- Edit Meme Page ( Only for logged user and creator to this meme )-->
<section id="edit-meme">
    <form id="edit-form">
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value=${meme.title}>
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description">${meme.description}</textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${meme.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">

            <input name="memeId" .value=${meme._id} type="hidden">
        </div>
    </form>
</section>
`;


export function setupEdit() {
    return showEdit;

    async function showEdit(context) {
        try {
            const id = context.params.id;
            const meme = await getResourceById(id);
            return editTemplate(meme);
        } catch (err) {
            alert(err.message);
        }
    }
}

export async function onEdit(data, onSuccess, errorBox) {
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

        const result = await editResourceById(data.memeId, data);

        onSuccess(data.memeId);
    } catch (err) {
        const span = errorBox.querySelector('span')
        span.textContent = err.message;
        errorBox.style.display = 'block';
        setTimeout(() => errorBox.style.display = 'none', 3000);
    }
}