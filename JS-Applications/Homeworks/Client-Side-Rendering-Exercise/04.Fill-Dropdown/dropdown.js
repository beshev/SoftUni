import { render, html } from "../node_modules/lit-html/lit-html.js";

renderSection();

let select = document.getElementById('menu');
let form = document.querySelector('form');
form.addEventListener('submit', addItem);


async function addItem(ev) {
    ev.preventDefault();
    let inputValue = document.getElementById('itemText').value.trim();

    if (inputValue === '') {
        return;
    }

    console.log(inputValue);
    await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
        method: 'post',
        body: JSON.stringify({ text: inputValue }),
    })

    ev.target.reset();
    renderSection();
}

async function renderSection() {
    let itemsTemplate = (items) => html`
        ${items.map(x => html`<option value="${x._id}">${x.text}</option>`)}
    `   
    let items = await fetch('http://localhost:3030/jsonstore/advanced/dropdown').then(res => res.json());
    render(itemsTemplate(Object.values(items)), select);
}