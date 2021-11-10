import { html } from "../../node_modules/lit-html/lit-html.js";

let contactTemplate = (contact) => html`
    <div class="contact card">
        <div>
            <i class="far fa-user-circle gravatar"></i>
        </div>
        <div class="info">
            <h2>Name: ${contact.name}</h2>
            <button class="detailsBtn" @click=${contact.onDetails}>Details</button>
            <div class="details" id="${contact.id}">
                <p>Phone number: ${contact.phoneNumber}</p>
                <p>Email: ${contact.email}</p>
            </div>
        </div>
    </div>
`;

let contactsListTemplate = (contacts) => html`
    ${contacts.map(x => contactTemplate(x))}
`

export default {
    contactTemplate,
    contactsListTemplate
};