function addItem() {
    let listElement = document.getElementById('items');
    let itemTextElement = document.getElementById('newItemText');

    let li = document.createElement('li');
    li.textContent = itemTextElement.value;

    listElement.appendChild(li);

    itemTextElement.value = '';
}