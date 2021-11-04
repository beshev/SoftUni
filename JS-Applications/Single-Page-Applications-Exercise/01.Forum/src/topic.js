import { el } from './dom.js';
import comments from './comments.js';

let main;
let section;
let baseUrl = 'http://localhost:3030/jsonstore/collections/myboard/posts';

function setTopic(tagName, targetSection) {
    main = tagName;
    section = targetSection;

    let form = targetSection.querySelector('form');
    form.querySelector('button.public').addEventListener('click', onPost);
    form.querySelector('button.cancel').addEventListener('click', (e) => {
        e.preventDefault();
        form.reset();
    });
}

async function onPost(e) {
    e.preventDefault();
    let formData = new FormData(e.target.parentElement.parentElement);

    let title = formData.get('topicName');
    let username = formData.get('username');
    let postText = formData.get('postText');

    var today = new Date();
    var currDate = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();

    if (title.trim() == '' || username.trim() == '' || postText.trim() == '') {
        alert('All fields are required!');
        return
    }

    try {
        let response = await fetch(baseUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application.json' },
            body: JSON.stringify({
                title,
                username,
                postText,
                currDate,
            })
        });

        if (response.status !== 200) {
            throw new Error();
        }

    } catch (error) {
        alert('An error occurred! Please try again later.');
    }

    showTopics();
}

async function showTopics() {
    main.innerHTML = '';
    main.appendChild(section);

    let data = await getTopics();
    let topics = Object.values(data).map(createTopic);

    let topicContainer = section.querySelector('div.topic-container');
    topicContainer.textContent = '';
    topicContainer.append(...topics);
}

async function getTopics() {
    let response = await fetch(baseUrl);
    let data = response.json();

    return data;
}

function createTopic(topic) {
    let result = el('div', { class: 'topic-name-wrapper' },
        el('div', { class: 'topic-name' },
            el('a', { href: '#', class: 'normal' },
                el('h2', {}, topic.title)
            ),
            el('div', { class: 'columns' },
                el('div', {},
                    el('p', {},
                        'Date:',
                        el('time', {}, topic.currDate)
                    ),
                    el('div', { class: 'nick-name' },
                        el('p', {},
                            'Username: ',
                            el('span', {}, topic.username)
                        )
                    )
                ),
            )
        )
    )
    result.querySelector('a').addEventListener('click', () => comments.showComments(topic._id))
    return result;
}

export default {
    setTopic,
    showTopics,
}