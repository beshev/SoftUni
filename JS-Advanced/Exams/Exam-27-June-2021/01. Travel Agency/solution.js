 window.addEventListener('load', solution);

function solution() {
  let submitButtonElement = document.getElementById('submitBTN');

  submitButtonElement.addEventListener('click', onSubmit);

  function onSubmit(e) {
    let nameInputElement = document.getElementById('fname');
    let emailInputElement = document.getElementById('email');
    let phoneInputElement = document.getElementById('phone');
    let addressInputElement = document.getElementById('address');
    let postCodeInputElement = document.getElementById('code');

    let name = nameInputElement.value;
    let email = emailInputElement.value;
    let phone = phoneInputElement.value;
    let address = addressInputElement.value;
    let code = postCodeInputElement.value;


    if (name.trim() === '' || email.trim() === '') {
      return;
    }

    let ul = document.getElementById('infoPreview');

    let liName = document.createElement('li');
    liName.textContent = `Full Name: ${name}`;
    ul.appendChild(liName);

    let liEmail = document.createElement('li');
    liEmail.textContent = `Email: ${email}`;
    ul.appendChild(liEmail);


    let liPhone = document.createElement('li');
    liPhone.textContent = `Phone Number: ${phone}`;
    ul.appendChild(liPhone);



    let liAddress = document.createElement('li');
    liAddress.textContent = `Address: ${address}`;
    ul.appendChild(liAddress);



    let liCode = document.createElement('li');
    liCode.textContent = `Postal Code: ${code}`;
    ul.appendChild(liCode);


    nameInputElement.value = '';
    emailInputElement.value = '';
    phoneInputElement.value = '';
    addressInputElement.value = '';
    postCodeInputElement.value = '';

    let editButton = document.getElementById('editBTN');
    let continueButton = document.getElementById('continueBTN');

    editButton.addEventListener('click', () => {
      nameInputElement.value = name;
      emailInputElement.value = email;
      phoneInputElement.value = phone;
      addressInputElement.value = address;
      postCodeInputElement.value = code;
      ul.innerHTML = '';

      submitButtonElement.disabled = false;
      editButton.disabled = true;
      continueButton.disabled = true;

    })

    continueButton.addEventListener('click', () => {
      let blockElement = document.getElementById('block');
      blockElement.innerHTML = '';
      let h3 = document.createElement('h3');
      h3.textContent = 'Thank you for your reservation!';
      blockElement.appendChild(h3);
    })

    e.target.disabled = true;
    editButton.disabled = false;
    continueButton.disabled = false;
  }
}