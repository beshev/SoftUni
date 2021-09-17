function search() {
   // TODO
   let townsElements = Array.from(document.querySelectorAll('#towns li'));
   let searchText = document.querySelector('#searchText').value;
   
   resetTable(townsElements);
   let counter = 0;
   for (const liElement of townsElements) {
      
      if (liElement.textContent.includes(searchText)) {
         liElement.style.fontWeight = 'bold';
         liElement.style.textDecoration = 'underline';
         counter++;
      }
   }

   let resut = document.querySelector('#result');
   resut.textContent = counter + " matches found"

   function resetTable(townsElements) {
        for (const liElement of townsElements) {
         liElement.style = null;
      }
   }
}
