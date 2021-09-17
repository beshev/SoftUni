function solve() {
  //TODO
  let input = document.querySelector('#input').value.split('.').filter(x => x.length > 0);
  let outputElement = document.querySelector('#output');
  outputElement.innerHTML = null;

  while (input.length > 0) {
    let curentRowData = input.splice(0,3);
    let p = document.createElement('p');
    p.textContent = curentRowData.join('').trim() + '.';
    outputElement.appendChild(p);
  }
}