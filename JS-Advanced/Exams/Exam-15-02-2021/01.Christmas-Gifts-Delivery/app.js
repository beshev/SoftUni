function solution() {
    let allSections = document.querySelectorAll('section.card');
    let addInputElement = allSections[0].querySelector('input');
    let addButton = allSections[0].querySelector('button');
    let listGiftElement = allSections[1].querySelector('ul');;
    let sendGiftElement = allSections[2].querySelector('ul');;
    let discardedElement = allSections[3].querySelector('ul');;

    addButton.addEventListener('click', onAddClick);



    function onAddClick() {
        let li = document.createElement('li');
        li.textContent = addInputElement.value
        li.classList.add('gift');

        let sendButton = document.createElement('button');
        sendButton.textContent = 'Send';
        sendButton.id = 'sendButton';
        sendButton.addEventListener('click', onSendClick)
        li.appendChild(sendButton);

        let discardButton = document.createElement('button');
        discardButton.textContent = 'Discard'
        discardButton.id = 'discardButton';
        discardButton.addEventListener('click', onDiscardClick)
        li.appendChild(discardButton);

        listGiftElement.appendChild(li);

        Array.from(listGiftElement.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(x => listGiftElement.appendChild(x));

        addInputElement.value = '';
    }

    function onSendClick(e) {
        let li = e.target.parentElement;
        e.target.nextSibling.remove();
        e.target.remove();

        sendGiftElement.appendChild(li);
    }

    function onDiscardClick(e) {
        let li = e.target.parentElement;
        e.target.previousSibling.remove();
        e.target.remove();

        discardedElement.appendChild(li);
    }
}