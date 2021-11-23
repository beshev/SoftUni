import { getMyCars } from "../api/data.js";
import authService from "../authService.js";
import { html } from "../lib.js";


const myListTemplate = (myCars) => html`
<!-- My Listings Page -->
<section id="my-listings">
    <h1>My car listings</h1>
    <div class="listings">
        ${myCars.length > 0 ? html`${myCars.map(carTemplate)}` : html`<p class="no-cars">You haven't listed any cars yet.</p>`}
    </div>
</section>
`;

const carTemplate = (car) => html`
    <div class="listing">
        <div class="preview">
            <img src="${car.imageUrl}">
        </div>
        <h2>${car.brand} ${car.model}</h2>
        <div class="info">
            <div class="data-info">
                <h3>Year: ${car.year}</h3>
                <h3>Price: ${car.price} $</h3>
            </div>
            <div class="data-buttons">
                <a href="/details/${car._id}" class="button-carDetails">Details</a>
            </div>
        </div>
    </div>
`

export function setupMyList() {
    return showMyList;

    async function showMyList() {
        const myCars = await getMyCars(authService.getUserId());

        return myListTemplate(myCars);
    }
}