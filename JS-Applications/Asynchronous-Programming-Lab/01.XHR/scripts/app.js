function loadRepos() {
   let httpRequest = new XMLHttpRequest();
   let url = 'https://api.github.com/users/testnakov/repos';
   
   httpRequest.addEventListener('readystatechange', () => {
      if (httpRequest.readyState == 4 && httpRequest.status == 200) {
         let div = document.getElementById('res');
         div.textContent = httpRequest.responseText;
      }
   });

   httpRequest.open("GET", url);
   httpRequest.send();
}