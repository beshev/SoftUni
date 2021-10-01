class Contact {
    _isOnline = false;

    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
    }

    render = function (id) {
        let parentDiv = document.getElementById(id);
        let articleElement = document.createElement('article');

        this.divTitleElement = document.createElement('div');
        this.divTitleElement.classList.add('title');
        this.divTitleElement.textContent = `${this.firstName} ${this.lastName}`;

        if (this.online) {
            this.divTitleElement.classList.add('online');
        }

        let titleButtonElement = document.createElement('button');
        titleButtonElement.textContent = String.fromCharCode(parseInt('+02139', 16));
        titleButtonElement.addEventListener('click', onButtonClick);
        this.divTitleElement.appendChild(titleButtonElement)

        let divInfoElement = document.createElement('div');
        divInfoElement.classList.add('info');
        divInfoElement.style.display = 'none';

        let spanPhoneElement = document.createElement('span');
        spanPhoneElement.textContent = `\u260E ${this.phone}`
        divInfoElement.appendChild(spanPhoneElement);

        let spanEmailElement = document.createElement('span');
        spanEmailElement.textContent = `${String.fromCharCode(parseInt('+02709', 16))} ${this.email}`;
        divInfoElement.appendChild(spanEmailElement);

        articleElement.appendChild(this.divTitleElement);
        articleElement.appendChild(divInfoElement);
        parentDiv.appendChild(articleElement);

        function onButtonClick() {
            divInfoElement.style.display = divInfoElement.style.display == 'block' ? 'none' : 'block'
        }

    }

    get online() {
        return this._isOnline;
    }

    set online(value) {
        this._isOnline = value;

        if (this.divTitleElement) {
            if (this._isOnline) {
                this.divTitleElement.classList.add('online');
            } else {
                this.divTitleElement.classList.remove('online');
            }
        }
    }
}


function solve() {
    let contacts = [
        new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
        new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
        new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
    ];
    contacts.forEach(c => c.render('main'));

    let data = {
        firstName: 'Ivan',
        lastName: 'Ivanov',
        phone: '0888 123 456',
        email: 'i.ivanov@gmail.com'
    };

    let contact = new Contact(data.firstName, data.lastName, data.phone, data.email)
    contact.online = true;
    contact.render('main');

    // After 1 second, change the online status to true
    setTimeout(() => contacts[1].online = true, 2000);

    setTimeout(() => contacts[1].online = false, 4000);
}


// document.body.innerHTML = `
// <div id="holder"></div>
// `;

// let Contact = result;

// let data = {
//     firstName: 'Ivan',
//     lastName: 'Ivanov',
//     phone: '0888 123 456',
//     email: 'i.ivanov@gmail.com'
// };

// let element = $('#holder').find('article');
// expect(element.length).to.equal(1, "<article> wasn't correctly generated");
// vrfyElement(element, data);

// function vrfyElement(element, data) {
//     let title = element.find('.title');
//     expect(title.hasClass('online')).to.equal(true, "Contact must be displayed as online");
// }