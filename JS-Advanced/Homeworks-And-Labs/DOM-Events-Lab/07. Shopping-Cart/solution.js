function solve() {
   let textAreaElement = document.querySelector('textArea');
   let allProducts = {};
   let addButtonsElements = Array.from(document.querySelectorAll('button.add-product'));
   let checkoutElement = document.querySelector('button.checkout');

   addButtonsElements.forEach(el => {
      el.addEventListener('click',addProduct);
   })
   
   checkoutElement.addEventListener('click', checkOut);

   function addProduct(event){
      let productName = event.target.parentNode.parentNode.querySelector('div.product-title').textContent;
      let productPrice = event.target.parentNode.parentNode.querySelector('div.product-line-price').textContent;

      textAreaElement.textContent += `Added ${productName} for ${productPrice} to the cart.\n`;

      allProducts[productName] = allProducts[productName] ? allProducts[productName] += Number(productPrice) : Number(productPrice);
   }

   function checkOut() {
      let products = Object.keys(allProducts).join(', ');
      let totalPrice = Object.values(allProducts).reduce((a,x) => a + x,0);
      textAreaElement.textContent += `You bought ${products} for ${totalPrice.toFixed(2)}.`;

      disableButtons()
   }
      
   function disableButtons() {
      let buttons = Array.from(document.querySelectorAll('button'));
      buttons.forEach(button => button.disabled = true);
   }
}