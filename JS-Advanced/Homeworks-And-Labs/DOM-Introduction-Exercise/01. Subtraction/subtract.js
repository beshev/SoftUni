function subtract() {
    let firstNumber = Number(document.querySelector('#firstNumber').value);
    let secondNumber = Number(document.querySelector('#secondNumber').value);
    let resultElement = document.querySelector('#result');
    
    resultElement.textContent = firstNumber - secondNumber;
}