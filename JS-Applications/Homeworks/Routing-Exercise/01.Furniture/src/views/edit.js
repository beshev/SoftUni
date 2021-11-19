import api from "../api/api.js";
import dom, { html } from "../dom.js";


const editTemplate = (furniture) => html`
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Edit Furniture</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form id="editForm">
            <input type="hidden" name="_id" value=${furniture._id}>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-make">Make</label>
                        <input class="form-control" id="new-make" type="text" name="make" value=${furniture.make}>
                    </div>
                    <div class="form-group has-success">
                        <label class="form-control-label" for="new-model">Model</label>
                        <input class="form-control" id="new-model" type="text" name="model" value=${furniture.model}>
                    </div>
                    <div class="form-group has-danger">
                        <label class="form-control-label" for="new-year">Year</label>
                        <input class="form-control" id="new-year" type="number" name="year" value=${furniture.year}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-description">Description</label>
                        <input class="form-control" id="new-description" type="text" name="description"
                            value=${furniture.description}>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-price">Price</label>
                        <input class="form-control" id="new-price" type="number" name="price" value=${furniture.price}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-image">Image</label>
                        <input class="form-control" id="new-image" type="text" name="img" value=${furniture.img}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-material">Material (optional)</label>
                        <input class="form-control" id="new-material" type="text" name="material"
                            value=${furniture.material}>
                    </div>
                    <input type="submit" class="btn btn-info" value="Edit" />
                </div>
            </div>
        </form>
    </div>
`

export function setupEdit() {
    return editView;

    async function editView(context) {
        const id = context.params.id;
        const furniture = await api.getFurniture(id);

        return editTemplate(furniture);
    }
}

export async function onEdit(data, onSuccess) {
    try {
        if (data.make.length < 4) {
            dom.addClassToElementById('new-make', 'is-invalid');
            throw new Error('Make must be at least 4 symbols long');
        }
        dom.removeClassFromElementById('new-make', 'is-invalid');
        dom.addClassToElementById('new-make', 'is-valid');

        if (data.model.length < 4) {
            dom.addClassToElementById('new-model', 'is-invalid');
            throw new Error('Model must be at least 4 symbols long');
        }
        dom.removeClassFromElementById('new-model', 'is-invalid');
        dom.addClassToElementById('new-model', 'is-valid');
        
        if (Number(data.year) < 1950 || Number(data.year) > 2050) {
            dom.addClassToElementById('new-year', 'is-invalid');
            throw new Error('Year must be between 1950 and 2050');
        }
        dom.removeClassFromElementById('new-year', 'is-invalid');
        dom.addClassToElementById('new-year', 'is-valid');

        if (data.description.length <= 10) {
            dom.addClassToElementById('new-description', 'is-invalid');
            throw new Error('Description must be more than 10 symbols');
        }
        dom.removeClassFromElementById('new-description', 'is-invalid');
        dom.addClassToElementById('new-description', 'is-valid');

        if (data.price === '' || Number(data.price) < 0) {
            dom.addClassToElementById('new-price', 'is-invalid');
            throw new Error('Price must be a positive number');
        }
        dom.removeClassFromElementById('new-price', 'is-invalid');
        dom.addClassToElementById('new-price', 'is-valid');

        if (data.img === '') {
            dom.addClassToElementById('new-image', 'is-invalid');
            throw new Error('Image URL is required');
        }
        dom.removeClassFromElementById('new-image', 'is-invalid');
        dom.addClassToElementById('new-image', 'is-valid');

        await api.editFurniture(data._id, JSON.stringify(data))
        onSuccess(data._id);
    } catch (err) {
        alert(err.message)
    }
}