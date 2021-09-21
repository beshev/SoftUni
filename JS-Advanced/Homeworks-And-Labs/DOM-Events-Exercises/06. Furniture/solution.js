function solve() {
  let generateButtonElement = document.querySelectorAll('#exercise button')[0]; 
  let buyButtonElement = document.querySelectorAll('#exercise button')[1];

  let generateTextareaElement = document.querySelectorAll('#exercise textarea')[0];
  let buyTextareaElement = document.querySelectorAll('#exercise textarea')[1];

  let tableBodyElement = document.querySelector('.table tbody');

  generateButtonElement.addEventListener('click', onClickAddProducts);
  
  buyButtonElement.addEventListener('click', onClickBuy);


  function onClickBuy() {
    let names = [];
    let prices = [];
    let decFactors = [];

    Array.from(tableBodyElement.children).forEach(r => {
      let checkBox = r.querySelector('td input');
      let allPElements = r.querySelectorAll('td p');
      if (checkBox.checked) {
        names.push(allPElements[0].textContent)
        prices.push(Number(allPElements[1].textContent));
        decFactors.push(Number(allPElements[2].textContent));
      }
    })
    
    buyTextareaElement.value = `Bought furniture: ${names.join(', ')}\n`;
    buyTextareaElement.value += `Total price: ${prices.reduce((a,x) => a + x,0).toFixed(2)}\n`;
    buyTextareaElement.value += `Average decoration factor: ${decFactors.reduce((a, x, i, arr) => a + (x / arr.length),0)}`;
  }

  function onClickAddProducts(){
    let products = Array.from(JSON.parse(generateTextareaElement.value));

    for (const element of products) {
      let tr = document.createElement('tr');

      let tdImg = document.createElement('td');
      let img = document.createElement('img');
      img.src = element.img;
      tdImg.appendChild(img);
      tr.appendChild(tdImg);
      
      let tdName = document.createElement('td');
      let pName = document.createElement('p');
      pName.textContent = element.name;
      tdName.appendChild(pName);
      tr.appendChild(tdName)

      let tdPrice = document.createElement('td');
      let pPrice = document.createElement('p');
      pPrice.textContent = element.price;
      tdPrice.appendChild(pPrice);
      tr.appendChild(tdPrice)

      let tdFactor = document.createElement('td');
      let pFactor = document.createElement('p');
      pFactor.textContent = element.decFactor;
      tdFactor.appendChild(pFactor);
      tr.appendChild(tdFactor)

      let tdCheckBox = document.createElement('td');
      let input = document.createElement('input');
      input.type = 'checkbox';
      tdCheckBox.appendChild(input);
      tr.appendChild(tdCheckBox)
      tableBodyElement.appendChild(tr);
    }
  }
}