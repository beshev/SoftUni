import { render, html } from '../node_modules/lit-html/lit-html.js'

let root = document.getElementById('root');

let loadButton = document.getElementById('btnLoadTowns');
loadButton.addEventListener('click', onLoad);

let townsTemplate = (towns) => html`
    <ul>
        ${towns.map(x => html`<li>${x}</li>`)}
    </ul>
`

function onLoad(ev) {
    ev.preventDefault();
    let towns = document.getElementById('towns')
        .value
        .split(',')
        .map(x => x.trim());

    render(townsTemplate(towns),root);
}


