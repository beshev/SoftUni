function validate() {
    let emailElement = document.getElementById('email');

    emailElement.addEventListener('change', (e) => {
        let email = e.target.value;

        if (!email.match(/^[a-z]+@[a-z]+.[a-z]+$/)) {
            e.target.className = 'error';
            return;
        } 
        e.target.className = '';
    })
}