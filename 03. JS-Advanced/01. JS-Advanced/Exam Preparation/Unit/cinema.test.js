const cinema = require('./cinema');
const {expect, assert} = require('chai');

describe("Cinema tests", function() {
    describe("showMovies Tests", function() {
        it("movieArr is empty",() => {
            let movieArr = [];

            expect(cinema.showMovies(movieArr)).to.equal('There are currently no movies to show.');
        });
     });
});
