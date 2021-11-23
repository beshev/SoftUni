import { searchCar } from "../api/data.js";
import { html } from "../lib.js";


const searchTemplate = (cars, onSearch) => html`
<!-- Search Page -->
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button class="button-list" @click=${onSearch}>Search</button>
    </div>

    <h2>Results:</h2>
    <div class="listings">
        ${cars.length > 0 
            ? html`${cars.map(carTemplate)}` 
            : html`<p class="no-cars"> No results.</p>`}
            ${cars.Length}
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


export function setupSearch() {
    return showSearch;

    async function showSearch(context) {
        let year = context.params.year;
        let cars = [];

        if (year) {
            year = Number(year);
            cars = await searchCar(year)
        }

        console.log(cars);

        return searchTemplate(cars, onSearch.bind(null,context.page));
    }
}

async function onSearch(page) {
    const year = document.getElementById('search-input').value;
    page.redirect(`/search-cars/${year}`)
}