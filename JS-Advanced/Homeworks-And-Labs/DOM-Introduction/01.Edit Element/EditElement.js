function editElement(element, match, replacer) {
    // TODO
    let matcher = new RegExp(match,'g');

   element.textContent = element.textContent.replace(matcher,replacer);
}