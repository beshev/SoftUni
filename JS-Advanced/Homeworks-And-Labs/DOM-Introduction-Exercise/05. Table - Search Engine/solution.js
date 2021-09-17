function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      //   TODO:
      let tableRowsElemets = Array.from(document.querySelectorAll('tbody tr'));
      let searchedText = document.querySelector('#searchField').value;
      console.log(searchedText);

      for (const rowElement of tableRowsElemets) {
         rowElement.classList.remove('select');
         
         if (rowElement.textContent.includes(searchedText)) {
            rowElement.classList.add('select')
         }
      }
   }
      
}