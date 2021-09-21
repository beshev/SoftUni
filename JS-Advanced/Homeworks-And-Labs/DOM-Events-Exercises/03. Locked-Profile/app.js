function lockedProfile() {
        Array.from(document.querySelectorAll('button')).forEach(e => {
        e.addEventListener('click', (event) => {
            let parentElement = event.currentTarget.parentNode;
            let lockCheckBoxElement = parentElement.querySelector('input[value=lock]');
            if (lockCheckBoxElement.checked) {
                return;
            }
            
            let isHide = event.target.textContent == 'Show more' ?  true : false;

            if (isHide) {
                event.target.textContent = 'Hide it';
                parentElement.children[9].style.display = 'block';
            } else {
                event.target.textContent = 'Show more';
                parentElement.children[9].style.display = 'none';
            }
        })
    })
}