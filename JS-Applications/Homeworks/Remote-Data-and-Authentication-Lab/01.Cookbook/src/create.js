let form = document.querySelector('main article form');
form.addEventListener('submit', create);


function create(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);

    let name = formData.get('name');
    let img = formData.get('img');
    let ingredients = formData.get('ingredients').split('\r\n');
    let steps = formData.get('steps').split('\r\n');


    fetch('http://localhost:3030/data/recipes', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('auth_token')
        },
        body: JSON.stringify({
            name,
            img,
            ingredients,
            steps
        })
    })
        .then(res => res.json())
        .then(data => {
            if (data) {
                window.location.replace('./index.html');
            } else {
                throw new Error(data.message);
            }
        })
        .catch(err => console.error(err.message));
}