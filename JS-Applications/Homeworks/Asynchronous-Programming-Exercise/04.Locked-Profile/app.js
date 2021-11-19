async function lockedProfile() {
    let url = 'http://localhost:3030/jsonstore/advanced/profiles';
    let response = await fetch(url);
    let users = await response.json();

    let main = document.getElementById('main');
    main.innerHTML = '';

    let userNumber = 1;
    for (const key in users) {
        let user = users[key];
        let showMoreButton = e('button', {}, 'Show more');
        showMoreButton.addEventListener('click', onShow);

        let div = e('div', { className: 'profile' },
            e('img', { src: './iconProfile2.png', className: 'userIcon' }),
            e('label', {}, 'Lock'),
            e('input', { type: 'radio', name: `user${userNumber}Locked`, value: 'lock', checked: true }),
            e('label', {}, ' Unlock'),
            e('input', { type: 'radio', name: `user${userNumber}Locked`, value: 'unlock' }),
            e('br'),
            e('hr'),
            e('label', {}, 'Username'),
            e('input', { type: 'text', name: `user${userNumber}Username`, value: user.username, disabled: true, readonly: true }),
            e('div', { id: 'user1HiddenFields' },
                e('hr'),
                e('label', {}, 'Email'),
                e('input', { type: 'email', name:  `user${userNumber}Email`, value: user.email, disabled: true, readonly: true }),
                e('label', {}, 'Age'),
                e('input', { type: 'email', name: `user${userNumber}Age`, value: user.age, disabled: true, readonly: true })),
            showMoreButton
        )
        main.appendChild(div);
        userNumber++;

    }

    function onShow(e) {
        let parent = e.target.parentElement;
        const hiddenElement = parent.querySelector('div');

        if (parent.querySelectorAll('input')[1].checked == true && e.target.textContent == 'Show more') {
            hiddenElement.style.display = 'block';
            e.target.textContent = 'Hide it';
        } else if (parent.querySelectorAll('input')[1].checked == true && e.target.textContent == 'Hide it') {
            hiddenElement.style.display = 'none';
            e.target.textContent = 'Show more';
        }
    }

    function e(type, attributes, ...content) {
        const result = document.createElement(type);

        for (let [attr, value] of Object.entries(attributes || {})) {
            if (attr.substring(0, 2) == 'on') {
                result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
            } else {
                result[attr] = value;
            }
        }

        content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

        content.forEach(e => {
            if (typeof e == 'string' || typeof e == 'number') {
                const node = document.createTextNode(e);
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });

        return result;
    }
}