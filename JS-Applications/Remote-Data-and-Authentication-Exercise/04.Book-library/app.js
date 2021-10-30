let url = 'http://localhost:3030/jsonstore/collections/books/';
let tbody = document.querySelector('body table tbody');

let formTitle = document.getElementById('form-title');

let loadButton = document.getElementById('loadBooks');
loadButton.addEventListener('click', loadBooks);

let form = document.getElementById('form');

let submitButton = document.getElementById('submitBtn');
submitButton.addEventListener('click', onSubmitHandler);

let saveButton = document.getElementById('saveBtn');
saveButton.addEventListener('click', onSaveHandler);

function onSubmitHandler(e) {
    e.preventDefault();

    let [title, author] = getValuesFromForm(form);

    if (author.trim() === '' || title.trim() === '') {
        return;
    }

    let body = JSON.stringify({
        author,
        title
    })

    fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application.json' },
        body
    })
        .catch(err => console.error(err.message))

    resetForm();
}

async function loadBooks() {
    try {
        let books = await fetch(url).then(res => res.json());
        Array.from(tbody.children).map(x => x.remove());
        Object.keys(books)
            .forEach(key => {
                createTableRow(books[key].author, books[key].title, key);
            })
    } catch (error) {
        console.error(error.message);
    }
}

function createTableRow(author, title, id) {
    let tdAuthor = document.createElement('td');
    tdAuthor.textContent = author;

    let tdTitle = document.createElement('td');
    tdTitle.textContent = title;

    let editButton = document.createElement('button');
    editButton.textContent = 'Edit';
    editButton.addEventListener('click', onEditHandler)

    let deleteButton = document.createElement('button');
    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener('click', onDeleteHandler)

    let tdButton = document.createElement('td');
    tdButton.appendChild(editButton);
    tdButton.appendChild(deleteButton);

    let tr = document.createElement('tr');
    tr.appendChild(tdTitle);
    tr.appendChild(tdAuthor);
    tr.appendChild(tdButton);
    tr.setAttribute('data-book-id', id);

    tbody.appendChild(tr);
}

function onDeleteHandler(e) {
    let tr = e.target.parentElement.parentElement;

    fetch(url + tr.getAttribute('data-book-id'),{
        method: 'DELETE',
    })
        .then(() => {
            tr.remove();
            resetForm();
        })
        .catch(err => console.error(err.message));
}

function onEditHandler(e) {
    let tr = e.target.parentElement.parentElement;
    let authorInput = document.getElementById('author');
    let titleInput = document.getElementById('title');

    titleInput.value = tr.children[0].textContent;
    authorInput.value = tr.children[1].textContent;

    submitButton.classList.add('hiden');
    saveButton.classList.remove('hiden');

    form.querySelector('#hidenId').value = tr.getAttribute('data-book-id');

    formTitle.textContent = 'Edit FORM'
}

function onSaveHandler(e) {
    e.preventDefault();

    let [title, author] = getValuesFromForm(form);

    let id = document.getElementById('hidenId').value;

    let body = JSON.stringify({
        author,
        title,
    });

    fetch(url + id, {
        method: 'PUT',
        headers: { 'Content-Type': 'application.json' },
        body
    })
        .then(() => {
            resetForm();
        })
        .catch(err => console.error(err.message));
}

function getValuesFromForm(params) {
    let formData = new FormData(form);
    let author = formData.get('author');
    let title = formData.get('title');
    return [title, author];
}

function resetForm() {
    form.reset();
    formTitle.textContent = 'FORM'
    form.querySelector('#hidenId').value = '';
    saveButton.classList.add('hiden');
    submitButton.classList.remove('hiden');
}