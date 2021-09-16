function sumTable() {
    let trElements = Array.from(document.querySelectorAll('td:nth-child(even)'));
    //debugger;
    let sumElement = trElements.pop();
    let sum = trElements.reduce((a, x) => a + Number(x.textContent),0);
    sumElement.textContent = sum;
}