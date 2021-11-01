import { e } from './dom.js';
import logControl from './logControl.js';
import app from './app.js';

async function getRecepies() {
    let url = 'http://localhost:3030/data/recipes';
    let response = await fetch(url);
    let recepies = await response.json();

    return Object.values(recepies);
}

function createRecipeInfo(recipeInfo) {
    let recipe = e('article', {},
        e('h2', {}, `${recipeInfo.name}`),
        e('div', { class: 'band' },
            e('div', { class: 'thumb' },
                e('img', { src: `${recipeInfo.img}` }, '')
            ),
            e('div', { class: 'ingredients' },
                e('h3', {}, 'Ingredients:'),
                e('ul', {}, recipeInfo.ingredients.map(x => e('li', {}, x))),
            )
        ),
        e('div', { class: 'description' },
            e('h3', {}, 'Preparation:'),
            recipeInfo.steps.map(x => e('p', {}, x))
        ));
    recipe.classList.add('recipeInfo');
    if (recipeInfo._ownerId === logControl.getUserId()) {
        let editButton = e('button', {}, '✎ Edit');
        editButton.addEventListener('click', edit);
        let deleteButton = e('button', {}, '✖ Delete');
        deleteButton.addEventListener('click', onDelete.bind());

        let div = e('div', { class: 'controls' },
            editButton,
            deleteButton,
        )

        recipe.appendChild(div);
        recipe.setAttribute('data-id', recipeInfo._id);
    }

    return recipe;
}

function edit(e) {
    let editForm = app.document.getElementById('edit-form');
    let article = e.target.parentElement.parentElement;
    editForm.addEventListener('submit', updateRecipe.bind(null, article.getAttribute('data-id')));

    let nameInput = editForm.querySelector('input[name="name"]');
    let imgInput = editForm.querySelector('input[name="img"]');
    let ingredientsTextArea = editForm.querySelector('textarea[name="ingredients"]');
    let stepsTextarea = editForm.querySelector('textarea[name="steps"]');

    let title = article.querySelector('h2').textContent;
    let imgSrc = article.querySelector('img').src;
    let ingredients = Array.from(article.querySelectorAll('div.ingredients ul li')).map(x => x.textContent);
    let description = Array.from(article.querySelectorAll('div.description p')).map(x => x.textContent);

    nameInput.value = title;
    imgInput.value = imgSrc;
    ingredientsTextArea.textContent = ingredients.join('\r\n');
    stepsTextarea.textContent = description.join('\r\n');

    let edit = document.getElementById('edit-article');
    edit.classList.remove('hidden');

    article.replaceWith(edit);
}

function updateRecipe(recipeId, event) {
    event.preventDefault();

    let formData = new FormData(event.target);
    let name = formData.get('name');
    let img = formData.get('img');
    let ingredients = formData.get('ingredients').split('\r\n').filter(x => x !== '');
    let steps = formData.get('steps').split('\r\n').filter(x => x !== '');

    let body = {
        name,
        img,
        ingredients,
        steps
    };

    fetch('http://localhost:3030/data/recipes/' + recipeId, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('token'),
        },
        body: JSON.stringify(body)
    })
        .then(res => res.json())
        .then(data => {
            if (data) {
                app.recipeInfo(recipeId);
            } else {
                throw new Error(data.message);
            }
        })
        .catch(err => alert(err.message));
}

function loadRecepies(recipe) {
    let result = e('article', { class: 'preview', },
        e('div', { class: 'title' },
            e('h2', {}, `${recipe.name}`)
        ),
        e('div', { class: 'small' },
            e('img', { src: `${recipe.img}` })
        )
    );
    return result;
}

async function getRecipeById(id) {
    let url = 'http://localhost:3030/data/recipes/' + id;
    let response = await fetch(url);
    let recepie = await response.json();

    return recepie;
}

function onDelete(ev) {
    let confirmed = confirm('Are you sure wanna delete this recipe?');

    if (!confirmed) {
        return;
    }

    let article = ev.target.parentElement.parentElement;
    article.textContent = '';
    let h2 = e('h2', {}, 'Recipe deleted');
    article.appendChild(h2);

    let url = 'http://localhost:3030/data/recipes/' + article.getAttribute('data-id');

    fetch(url, {
        method: 'DELETE',
        headers: {
            'X-Authorization': logControl.getSessionId(),
        }
    })
}

function create(formData) {
    let name = formData.get('name');
    let img = formData.get('img');
    let ingredients = formData.get('ingredients').split('\r\n').filter(x => x !== '');
    let steps = formData.get('steps').split('\r\n').filter(x => x !== '');

    fetch('http://localhost:3030/data/recipes', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('token')
        },
        body: JSON.stringify({
            name,
            img,
            ingredients,
            steps
        })
    })
        .then(res => res.json())
        .then(data => {
            if (data) {
                app.setUpNavigationBar();
            } else {
                throw new Error(data.message);
            }
        })
        .catch(err => console.error(err.message));
}

export default {
    getRecepies,
    createRecipeInfo,
    loadRecepies,
    getRecipeById,
    create,
}