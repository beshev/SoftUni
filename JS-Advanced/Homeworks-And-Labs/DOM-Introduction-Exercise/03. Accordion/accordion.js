function toggle() {
    let buttonElement = document.querySelector('span.button');
    let hiddenElement = document.querySelector('#extra');

    if (hiddenElement.style.display  == 'none') {
        hiddenElement.style.display = "block";
        buttonElement.textContent = 'Less';
    } else {
        hiddenElement.style.display = "none";
        buttonElement.textContent = 'More';
    }
}