function validate() {
    let userInfoElement = document.getElementById('userInfo');
    let submitButton = document.querySelector('#submit');
    let checkBox = userInfoElement.querySelector('div input#company');
    let validElement = document.getElementById('valid');

    let usernameElement = userInfoElement.querySelector('#username');
    let emailElement = userInfoElement.querySelector('#email');
    let passwordElement = userInfoElement.querySelector('#password');
    let confirmPasswordElement = userInfoElement.querySelector('#confirm-password');
    let companyInfoElement = document.getElementById('companyNumber');
    
    let usernameRegex = /^[a-zA-Z0-9]{3,20}$/;
    let emailRegex = /^.*@.*\..*$/;
    let passwordRegex = /^[0-9A-Za-z_]{5,15}$/;


    submitButton.addEventListener('click', (e) => {
        e.preventDefault();
        let validCounter = 0;

        if (!usernameElement.value.match(usernameRegex)) {
            usernameElement.style.borderColor = 'red';
        } else {
            usernameElement.style.border = 'none';
            validCounter++;
        }

        if (!emailElement.value.match(emailRegex)) {
            emailElement.style.borderColor = 'red';
        } else {
            emailElement.style.border = 'none';
            validCounter++;
        }

        if (passwordElement.value.match(passwordRegex)
            && confirmPasswordElement.value.match(passwordRegex)
            && confirmPasswordElement.value == passwordElement.value) {
            confirmPasswordElement.style.border = 'none';
            passwordElement.style.border = 'none';
            validCounter++;
        } else {
            confirmPasswordElement.style.borderColor = 'red';
            passwordElement.style.borderColor = 'red';
        }

        if (checkBox.checked) {
            let companyNumber = Number(companyInfoElement.value);
            if (companyNumber < 1000 || companyNumber > 9999) {
                companyInfoElement.style.borderColor = 'red';
            } else {
                companyInfoElement.style.border = 'none';
                validCounter++;
            }
        }

        let expectedValidCount = checkBox.checked ? 4 : 3;

        if (validCounter == expectedValidCount) {
            validElement.style.display = 'block';
        } else {
            validElement.style.display = 'none';
        }
    })

    checkBox.addEventListener('change', (e) => {
        if (e.target.checked) {
            document.getElementById('companyInfo').style.display = 'block';
        } else {
            document.getElementById('companyInfo').style.display = 'none';
        }
    })
}
