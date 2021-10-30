let form = document.querySelector('#register-view #register');
form.addEventListener('submit', onRegisterHandler);


async function onRegisterHandler(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);
    let p = document.querySelector('.notification');
    p.textContent = '';

    let email = formData.get('email');
    let password = formData.get('password');
    let repeat = formData.get('rePass');

    if (repeat !== password) {
        p.textContent = "Passwords doesn't match";
        return;
    }

    let body = JSON.stringify({
        email,
        password
    })

    try {
        let response = await fetch('http://localhost:3030/users/register', {
            method: 'POST',
            headers: { 'Content-Type': 'application.json' },
            body
        });

        let user = await response.json();

        if (response.status == 400) {
            throw new Error(user.message);
        }

        sessionStorage.setItem('auth_token', user.accessToken);
        sessionStorage.setItem('userId', user._id);
        sessionStorage.setItem('userEmail', user.email);
        
        window.location.pathname = '05.Fisher-Game/src/index.html';

    } catch (err) {
        p.textContent = err.message
    }
}