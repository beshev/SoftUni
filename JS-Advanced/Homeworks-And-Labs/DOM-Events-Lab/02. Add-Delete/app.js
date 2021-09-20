function addItem() {
    let listElement = document.getElementById('items');
    let newItemTextElement = document.getElementById('newItemText');

    let li = document.createElement('li');
    let a = document.createElement('a');
    a.addEventListener('click',(e) => {
       e.currentTarget.parentNode.remove()
    });

    li.textContent = newItemTextElement.value;
    a.setAttribute('href','#');
    a.textContent = '[Delete]';
    li.appendChild(a);
    
    listElement.appendChild(li);
    newItemTextElement.value = '';
}