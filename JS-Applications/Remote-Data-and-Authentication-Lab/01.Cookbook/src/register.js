let form = document.querySelector('main article form');
form.addEventListener('submit', register);


function register(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);

    let email = formData.get('email');
    let password = formData.get('password');
    let repeat = formData.get('rePass')

    if (password !== repeat) {
        return console.error('Passwords don\'t match');
    }

    fetch('http://localhost:3030/users/register', {
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
                throw new Error(data.message);
            }
        })
        .catch(err => console.error(err.message));
}