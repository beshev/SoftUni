import detailsModule from './details.js'

let main;
let section
let targetId;

function setEdit(tagName, targetSection) {
    main = tagName;
    section = targetSection;

    const form = targetSection.querySelector('form');
    form.addEventListener('submit', onSubmit)
}

function showEdit(movie) {
    targetId = movie._id;
    main.innerHTML = '';
    let fileds = section.querySelectorAll('.form-control');
    fileds[0].value = movie.title;
    fileds[1].value = movie.description;
    fileds[2].value = movie.img;
    main.appendChild(section);
}

async function onSubmit(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);
    let title = formData.get('title');
    let description = formData.get('description');
    let img = formData.get('imageUrl');

    let body = JSON.stringify({
        title,
        description,
        img
    })

    let token = sessionStorage.getItem('token');

    let url = 'http://localhost:3030/data/movies/' + targetId;
    try {
        await fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': token,
            },
            body
        });

        detailsModule.showDetails(targetId);
    } catch (error) {
        alert('An error occurred! Please try agein later.')
    }

}


export default {
    setEdit,
    showEdit,
}