const token = sessionStorage.getItem('auth_token');
const baseUrl = 'http://localhost:3030/data/furniture';
let tableBody = document.getElementById('table-body');
tableBody.querySelectorAll('tr').forEach(x => x.remove());

loadFurniture();

let loginForm = document.querySelector('div form[action="/login"]');
if (loginForm) {
  loginForm.addEventListener('submit', onLoginHandler);
}

let registerForm = document.querySelector('div form[action="/register"]');
if (registerForm) {
  registerForm.addEventListener('submit', onRegisterHandler);
}


let logoutButton = document.getElementById('logoutBtn');
logoutButton.addEventListener('click', onLogoutHandler);



function isAuthenticated(isAuth) {
  let userDiv = document.getElementById('user');
  let guestDiv = document.getElementById('guest');

  if (isAuth) {
    userDiv.style.display = 'inline';
    guestDiv.style.display = 'none';

  } else {
    userDiv.style.display = 'none';
    guestDiv.style.display = 'inline';
  }
}

async function onLoginHandler(e) {
  e.preventDefault();
  let formData = new FormData(e.currentTarget);

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

    sessionStorage.setItem('auth_token', user.accessToken);
    sessionStorage.setItem('userId', user._id);

    window.location.pathname = '06.Furniture/homeLogged.html';

  } catch (err) {
    alert(err.message);
  }
}

async function onRegisterHandler(e) {
  e.preventDefault();
  let formData = new FormData(e.currentTarget);

  let email = formData.get('email');
  let password = formData.get('password');
  let repeat = formData.get('rePass');

  if (repeat !== password) {
    alert("Passwords doesn't match");
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

    window.location.pathname = '06.Furniture/homeLogged.html';

  } catch (err) {
    alert(err.message);
  }
}

async function onLogoutHandler() {
  try {
    let response = await fetch('http://localhost:3030/users/logout', {
      method: 'GET',
      headers: { 'X-Authorization': token }
    });

    if (response.status !== 204) {
      throw new Error('User session does not exist');
    }

    sessionStorage.removeItem('auth_token');
    sessionStorage.removeItem('userId');
  } catch (error) {
    alert(error.message);
  }

  window.location.pathname = '06.Furniture/home.html';
}

async function loadFurniture() {
  let response = await fetch(baseUrl);
  let furniture = await response.json();

  furniture.forEach(el => {
    let tr = e('tr', {},
      e('td', {},
        e('img', { src: el.img }, '')
      ),
      e('td', {},
        e('p', {}, el.name)
      ),
      e('td', {},
        e('p', {}, el.price)
      ),
      e('td', {},
        e('p', {}, el.decFactor)
      ),
      e('td', {},
        e('input', { type: 'checkbox' })
      ),
    )
  });

  tableBody.appendChild(tr);
}

function e(type, attr, ...content) {
  const element = document.createElement(type);

  for (const prop in attr) {
    if (prop === 'class') {
      element.classList.add(attr[prop])
    } else if (prop === 'disabled') {
      element.disabled = attr[prop];
    } else {
      element.setAttribute(prop, attr[prop]);
    }
  }

  for (let item of content) {
    if (typeof item == 'string' || typeof item == 'number') {
      item = document.createTextNode(item);
    }

    element.appendChild(item);
  }

  return element;
}