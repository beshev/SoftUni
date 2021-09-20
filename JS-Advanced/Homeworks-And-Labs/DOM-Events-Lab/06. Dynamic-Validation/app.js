function validate() {
    let inputElement = document.getElementById('email');
    inputElement.addEventListener('change', (e) => {
        let text = e.target.value;

        if (!text.match(/[a-z]+@[a-z]+\.[a-z]{2,3}$/g)) {
            e.target.className = 'error'
        } else {
            e.target.className = ''
        }
    })
}