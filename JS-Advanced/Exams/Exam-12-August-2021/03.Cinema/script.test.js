let cinema = require('./script');
let assert = require('chai').assert;

describe("cinema", function () {
    describe("showMovies", function () {
        it("Should work as expected", function () {
            assert.equal('Jonny, Wallker, SpinderMan, SuperMan', cinema.showMovies(['Jonny', 'Wallker', 'SpinderMan', 'SuperMan']))
            assert.equal('1, 2, 3, 4', cinema.showMovies(['1', '2', '3', '4']))
            assert.equal('1, 2, 3, 4', cinema.showMovies([1, 2, 3, 4]))
        });

        it("Should work retunr massege for empty array", function () {
            assert.equal('There are currently no movies to show.', cinema.showMovies([]))
        });
    });

    describe("ticketPrice", function () {
        it("Should throw excerption, if invalid projectionType is passed", function () {
            assert.throw(() => {
                cinema.ticketPrice('not exist');
                cinema.ticketPrice(1);
                cinema.ticketPrice(undefined);
            });
        });

        it("Should return 12.00 for Premiere", function () {
            assert.equal(12, cinema.ticketPrice('Premiere'))
        });

        it("Should return 7.50 for Normal", function () {
            assert.equal(7.50, cinema.ticketPrice('Normal'))
        });

        it("Should return 5.50 for Discount", function () {
            assert.equal(5.50, cinema.ticketPrice('Discount'))
        });
    });

    describe("swapSeatsInHall", function () {
        it("Should return Unsuccessful if firstSeat and secondSeat are equal", function () {
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(20, 20));
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(1, 1));
        });

        it("Should return Unsuccessful if firstSeat is not intiger", function () {
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(1.2, 12));
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(undefined, 12));
        });

        it("Should return Unsuccessful if firstSeat bigger than 20", function () {
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(21, 12));
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(30, 12));
        });

        it("Should return Unsuccessful if firstSeat is less or equal to 0", function () {
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(0, 12));
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(-15, 12));
        });

        it("Should return Unsuccessful if secondSeat is not intiger", function () {
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(12, 1.26));
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(12, undefined));
        });

        it("Should return Unsuccessful if secondSeat bigger than 20", function () {
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(12, 21));
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(12, 30));
        });

        it("Should return Unsuccessful if secondSeat is less or equal to 0", function () {
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(12, 0));
            assert.equal('Unsuccessful change of seats in the hall.', cinema.swapSeatsInHall(12, -25));
        });

        it("Should work correctly", function () {
            assert.equal('Successful change of seats in the hall.', cinema.swapSeatsInHall(12, 2));
            assert.equal('Successful change of seats in the hall.', cinema.swapSeatsInHall(8, 13));
            assert.equal('Successful change of seats in the hall.', cinema.swapSeatsInHall(1, 20));
        });
    });
});
