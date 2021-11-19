async function getInfo() {
    let input = document.getElementById('stopId');
    let stopName = document.getElementById('stopName');

    let stopId = input.value;
    let url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;

    let ul = document.getElementById('buses');
    ul.innerHTML = '';
    input.value = '';
    
    try {
        let response = await fetch(url);
        let data = await response.json();

        stopName.textContent = data.name;
        for (const bus in data.buses) {
            ul.appendChild(e('li', {}, `Bus ${bus} arrives in ${data.buses[bus]} minutes`))
        }

    } catch (error) {
        stopName.textContent = 'Error';
    }
}


function e(type, attr, ...content) {
    const element = document.createElement(type);

    for (const prop in attr) {
        if (prop === 'class') {
            element.classList.add(attr[prop])
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
