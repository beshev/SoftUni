function solution() {
    let sections = document.querySelectorAll('.container section');
    let addButton = sections[0].querySelector('button');

    addButton.addEventListener('click', onAdd);



    function onAdd() {
        let input = sections[0].querySelector('input');
        let ul = sections[1].querySelector('ul');
        let sendButton = e('button', { id: 'sendButton' }, 'Send');
        sendButton.addEventListener('click', onSend);

        let discardButton = e('button', { id: 'discardButton' }, 'Discard');
        discardButton.addEventListener('click', onDiscard);

        let li = e('li', { class: 'gift' },
            input.value,
            sendButton,
            discardButton
        )

        ul.appendChild(li);

        Array.from(ul.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(x => {
                ul.appendChild(x);
            })


        input.value = '';

        function onSend() {
            sendButton.remove();
            discardButton.remove();
            sections[2].querySelector('ul').appendChild(li);
        }

        function onDiscard() {
            sendButton.remove();
            discardButton.remove();
            sections[3].querySelector('ul').appendChild(li);
        }
    }

    function e(type, attr, ...content) {
        const element = document.createElement(type);

        for (const prop in attr) {
            if (prop === 'class') {
                element.classList.add(attr[prop])
            } else {
                element[prop] = attr[prop];
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