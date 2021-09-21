function create(words) {
   let conttentElement = document.getElementById('content');

   for (const word of words) {
      console.log(word);

      let div = document.createElement('div');
      let p = document.createElement('p');

      p.style.display = 'none';
      p.textContent = word;

      div.addEventListener('click', (e) => {
         e.target.children[0].style.display = 'block';
      });

      div.appendChild(p);
      conttentElement.appendChild(div);
   }
}