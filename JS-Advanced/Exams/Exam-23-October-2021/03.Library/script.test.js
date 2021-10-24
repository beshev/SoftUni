let library = require('./script');
let assert = require('chai').assert;

describe('library', () => {
    describe('calcPriceOfBook', () => {
        it('Should throw error if name of book is not a string', () => {
            assert.throw(() => {
                library.calcPriceOfBook(2, 2000);
            },Error,'Invalid input')

            assert.throw(() => {
                library.calcPriceOfBook(true, 2000);
            },Error,'Invalid input')

            assert.throw(() => {
                library.calcPriceOfBook(undefined, 2000);
            },Error,'Invalid input')
        })

        it('Should throw error if price of book is not a intiger number', () => {
            assert.throw(() => {
                library.calcPriceOfBook('Limitless', 2.2);
            })

            assert.throw(() => {
                library.calcPriceOfBook('Mecho pux', undefined);
            })

            assert.throw(() => {
                library.calcPriceOfBook('Think and grow', '2');
            })
        })

        it('Should make discount for book less or equal than 1980', () => {
            assert.equal(library.calcPriceOfBook('Limitless', 1980), 'Price of Limitless is 10.00');
            assert.equal(library.calcPriceOfBook('Mecho pux', 1970), 'Price of Mecho pux is 10.00');
        })

        it('Should work', () => {
            assert.equal(library.calcPriceOfBook('Limitless', 2000), 'Price of Limitless is 20.00');
            assert.equal(library.calcPriceOfBook('Mecho pux', 1981), 'Price of Mecho pux is 20.00');
        })
    })

    describe('findBook', () => {
        it('Should throw Error if bookArray is empty', () => {
            assert.throw(() => {
                library.findBook([],'Limitless')
            })
        })

        it('Should show message for existi book', () => {
            assert.equal(library.findBook(["Troy", "Life Style", "Torronto"],'Troy'), 'We found the book you want.');
            assert.equal(library.findBook(["Troy", "Life Style", "Limitless"],'Limitless'), 'We found the book you want.');
            assert.equal(library.findBook(["Troy", "Mecho pux", "Torronto"],'Mecho pux'), 'We found the book you want.');
        })

        it('Should show message for non-exist book', () => {
            assert.equal(library.findBook(["Troy", "Life Style", "Torronto"],'Limitless'), 'The book you are looking for is not here!');
            assert.equal(library.findBook(["Troy", "Life Style", "Limitless"],'Mecho pux'), 'The book you are looking for is not here!');
            assert.equal(library.findBook(["Troy", "Mecho pux", "Torronto"],'Life Style'), 'The book you are looking for is not here!');
        })
    })

    describe('arrangeTheBooks', () => {
        it('Should throw error if book count is not a integer number or is negative number', () => {
            assert.throw(() => {
                library.arrangeTheBooks(2.2);
            })

            assert.throw(() => {
                library.arrangeTheBooks('2');
            })

            assert.throw(() => {
                library.arrangeTheBooks(undefined);
            })

            assert.throw(() => {
                library.arrangeTheBooks(-1);
            })

            assert.throw(() => {
                library.arrangeTheBooks(-10);
            })
        })

        it('Should return message if book count is less or equal to availableSpace', () => {
           assert.equal(library.arrangeTheBooks(40),'Great job, the books are arranged.');
           assert.equal(library.arrangeTheBooks(29),'Great job, the books are arranged.');
           assert.equal(library.arrangeTheBooks(10),'Great job, the books are arranged.');
           assert.equal(library.arrangeTheBooks(0),'Great job, the books are arranged.');
        })

        it('Should return message if book count is bigger than availableSpace', () => {
            assert.equal(library.arrangeTheBooks(41),'Insufficient space, more shelves need to be purchased.');
            assert.equal(library.arrangeTheBooks(50),'Insufficient space, more shelves need to be purchased.');
         })
    })
})