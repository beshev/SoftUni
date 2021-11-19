import { html, render } from "../node_modules/lit-html/lit-html.js";
import { cats } from "./catSeeder.js";

let allCatsSection = document.getElementById('allCats');

let catTemplate = (cat) => html`
    <li>
        <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
        <div class="info">
            <button class="showBtn" @click=${onDetails.bind(null,cat.id)}>Show status code</button>
            <div class="status" style="display: none" id="${cat.id}">
                <h4>Status Code: ${cat.statusCode}</h4>
                <p>${cat.statusMessage}</p>
            </div>
        </div>
    </li>
`

let catsListTemplate = (cats) => html`
    <ul>
        ${cats.map(cat => catTemplate(cat))}
    </ul>
`

function onDetails(catId,e) {
    let buttonText = e.target.textContent;
    let statusDiv = document.getElementById(catId);

    if (buttonText == 'Show status code') {
        statusDiv.style.display = 'block';
        buttonText = 'Hide status code';
    } else {
        statusDiv.style.display = 'none';
        buttonText = 'Show status code';
    }

    e.target.textContent = buttonText;
}

render(catsListTemplate(cats),allCatsSection);