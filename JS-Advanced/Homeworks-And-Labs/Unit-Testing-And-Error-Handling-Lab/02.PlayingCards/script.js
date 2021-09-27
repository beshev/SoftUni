function createCard(face, suit) {
    var allowedFaces = ['2','3','4','5','6','7','8','9','10','J','Q','K','A'];
    var allowedSuits = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\u2663',
    };


    if (!allowedFaces.includes(face) || !Object.keys(allowedSuits).includes(suit)) {
        throw new Error('Error');
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


console.log(createCard('A', 'S').toString());
console.log(createCard('10', 'H').toString());
console.log(createCard('1', 'C').toString());