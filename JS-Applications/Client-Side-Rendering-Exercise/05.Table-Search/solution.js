import { html, render } from '../node_modules/lit-html/lit-html.js';

function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   renderRows();

   function onClick() {
      let input = document.getElementById('searchField');
      let value = input.value.toLowerCase().trim();
      let alltd = document.querySelectorAll('tbody tr');

      alltd.forEach(x => {
         if (x.textContent.toLocaleLowerCase().includes(value) && value !== '') {
            x.classList.add('select');
         } else {
            x.classList.remove('select');
         }
      })

      input.value = '';
   }
}

solve();


let tableRowTemplate = (student) => html`
   <tr>
      <td>${student.firstName} ${student.lastName}</td>
      <td>${student.email}</td>
      <td>${student.course}</td>
   </tr>
`

async function renderRows() {
   let students = await getTableRows();
   render(html`${students.map(x => tableRowTemplate(x))}`, document.querySelector('tbody'));
}

async function getTableRows() {
   let response = await fetch('http://localhost:3030/jsonstore/advanced/table');
   let data = await response.json();

   return Object.values(data);
}