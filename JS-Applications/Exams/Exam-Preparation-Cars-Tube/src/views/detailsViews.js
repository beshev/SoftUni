import { deleteResourceByIdAsync, getResourceByIdAsync } from "../api/data.js";
import authService from "../authService.js";
import { html } from "../lib.js";


const detailsTemplate = (car, isOwner,onDelete) => html`
<!-- Listing Details Page -->
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src="${car.imageUrl}">
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${car.brand}</li>
            <li><span>Model:</span>${car.model}</li>
            <li><span>Year:</span>${car.year}</li>
            <li><span>Price:</span>${car.price}$</li>
        </ul>

        <p class="description-para">${car.description}</p>

        ${isOwner 
        ? html`
            <div class="listings-buttons">
                <a href="/edit/${car._id}" class="button-list">Edit</a>
                <a href="javascript:void(0)" class="button-list" @click=${onDelete}>Delete</a>
            </div>
        ` : null}
    </div>
</section>
`;


export function setupDetails() {
    return showDetails;

    async function showDetails(context) {
        const id = context.params.id;
        const car = await getResourceByIdAsync(id);
        const isOwner = authService.getUserId() === car._ownerId;

        return detailsTemplate(car, isOwner,onDelete.bind(null,context,id));
    }
}


async function onDelete (context,carId) {
    const comfirm = window.confirm('Are you sure you wanna delete this car?!');

    if (comfirm) {
        await deleteResourceByIdAsync(carId)
        context.page.redirect('/all-cars');
    }
}