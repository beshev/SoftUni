function attachGradientEvents() {
    let hoverElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');

    hoverElement.addEventListener('mousemove',(e) => {
        let precentage = Math.floor(e.offsetX / e.target.clientWidth * 100);
        resultElement.textContent = `${Number(precentage)}%`;
    });
}