window.addEventListener('load', solve);

function solve() {
    let addButton = document.getElementById('add-btn');
    addButton.addEventListener('click', onAdd);

        console.log(this);
    function onAdd(event) {
        event.preventDefault();
        let hits = document.querySelector('#all-hits div');
        let genreInput = document.getElementById('genre');
        let nameInput = document.getElementById('name');
        let authorInput = document.getElementById('author');
        let dateInput = document.getElementById('date');

        console.log(this);

        let genre = genreInput.value;
        let name = nameInput.value;
        let author = authorInput.value;
        let date = dateInput.value;

        if (genre.trim() === '' || name.trim() === '' || author.trim() === '' || date.trim() === '') {
            return;
        }

        let saveButton = e('button', { class: 'save-btn' }, 'Save song');
        saveButton.addEventListener('click', onSave);
        let likeButton = e('button', { class: 'like-btn' }, 'Like song');
        likeButton.addEventListener('click', onLike);

        let deleteButton = e('button', { class: 'delete-btn' }, 'Delete');
        deleteButton.addEventListener('click', onDelete);

        let img = document.createElement('img');
        img.src = './static/img/img.png';

        let div = e('div', { class: 'hits-info' },
            img,
            e('h2', {}, `Genre: ${genre}`),
            e('h2', {}, `Name: ${name}`),
            e('h2', {}, `Author: ${author}`),
            e('h3', {}, `Date: ${date}`),
            saveButton,
            likeButton,
            deleteButton,
        );

        hits.appendChild(div);

        genreInput.value = '';
        nameInput.value = '';
        authorInput.value = '';
        dateInput.value = '';
    }

    function onSave(e) {
        let saveSongs = document.querySelector('#saved-hits div');
        let parent = e.target.parentElement;
        e.target.nextSibling.remove();
        e.target.remove();
        saveSongs.appendChild(parent);
    }

    function onLike(e) {
        let likes = document.querySelector('#total-likes div p');

        let [content, likeNumber] = likes.textContent.split(':');
        likeNumber = Number(likeNumber.trim()) + 1;
        likes.textContent = `${content}: ${likeNumber}`
        e.target.disabled = true;
    }

    function onDelete(e) {
        e.target.parentElement.remove();
    }

    function e(type, attr, ...content) {
        const element = document.createElement(type);

        for (const prop in attr) {
            if (prop === 'class') {
                element.classList.add(attr[prop])
            } else {
                element.setAttribute(prop, attr[prop]);
            }
        }

        for (let item of content) {
            if (typeof item == 'string' || typeof item == 'number') {
                item = document.createTextNode(item);
            }

            element.appendChild(item);
        }

        return element;
    }
}