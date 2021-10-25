function addDestination() {
    let fields = document.querySelectorAll('#input input');
    let selectElement = document.getElementById('seasons');
    let tbody = document.getElementById('destinationsList');
    let summaryBoxElemets = {
        summer: document.getElementById('summer'),
        autumn: document.getElementById('autumn'),
        winter: document.getElementById('winter'),
        spring: document.getElementById('spring'),
    }

    let cityElement = fields[0];
    let countryElement = fields[1];
    let season = selectElement.value;

    if (cityElement.value.trim() === '' || countryElement.value.trim() === '') {
        return;
    }


    let tr = e('tr', {},
        e('td', {}, `${cityElement.value}, ${countryElement.value}`),
        e('td', {}, season.substring(0,1).toUpperCase() + season.substring(1)),
    );

    tbody.appendChild(tr);
    summaryBoxElemets[season].value = Number(summaryBoxElemets[season].value) + 1
    cityElement.value = '';
    countryElement.value = '';



    function e(type, attr, ...content) {
        const element = document.createElement(type);

        for (const prop in attr) {
            if (prop === 'class') {
                element.classList.add(attr[prop])
            } else {
                element[prop] = attr[prop];
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
}