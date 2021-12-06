import { editResourceByIdAsync, getResourceByIdAsync } from "../api/data.js";
import { html } from "../lib.js";


const editTemplate = (album) => html`
<!--Edit Page-->
<section class="editPage">
    <form id="edit-form">
        <fieldset>
            <legend>Edit Album</legend>

            <div class="container">
                <label for="name" class="vhide">Album name</label>
                <input id="name" name="name" class="name" type="text" .value=${album.name}>

                <label for="imgUrl" class="vhide">Image Url</label>
                <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" .value=${album.imgUrl}>

                <label for="price" class="vhide">Price</label>
                <input id="price" name="price" class="price" type="text" .value=${album.price}>

                <label for="releaseDate" class="vhide">Release date</label>
                <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" .value=${album.releaseDate}>

                <label for="artist" class="vhide">Artist</label>
                <input id="artist" name="artist" class="artist" type="text" .value=${album.artist}>

                <label for="genre" class="vhide">Genre</label>
                <input id="genre" name="genre" class="genre" type="text" .value=${album.genre}>

                <label for="description" class="vhide">Description</label>
                <textarea name="description" class="description" rows="10" cols="10" .value=${album.description}></textarea>

                <button class="edit-album" type="submit">Edit Album</button>

                <input type="hidden" .value=${album._id} name="albumId">
            </div>
        </fieldset>
    </form>
</section>
`;


export function setupEdit() {
    return showEdit;

    async function showEdit(context) {
        try {
            const id = context.params.id;
            const album = await getResourceByIdAsync(id);
            return editTemplate(album);
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

        await editResourceByIdAsync(data.albumId, data);

        onSuccess(data.albumId);
    } catch (err) {
        alert(err.message)
    }
}