import { html, render } from '../node_modules/lit-html/lit-html.js';
let body = document.querySelector('body');
render(renderBody(), body);

let formDiv = document.querySelector('#form');
render(createFormTemplate(), formDiv);

let loadButton = document.getElementById('loadBooks');
loadButton.addEventListener('click', loadBooks);

let tableBody = document.querySelector('tbody[data-table-body="body"]')


async function loadBooks() {
    let books = await getBooks();
    render(html`${Object.keys(books).map(k => tableRowTemplate(k,books[k]))}`, tableBody);
    render(html`${createFormTemplate()}`, formDiv);
}

async function getBooks() {
    let response = await fetch('http://localhost:3030/jsonstore/collections/books');
    let data = await response.json();

    return data;
}

function renderBody() {
    return html`
        ${tableTemplate()}
        ${html`<div id="form"></div>`}
    `
}

function tableTemplate() {
    return html`
        <button id="loadBooks">LOAD ALL BOOKS</button>
        <table>
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Author</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody data-table-body="body">
        
            </tbody>
        </table>
    `
}

function createFormTemplate() {
    return html`
        <form id="add-form" @submit='${onSubmit.bind(null, 'post', '')}'>
            <h3>Add book</h3>
            <label>TITLE</label>
            <input type="text" name="title" placeholder="Title...">
            <label>AUTHOR</label>
            <input type="text" name="author" placeholder="Author...">
            <input type="submit" value="Submit">
        </form>
    `
}

async function onSubmit(method, bookId, ev) {
    ev.preventDefault();
    let formData = new FormData(ev.target);

    let body = [...formData.entries()].reduce((a, [k, v]) => Object.assign(a, { [k]: v.trim() }), {})

    if (body.author == '' || body.title == '') {
        return;
    }

    await fetch('http://localhost:3030/jsonstore/collections/books/' + bookId, {
        method: method,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(body),
    });

    ev.target.reset();
    loadBooks();
}

function editFormTemplate(bookId,title,author) {
    return html`
        <form id="edit-form" @submit='${onSubmit.bind(null, 'put', bookId)}'>
            <input type="hidden" name="id">
            <h3>Edit book</h3>
            <label>TITLE</label>
            <input type="text" name="title" placeholder="Title..." value="${title}">
            <label>AUTHOR</label>
            <input type="text" name="author" placeholder="Author..." value="${author}">
            <input type="submit" value="Save">
        </form>
    `
}

function tableRowTemplate(id, book) {
    return html`
        <tr>
            <td data-title="title">${book.title}</td>
            <td data-title="author">${book.author}</td>
            <td>
                <button @click="${onEdit}" data-id="${id}">Edit</button>
                <button @click="">Delete</button>
            </td>
        </tr>
    `
}

function onEdit(ev) {
    let id = ev.target.getAttribute('data-id');
    let title = ev.target.parentElement.parentElement.querySelector('[data-title="title"]').textContent;
    let author = ev.target.parentElement.parentElement.querySelector('[data-title="author"]').textContent;

    render(editFormTemplate(id,title,author),formDiv);
}