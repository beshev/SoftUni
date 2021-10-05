function solve() {
   let createButtonElement = document.querySelector('form button.create');
   createButtonElement.addEventListener('click', (e) => {
      e.preventDefault();
      let section = document.querySelector('main section');
      let authorElement = document.getElementById('creator');
      let titleElement = document.getElementById('title');
      let categoryElement = document.getElementById('category');
      let contentElement = document.getElementById('content');

      let article = document.createElement('article');
      let h1 = document.createElement('h1');
      h1.textContent = titleElement.value;
      article.appendChild(h1);

      let pCategory = document.createElement('p');
      pCategory.textContent = 'Category:';
      let strongCate =  document.createElement('strong');
      strongCate.textContent = categoryElement.value;
      pCategory.appendChild(strongCate);
      article.appendChild(pCategory);

      let pAuthor = document.createElement('p');
      pAuthor.textContent = 'Creator:';
      let strongAuth =  document.createElement('strong');
      strongAuth.textContent = authorElement.value;
      pAuthor.appendChild(strongAuth);
      article.appendChild(pAuthor);

      let pContent = document.createElement('p');
      pContent.textContent = contentElement.value;
      article.appendChild(pContent);

      let div = document.createElement('div');
      div.classList.add('buttons');
      let deleteButton = document.createElement('button');
      deleteButton.textContent = 'Delete';
      deleteButton.classList.add('btn');
      deleteButton.classList.add('delete');
      deleteButton.addEventListener('click', (e) => {
         e.currentTarget.parentElement.parentElement.remove();
      });

      let archiveButton = document.createElement('button');
      archiveButton.textContent = 'Archive';
      archiveButton.classList.add('btn');
      archiveButton.classList.add('archive');
      archiveButton.addEventListener('click', (e) => {
         let olElement = document.querySelector('section.archive-section ol');
         let li = document.createElement('li');
         li.textContent = e.currentTarget.parentElement.parentElement.children[0].textContent;

         olElement.appendChild(li);
         Array.from(olElement.children)
         .sort((a, b) => a.textContent.localeCompare(b.textContent))
         .forEach(el => {
            olElement.appendChild(el);
         })

         e.currentTarget.parentElement.parentElement.remove();
      });

      div.appendChild(deleteButton);
      div.appendChild(archiveButton);
      article.appendChild(div);

      section.appendChild(article);
   });
}
