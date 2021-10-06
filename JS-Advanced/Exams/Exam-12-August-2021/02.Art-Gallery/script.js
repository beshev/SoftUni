class ArtGallery{
    constructor(creator){
        this.creator = creator;
        this._possibleArticles = {
            picture: 200,
            photo: 50,
            item: 250,
        }
        this._listOfArticles = [];
        this._guests = []; 
    }

    addArticle(articleModel, articleName, quantity){
        quantity = Number(quantity);
        articleModel = articleModel.toLowerCase();

        if (!this._possibleArticles[articleModel]) {
            throw Error('This article model is not included in this gallery!');
        }

        let article = this._listOfArticles.find(x => x.articleName == articleName && x.articleModel == articleModel);
        if (article) {
            article.quantity += quantity;
        } else {
            let newArticle = {
                articleModel,
                articleName,
                quantity,
            }

            this._listOfArticles.push(newArticle);
        }
        // !! check quantity for already exist article
        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality){
        if (this._guests.some(x => x.guestName == guestName)) {
            throw new Error(`${guestName} has already been invited.`)
        }

        let newGuest = {
            guestName,
            points: personality === 'Vip' ? 500 : personality === 'Middle' ? 250 : 50,
            purchaseArticle: 0,
        }

        this._guests.push(newGuest);

        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName){
        articleModel = articleModel.toLowerCase();

        let article = this._listOfArticles.find(x => x.articleName == articleName);
        if (!article || article.articleModel != articleModel) {
            throw new Error(`This article is not found.`);
        }

        if (article.quantity == 0) {
            return `The ${articleName} is not available.`;
        }

        let guest = this._guests.find(x => x.guestName == guestName);
        if (!guest) {
            return 'This guest is not invited.';
        }

        if (guest.points < this._possibleArticles[articleModel]) {
            return 'You need to more points to purchase the article.';
        }

        guest.points = guest.points - this._possibleArticles[articleModel];
        article.quantity--;
        guest.purchaseArticle++;

        return `${guestName} successfully purchased the article worth ${this._possibleArticles[articleModel]} points.`;
    }

    showGalleryInfo(criteria){
        let result = [];
        if (criteria === 'article') {
            result.push('Articles information:');

            this._listOfArticles.forEach(ar => {
                result.push(`${ar.articleModel} - ${ar.articleName} - ${ar.quantity}`);
            });
        } else if (criteria === 'guest') {
            result.push('Guests information:');

            this._guests.forEach(g => {
                result.push(`${g.guestName} - ${g.purchaseArticle}`);
            });
        }

        return result.join('\n');
    }
}



