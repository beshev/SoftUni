import { render, html } from '../node_modules/lit-html/lit-html.js'

function removeClassFromElementById(elementId,className) {
    document.getElementById(elementId).classList.remove(className);
}

function addClassToElementById(elementId,className) {
    document.getElementById(elementId).classList.add(className);
}

export {
    render,
    html
}

export default {
    removeClassFromElementById,
    addClassToElementById,
}