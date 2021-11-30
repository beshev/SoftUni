import { editResourceByIdAsync, getResourceByIdAsync } from "../api/data.js";
import { html } from "../lib.js";


const editTemplate = (pet) => html`
<section id="edit-page" class="edit">
    <form id="edit-form" action="#" method="">
        <fieldset>
            <legend>Edit my Pet</legend>
            <p class="field">
                <label for="name">Name</label>
                <span class="input">
                    <input type="text" name="name" id="name" .value=${pet.name}>
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description"
                        id="description" .value=${pet.description}></textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" .value=${pet.imageUrl}>
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type" .value=${pet.type}>
                        <option value="cat">Cat</option>
                        <option value="dog" selected>Dog</option>
                        <option value="parrot">Parrot</option>
                        <option value="reptile">Reptile</option>
                        <option value="other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Save">
            <input type="hidden" .value=${pet._id} name="petId">
        </fieldset>
    </form>
</section>
`;


export function setupEdit() {
    return showEdit;

    async function showEdit(context) {
        try {
            const id = context.params.id;
            const pet = await getResourceByIdAsync(id);
            
            return editTemplate(pet);
        } catch (err) {
            alert(err.message);
        }
    }
}

export async function onEdit(data, onSuccess) {
    try {

        [...Object.values(data)].forEach(x => {
            if (x == '') {
                throw new Error('All fields are required!!')
            }
        })

        await editResourceByIdAsync(data.petId, data);

        onSuccess(data.petId);
    } catch (err) {
        alert(err.message)
    }
}