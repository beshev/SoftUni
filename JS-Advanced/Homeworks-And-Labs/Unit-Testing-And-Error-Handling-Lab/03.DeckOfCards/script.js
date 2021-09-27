function printDeckOfCards(cards) {
    let result = [];

    for (const cardInfo of cards) {
        let cardFace = cardInfo.length > 2 ? cardInfo.slice(0,2) : cardInfo[0];
        let cardSuit = cardInfo.length > 2 ? cardInfo[2] : cardInfo[1];

        try {
            result.push(createCard(cardFace, cardSuit));
        } catch (error) {
                console.log(`Invalid card: ${cardInfo}`);
            return;
        }
    }
    
    console.log(result.join(' '));


    function createCard(face, suit) {
        var allowedFaces = ['2','3','4','5','6','7','8','9','10','J','Q','K','A'];
        var allowedSuits = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663',
        };
    
    
        if (!allowedFaces.includes(face) || !Object.keys(allowedSuits).includes(suit)) {
            throw new Error();
        }
    
        let cardObj = {
            face: face,
            suit: suit,
            toString: function () {
                return `${this.face}${allowedSuits[suit]}`;
            }
        }
    
        return cardObj;
    }
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);