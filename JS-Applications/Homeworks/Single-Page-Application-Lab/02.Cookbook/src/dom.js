export function e(type, attr, ...content) {
    const element = document.createElement(type);

    for (const prop in attr) {
        if (prop === 'class') {
            element.classList.add(attr[prop])
        } else {
            element.setAttribute(prop, attr[prop]);
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    for (let item of content) {
        if (typeof item == 'string' || typeof item == 'number') {
            item = document.createTextNode(item);
        }

        element.appendChild(item);
    }

    return element;
}