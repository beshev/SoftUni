window.addEventListener('load', solve);

async function solve() {
    let logoutButton = document.getElementById('logoutBtn');
    logoutButton.addEventListener('click', logoutHandler);
    let recepies = await getRecepies();
    let cards = recepies.map(loadRecepies);

    let main = document.querySelector('body main');
    main.innerHTML = '';

    cards.map(x => main.appendChild(x))

    let authToken = sessionStorage.getItem('auth_token');

    if (authToken && authToken !== 'undefined') {
        isAuthenticated(true);
    } else {
        isAuthenticated(false);
    }

}

function logoutHandler() {
    sessionStorage.removeItem('auth_token');
    isAuthenticated(false);
}

function isAuthenticated(isLogged) {
    let userDiv = document.getElementById('user');
    let guestDiv = document.getElementById('guest');

    if (isLogged) {
        guestDiv.style.display = 'node';
        userDiv.style.display = 'inline';
    } else {
        guestDiv.style.display = 'inline';
        userDiv.style.display = 'none';
    }
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
    result.addEventListener('click', onArticle);
    return result;

    async function onArticle() {
        result.replaceWith(CreateRecipeInfo(await getRecipeById(recipe._id)));
    }

}

function CreateRecipeInfo(recipeInfo) {
    return e('article', {},
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
        ))
}

async function getRecipeById(recipeId) {
    let url = `http://localhost:3030/data/recipes/${recipeId}`;
    let response = await fetch(url);
    let recipeInfo = await response.json();

    return recipeInfo;
}

async function getRecepies() {
    let url = 'http://localhost:3030/data/recipes';
    let response = await fetch(url);
    let recepies = await response.json();

    return Object.values(recepies);
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

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    for (let item of content) {
        if (typeof item == 'string' || typeof item == 'number') {
            item = document.createTextNode(item);
        }

        element.appendChild(item);
    }

    return element;
}

