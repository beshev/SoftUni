import { showNavBar } from './app.js';
import { viewDetails } from './details.js';
import { e } from './dom.js';

let main = undefined;
let section = undefined;


function setDashboard(tagName, targetSection) {
    main = tagName;
    section = targetSection;
}

export async function viewDashboard() {
    main.innerHTML = '';
    section.innerHTML = '';
    main.appendChild(section);
    let ideas = await getIdeas();

    if (ideas.length == 0) {
        let h1 = document.createElement('h1');
        h1.textContent = 'No ideas yet! Be the first one :)';
        section.appendChild(h1);
    } else {
        let result = ideas.map(x => createIdeaElement(x));
        section.append(...result);
    }
    showNavBar();
}

async function getIdeas() {
    let response = await fetch('http://localhost:3030/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc');
    let data = await response.json();
    return data
}

function createIdeaElement(idea) {
    let div = e('div', { class: 'card overflow-hidden current-card details', style: 'width: 20rem; height: 18rem;' },
        e('div',{class: 'card-body'},
            e('p',{class: 'card-text'},idea.title)
        ),
        e('img',{class: "card-image", src: `${idea.img}`, alt: "Card image cap"}),
        e('a',{class: 'btn',onClick: viewDetails.bind(null,idea._id)},'Details')
    )
    return div;
}

export default {
    setDashboard,
    viewDashboard,
}