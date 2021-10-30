let form = document.querySelector('#login-view #login');
form.addEventListener('submit', onLoginHandler);


async function onLoginHandler(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);
    let p = document.querySelector('.notification');
    p.textContent = '';

    let email = formData.get('email');
    let password = formData.get('password');

    let body = JSON.stringify({
        email,
        password
    })

    try {
        let response = await fetch('http://localhost:3030/users/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application.json' },
            body
        });

        let user = await response.json();

        if (response.status == 403) {
            let message = user.message.
                split('Login')
                .filter(x => x !== '')
                .map(x => 'Email' + x);

            throw new Error(message);
        }

        sessionStorage.setItem('auth_token',user.accessToken);
        sessionStorage.setItem('userId',user._id);
        sessionStorage.setItem('userEmail',user.email);

        window.location.pathname = '05.Fisher-Game/src/index.html';

    } catch (err) {
        p.textContent = err.message
    }
}