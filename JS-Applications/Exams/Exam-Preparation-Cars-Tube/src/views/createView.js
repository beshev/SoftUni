import { createResourceAsync } from "../api/data.js";
import { html } from "../lib.js";


const createTemplate = () => html`
<!-- Create Listing Page -->
<section id="create-listing">
    <div class="container">
        <form id="create-form">
            <h1>Create Car Listing</h1>
            <p>Please fill in this form to create an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price">

            <hr>
            <input type="submit" class="registerbtn" value="Create Listing">
        </form>
    </div>
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

        const result = await createResourceAsync(data);
        console.log(result);
        onSuccses();
    } catch (err) {
        alert(err.message);
    }
}