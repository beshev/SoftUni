function attachEvents() {
    let url = 'http://localhost:3030/jsonstore/messenger';
    let refreshInput = document.getElementById('refresh');
    refreshInput.addEventListener('click', onRefresh.bind(null, url));

    let sendInput = document.getElementById('submit');
    sendInput.addEventListener('click', onSend.bind(null, url));
}

function onSend(url) {
    const name = document.querySelector('input[name="author"]');
    const message = document.querySelector('input[name="content"]');

    const body = JSON.stringify({
        author: name.value,
        content: message.value
    })

    fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application.json' },
        body
    })

    name.value ='';
    message.value ='';
}

async function onRefresh(url) {
    let messages = await fetch(url).then(res => res.json());
    let textArea = document.getElementById('messages');
    textArea.textContent = '';

    Object.values(messages).forEach(entity => {
        textArea.textContent += `${entity.author}: ${entity.content}\r\n`;
    })
}

attachEvents();