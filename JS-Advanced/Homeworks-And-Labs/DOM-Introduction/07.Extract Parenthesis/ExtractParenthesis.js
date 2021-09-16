function extract(content) {
    let contentElement = document.getElementById('content');
    let regExp = new RegExp(/\(.*?\)/,'gm');

    let result = contentElement.textContent.match(regExp).map(x => x.replace('(','').replace(')',''));

    return result.join('; ');
}