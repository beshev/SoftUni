function addItem() {
    let newItemValueElement = document.getElementById('newItemValue');
    let newItemTextElement = document.getElementById('newItemText');
    let selectMenuElement = document.getElementById('menu');

    let newOptionElement = document.createElement('option');

    newOptionElement.value = newItemValueElement.value;
    newOptionElement.textContent = newItemTextElement.value;

    selectMenuElement.appendChild(newOptionElement);
    newItemValueElement.value = '';
    newItemTextElement.value= '';

}