function solution() {
    let url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    fetch(url)
        .then(res => res.json())
        .then(data => {
            loadArticles(data);
        })
        .catch()
}

function loadArticles(articles) {
    let mainSectionElement = document.getElementById('main');

    articles.forEach(article => {
        let p = e('p', {}, '');

        fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${article._id}`)
            .then(res => res.json())
            .then(data => {
                loadDescription(p, data.content);
            })
            .catch();

        let divAccordion = e('div', { class: 'accordion' },
            e('div', { class: 'head' },
                e('span', {}, article.title),
                e('button', { class: 'button', onclick: showMore, id: article._id }, 'MORE')
            ),
            e('div', { class: 'extra' },
                p
            )
        )
        mainSectionElement.appendChild(divAccordion);
    });
}

function loadDescription(paragraf, content) {
    paragraf.textContent = content;
}

function showMore(e) {
    let nextSibling = e.target.parentElement.nextSibling;

    nextSibling.style.display = nextSibling.style.display == 'block' ?  'none' : 'block';
    e.target.textContent =   e.target.textContent == 'MORE' ? 'LESS' : 'MORE';
}

function e(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else if (attr == 'class') {
            result.classList.add(value);
        } else {
            result.setAttribute(attr, value);
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}


solution();