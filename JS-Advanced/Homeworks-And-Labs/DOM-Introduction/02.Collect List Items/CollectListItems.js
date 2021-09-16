function extractText() {
    // TODO
    let values = document.querySelectorAll('li');

    let textAreaElement = document.getElementById('result');
    for (const value of values) {

        console.log(value.textContent);
        textAreaElement.textContent += value.textContent + '\n';
    }
}