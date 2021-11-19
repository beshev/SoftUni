import { showNavBar } from './app.js';
import { viewDashboard } from './dashboard.js';
import { e } from './dom.js';

let main = undefined;
let section = undefined;


function setDetails(tagName, targetSection) {
    main = tagName;
    section = targetSection;
}

export async function viewDetails(ideaId, e) {
    e.preventDefault();
    main.innerHTML = '';

    let ideaDetails = createDetailsElement(await getDetails(ideaId));

    main.appendChild(ideaDetails);
}

async function getDetails(targetId) {
    let response = await fetch('http://localhost:3030/data/ideas/' + targetId);
    let data = await response.json();
    return data;
}

function createDetailsElement(idea) {
     let a = e('a',{class: 'btn detb'},'Delete')
     a.addEventListener('click', onDelete.bind(null,idea._id));

    let div = e('div', { class: 'container home some' },
        e('img', { class: 'det-img', src: `${idea.img}` }),
        e('div', { class: 'desc' },
            e('h2', { class: 'display-5' }, idea.title),
            e('p', { class: 'infoType' }, 'Description:'),
            e('p',{class: 'idea-description'},idea.description)
        ),
        e('div',{class: 'text-center'},
            localStorage.getItem('userId') == idea._ownerId ? a : ''
        )
    )

    return div;
}

async function onDelete(targetId,e) {
    e.preventDefault();

    await fetch('http://localhost:3030/data/ideas/' + targetId,{
        method: 'Delete',
        headers: {'X-Authorization': localStorage.getItem('token')}
    })

    viewDashboard();
}

export default {
    setDetails,
    viewDetails,
}