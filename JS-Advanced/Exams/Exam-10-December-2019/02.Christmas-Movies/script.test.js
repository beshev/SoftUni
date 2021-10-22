let ChristmasMovies = require('./script');
let {assert,expect} = require('chai');


describe("ChristmasMovies", function () {
    let movies;
    let actors;
    beforeEach(() => {
        movies = new ChristmasMovies();
        actors = ['Test1', 'Test2', 'Test3'];
    })

    describe("constructor", function () {
        it("Should work", function () {
            assert.deepEqual(movies.movieCollection, []);
            assert.deepEqual(movies.watched, {});
            assert.deepEqual(movies.actors, []);
        });
    });

    describe("buyMovie", function () {
        it("Should throw error if already buyed", function () {
            movies.buyMovie('FirstTest', actors);
            assert.throw(() => {
                movies.buyMovie('FirstTest', actors);
            })
        });

        it("Should work", function () {
            assert.equal(movies.buyMovie('FirstTest', actors), 'You just got FirstTest to your collection in which Test1, Test2, Test3 are taking part!');
            assert.equal(movies.movieCollection.length, 1);
        });

        it("Should return only unique actors", function () {
            assert.equal(movies.buyMovie('FirstTest', ['test1','test1','test2']), 'You just got FirstTest to your collection in which test1, test2 are taking part!');
            assert.equal(movies.movieCollection.length, 1);
        });
    });

    describe("discardMovie", function () {
        it("Should throw error if movie not exist", function () {
            assert.throw(() => {
                movies.discardMovie('NonExisting');
            })
        });

        it("Should throw error if movie is not watched", function () {
            movies.buyMovie('FirstMovie', actors);

            assert.throw(() => {
                movies.discardMovie('FirstMovie');
            })
        });

        it("Should work", function () {
            movies.buyMovie('FirstMovie', actors);

            movies.watchMovie('FirstMovie');
            assert.equal(movies.discardMovie('FirstMovie'), 'You just threw away FirstMovie!');
        });
    });

    describe("watchMovie", function () {
        it("Should throw error if movie not exist", function () {
            assert.throw(() => {
                movies.watchMovie('NotExist')
            },Error,'No such movie in your collection!')
        });

        it("Should return three watched a movie", function () {
            movies.buyMovie('FirstMovie', actors);
            movies.watchMovie('FirstMovie');
            movies.watchMovie('FirstMovie');
            movies.watchMovie('FirstMovie');
            assert.equal(movies.watched['FirstMovie'], 3);
        });
    });

    describe("favouriteMovie", function () {
        it("Should throw error if watched is empty", function () {
            assert.throw(() => {
                movies.favouriteMovie();
            })
        });

        it("Should work with many movies", function () {
            movies.buyMovie('First', actors);
            movies.buyMovie('Second', ['1','2','3']);

            movies.watchMovie('First');

            movies.watchMovie('Second');
            movies.watchMovie('Second');
            movies.watchMovie('Second');

            assert.equal(movies.favouriteMovie(), 'Your favourite movie is Second and you have watched it 3 times!')
        });
    });

    describe("mostStarredActors", function () {
        it("Should throw error if no movies in collection", function () {
            assert.throw(() => {
                movies.mostStarredActor();
            })
        });

        it("Should work with actors", function () {
           movies.buyMovie('One',['test1','test2','test3','test4']);
           movies.buyMovie('two',['test1','test2','Test2','test3']);
           movies.buyMovie('three',['test3','test2','some','another']);
           movies.buyMovie('four',['ima','test2','nqma','tva e']);

           assert.equal(movies.mostStarredActor(),'The most starred actor is test2 and starred in 4 movies!');
        });
    });
});
