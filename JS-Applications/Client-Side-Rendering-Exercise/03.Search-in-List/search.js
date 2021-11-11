import { html, render } from "../node_modules/lit-html/lit-html.js";
import { towns } from "./towns.js";

let townsListTemplate = (towns) => html`
   <ul>
      ${towns.map(x => html`<li>${x}</li>`)}
   </ul>
   `
let townsDiv = document.getElementById('towns');
render(townsListTemplate(towns), townsDiv);

let searchBtn = document.getElementById('searchBtn');
searchBtn.addEventListener('click', search)

function search(ev) {
   let searchText = document.getElementById('searchText').value.toLowerCase();
   let allLi = document.querySelectorAll('#towns ul li');
   let count = 0;

   allLi.forEach(x => {
      if (x.textContent.toLowerCase().includes(searchText) && searchText !== '') {
         x.classList.add('active')
         count++;
      } else {
         x.classList.remove('active')
      }
   });

   document.getElementById('result').textContent = `${count} matches found`;
}
