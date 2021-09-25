function solve() {
    let allSections = document.querySelectorAll('section')
    let addButtonElement = document.querySelector('#add');

    let openSection = allSections[1];
    let inProgressSection = allSections[2];
    let fishinSection = allSections[3];

    addButtonElement.addEventListener('click', onAdd)

    function onAdd(e) {
        e.preventDefault();
        let taskInputElement = document.getElementById('task');
        let descInputElement = document.getElementById('description');
        let dateInputElement = document.getElementById('date');

        let task = taskInputElement.value.length <= 0 ? undefined : taskInputElement.value;
        let desc = descInputElement.value.length <= 0 ? undefined : descInputElement.value;
        let date = dateInputElement.value.length <= 0 ? undefined : dateInputElement.value;

        if (!task || !desc || !date) {
            return;
        }
        
        let sectionDiv = openSection.children[1];
        let article = document.createElement('article');
        let h3 = document.createElement('h3');
        let pDesc = document.createElement('p');
        let pDate = document.createElement('p');
        let articleDiv = document.createElement('div');
        let buttonStart = document.createElement('button');
        let buttonDelete = document.createElement('button');

        h3.textContent = task;

        pDesc.textContent = `Description: ${desc}`;
        pDate.textContent = `Due Date: ${date}`;

        buttonStart.textContent = 'Start';
        buttonStart.className = 'green';
        buttonStart.addEventListener('click', onStart)

        buttonDelete.className = 'red';
        buttonDelete.textContent = 'Delete';
        buttonDelete.addEventListener('click', (e) => {
            e.target.parentElement.parentElement.remove();
        })

        articleDiv.className = 'flex';
        articleDiv.appendChild(buttonStart);
        articleDiv.appendChild(buttonDelete);
        article.appendChild(h3);
        article.appendChild(pDesc);
        article.appendChild(pDate);
        article.appendChild(articleDiv);

        sectionDiv.appendChild(article);
        
        
        function onStart() {
            let inProgressSectionDivElement = inProgressSection.children[1];
            articleDiv.removeChild(buttonStart);
            buttonStart.textContent = 'Finish';
            buttonStart.addEventListener('click', onFinish)
            buttonStart.className = 'orange';
            articleDiv.appendChild(buttonStart);

            inProgressSectionDivElement.appendChild(article);
        }

        function onFinish() {
            let finishSectionDivElement = fishinSection.children[1];
            article.removeChild(articleDiv);
            finishSectionDivElement.appendChild(article);
        }
    }

}