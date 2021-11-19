function attachEvents() {
    let selectElement = document.getElementById('posts');

    let loadButtonElement = document.getElementById('btnLoadPosts');
    loadButtonElement.addEventListener('click', onLoad)

    let viewButtonElement = document.getElementById('btnViewPost');
    viewButtonElement.addEventListener('click', onView);


    function onView() {
        let postId = selectElement.value;

        fetch(`http://localhost:3030/jsonstore/blog/posts/${postId}`)
            .then(res => res.json())
            .then(post => loadPostWithBody(post))
            .catch();

        fetch(`http://localhost:3030/jsonstore/blog/comments`)
            .then(res => res.json())
            .then(comments => loadPostComments(comments))
            .catch();
    }

    function loadPostWithBody(post) {
        let postTitleElement = document.getElementById('post-title');
        let pBodyElement = document.getElementById('post-body');
        pBodyElement.innerHTML = '';

        postTitleElement.textContent = post.title;

        // In the skeleton, this was 'ul' but in the document, examples were with 'p' and for that, I changed it to 'p'.
        pBodyElement.textContent = post.body;
    };

    function loadPostComments(comments) {
        let commentsUlElement = document.getElementById('post-comments');
        commentsUlElement.innerHTML = '';

        let postId = selectElement.value;
        let allComments = Object.values(comments);

        allComments.filter(x => x.postId == postId).forEach(comment => {
            commentsUlElement.appendChild(e('li',{},comment.text))
        });
    }

    function onLoad() {
        selectElement.innerHTML = '';
        let url = 'http://localhost:3030/jsonstore/blog/posts';
        fetch(url)
            .then(res => res.json())
            .then(posts => {
                for (const post in posts) {
                    let option = e('option', { value: posts[post].id }, posts[post].title);
                    selectElement.appendChild(option);
                }
            })
            .catch();
    };
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

attachEvents();