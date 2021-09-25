function getArticleGenerator(articles) {
    let contentElement = document.getElementById('content');

    return function showNext() {
       if (articles.length > 0) {
        let article = document.createElement('article');
        article.textContent = articles.shift();
        contentElement.appendChild(article);
       }
    }
}
