import { editResourceByIdAsync, getResourceByIdAsync } from "../api/data.js";
import { html } from "../lib.js";


const editTemplate = (car) => html`
<!-- Edit Listing Page -->
<section id="edit-listing">
    <div class="container">

        <form id="edit-form">
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" value=${car.brand}>

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" value=${car.model}>

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" value=${car.description}>

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" value=${car.year}>

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" value=${car.imageUrl}>

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" value=${car.price}>

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
            <input type="hidden" name="carId" value=${car._id}>
        </form>
    </div>
</section>
`;


export function setupEdit() {
    return showEdit;

    async function showEdit(context) {
        try {
            const id = context.params.id;
            const car = await getResourceByIdAsync(id);
            return editTemplate(car);
        } catch (err) {
            alert(err.message);
        }
    }
}

export async function onEdit(data, onSuccess) {
    try {
        if (data.brand === '' || data.model === '' || data.description === '' || data.year === '' || data.imageUrl === '' || data.price === '') {
            alert('All fields are required!!');
            return;
        }

        if (data.price < 0 || data.year < 0) {
            alert('Year and price must me positive numbers!!');
            return;
        }

        data.price = Number(data.price);
        data.year = Number(data.year);

        const result = await editResourceByIdAsync(data.carId, data);

        onSuccess(data.carId);
    } catch (err) {
        alert(err.message)
    }
}