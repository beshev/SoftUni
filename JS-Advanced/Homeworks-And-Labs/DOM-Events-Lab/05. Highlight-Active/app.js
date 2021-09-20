function focused() {
    Array.from(document.querySelectorAll('input')).forEach(e => {
        e.addEventListener('focus',(e) => {
            e.target.parentNode.className = 'focused';
        })
        e.addEventListener('blur',(e) => {
            e.target.parentNode.className = '';
        });
    });
}