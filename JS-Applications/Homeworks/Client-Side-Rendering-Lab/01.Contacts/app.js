import { contacts } from "./contacts.js";
import { render } from "../node_modules/lit-html/lit-html.js";
import templates from './templates/contactTemplate.js';

let contactsDiv = document.getElementById('contacts');

contacts.forEach(c => c.onDetails = onDetails.bind(null,c.id));

render(templates.contactsListTemplate(contacts),contactsDiv);

function onDetails(id) {
    let details = document.getElementById(id);

    details.style.display = 'block';
}