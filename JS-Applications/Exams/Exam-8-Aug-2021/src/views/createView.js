import { createResourceAsync } from "../api/data.js";
import { html } from "../lib.js";


const createTemplate = () => html`
<!-- Create Page ( Only for logged-in users ) -->
<section id="create-page" class="create">
    <form id="create-form" action="" method="">
        <fieldset>
            <legend>Add new Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" placeholder="Title">
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description" id="description" placeholder="Description"></textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" placeholder="Image">
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type">
                        <option value="Fiction">Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Add Book">
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

        [...Object.values(data)].forEach(x => {
            if (x == '') {
                throw new Error('All field are required!!!')
            }
        })

        const result = await createResourceAsync(data);
        console.log(result);
        onSuccses();
    } catch (err) {
        alert(err.message);
    }
}