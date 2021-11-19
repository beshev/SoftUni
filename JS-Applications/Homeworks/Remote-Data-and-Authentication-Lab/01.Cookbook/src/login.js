
let form = document.querySelector('main article form');
form.addEventListener('submit', loggin);


function loggin(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);

    let email = formData.get('email');
    let password = formData.get('password');

    fetch('http://localhost:3030/users/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            email,
            password,
        })
    })
        .then(res => res.json())
        .then(data => {
            if (data.accessToken) {
                sessionStorage.setItem('auth_token', data.accessToken);
                window.location.replace('./index.html');
            } else {
                throw data;
            }
        })
        .catch(err => console.error(err.message));
}