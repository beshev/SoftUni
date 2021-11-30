import { getMyPets } from "../api/data.js";
import authService from "../authService.js";
import { html } from "../lib.js";


const myPetsTemplate = (myPets = []) => html`
<section id="my-pets-page" class="my-pets">
    <h1>My Pets</h1>
    ${myPets.length > 0 
        ? html`<ul class="my-pets-list">${myPets.map(petTemplate)}</ul>`
        : html`<p class="no-pets">No pets in database!</p>`}
</section>
`;

const petTemplate = (pet) => html`
<li class="otherPet">
    <h3>Name: ${pet.name}</h3>
    <p>Type: ${pet.type}</p>
    <p class="img"><img src=${pet.imageUrl}></p>
    <a class="button" href="/details/${pet._id}">Details</a>
</li>
`

export function setupMyPets() {
    return showMyPets;

    async function showMyPets() {
        const userId = authService.getUserId();
        const myPets = await getMyPets(userId);

        return myPetsTemplate(myPets);
    }
}