import { html } from "../dom.js";
import api from "../api/api.js";

const detailsTemplate = (furniture, isOwner) => html`
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src="${furniture.img}" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>${furniture.make}</span></p>
                <p>Model: <span>${furniture.model}</span></p>
                <p>Year: <span>${furniture.year}</span></p>
                <p>Description: <span>${furniture.description}</span></p>
                <p>Price: <span>${furniture.price}</span></p>
                <p>Material: <span>${furniture.material}</span></p>
                <div>
                    ${isOwner ? buttonsTemplate(furniture._id) : ''}
                </div>
            </div>
        </div>
    </div>
`

const buttonsTemplate = (id) => html`
<a href="/edit/${id}" class="btn btn-info">Edit</a>
<a href="/delete/${id}" class="btn btn-red">Delete</a>
`

export function setupDetails() {
    return detailsView;

    async function detailsView(context) {
        const id = context.params.id;
        const furniture = await api.getFurniture(id);
        const isOwner = localStorage.getItem('userId') === furniture._ownerId;

        return detailsTemplate(furniture, isOwner);
    }
}


export async function deleteF(context) {
    const confirm = window.confirm('Are you sure wanna delete this Furniture?');

    if (confirm) {
        const id = context.params.id;
        await api.deleteFurniture(id);

        context.page.redirect('/');
    }
}