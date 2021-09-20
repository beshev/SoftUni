function deleteByEmail() {
    let outPutElement = document.getElementById('result');
    let inputTextElement = document.querySelector('input[name=email]');
    let emailsElements = Array.from(document.querySelectorAll('tbody tr td:nth-child(2)'))
    .filter(x => x.textContent === inputTextElement.value);

    if (emailsElements.length == 0) {
        outPutElement.textContent = 'Not found.';
        return;
    }
    outPutElement.textContent = 'Deleted';


    emailsElements[0].parentNode.remove();
}