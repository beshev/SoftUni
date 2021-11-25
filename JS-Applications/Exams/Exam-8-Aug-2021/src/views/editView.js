import { editResourceByIdAsync, getResourceByIdAsync } from "../api/data.js";
import { html } from "../lib.js";


const editTemplate = (book) => html`
<!-- Edit Page ( Only for the creator )-->
<section id="edit-page" class="edit">
    <form id="edit-form" action="#" method="">
        <fieldset>
            <legend>Edit my Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" value=${book.title}>
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description"
                        id="description">${book.description}</textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" value=${book.imageUrl}>
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type" value="Fiction">
                        <option value="Fiction" selected>Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Save">
            <input type="hidden" name="bookId" value=${book._id} />
        </fieldset>
    </form>
</section>

`;


export function setupEdit() {
    return showEdit;

    async function showEdit(context) {
        try {
            const id = context.params.id;
            const book = await getResourceByIdAsync(id);

            return editTemplate(book);
        } catch (err) {
            alert(err.message);
        }
    }
}

export async function onEdit(data, onSuccess) {
    try {

        [...Object.values(data)].forEach(x => {
            if (x == '') {
                throw new Error('All field are required!!!')
            }
        })

        const result = await editResourceByIdAsync(data.bookId, data);
        
        onSuccess(data.bookId);
    } catch (err) {
        alert(err.message)
    }
}