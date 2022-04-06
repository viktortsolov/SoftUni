const bookSelection = require('../bookSelection.js');
const { expect } = require('chai');

describe("bookSelection Tests", function () {
    describe("isGenreSuitable Tests", function () {
        it("Should return that the age is not suitable if genre is Thriller", function () {
            let genre = 'Thriller';
            let age = 12;

            expect(bookSelection.isGenreSuitable(genre, age)).to.be.deep.equal(`Books with ${genre} genre are not suitable for kids at ${age} age`);
        });

        it("Should return that the age is not suitable if genre is Horror", function () {
            let genre = 'Thriller';
            let age = 11;

            expect(bookSelection.isGenreSuitable(genre, age)).to.be.deep.equal(`Books with ${genre} genre are not suitable for kids at ${age} age`);
        });

        it("Should return that the books are suitable. (Thriller)", function () {
            let genre = 'Thriller';
            let age = 13;

            expect(bookSelection.isGenreSuitable(genre, age)).to.be.deep.equal(`Those books are suitable`);
        });

        it("Should return that the books are suitable. (Horror)", function () {
            let genre = 'Horror';
            let age = 61;

            expect(bookSelection.isGenreSuitable(genre, age)).to.be.deep.equal(`Those books are suitable`);
        });

        it("Should return that the books are suitable. (Fiction)", function () {
            let genre = 'Fiction';
            let age = 61;

            expect(bookSelection.isGenreSuitable(genre, age)).to.be.deep.equal(`Those books are suitable`);
        });

        it("Should return that the books are suitable. (Biography)", function () {
            let genre = 'Biography';
            let age = 11;

            expect(bookSelection.isGenreSuitable(genre, age)).to.be.deep.equal(`Those books are suitable`);
        });
    });

    describe('isItAffordable Tests', () => {
        it('Should throw error if price is not integer.', () => {
            let price = '12';
            let budget = 12;

            expect(() => bookSelection.isItAffordable(price, budget)).to.throw(`Invalid input`);
        })

        it('Should throw error if budget is not integer.', () => {
            let price = 12;
            let budget = '12';

            expect(() => bookSelection.isItAffordable(price, budget)).to.throw(`Invalid input`);
        })

        it('Should return that you do not have enough money.', () => {
            let price = 10;
            let budget = 9;

            expect(bookSelection.isItAffordable(price, budget)).to.deep.equal(`You don't have enough money`);
        })

        it('Should return that you bought the book successfully.', () => {
            let price = 10;
            let budget = 11;

            expect(bookSelection.isItAffordable(price, budget)).to.deep.equal(`Book bought. You have ${budget - price}$ left`);
        })
    });

    describe('suitableTitles Tests', () => {
        it('Should throw error if array is not array.', () => {
            let array = '[Horror]';
            let wantedGenre = 'Horror';

            expect(() => bookSelection.suitableTitles(array, wantedGenre)).to.throw(`Invalid input`);
        })

        it('Should throw error if wantedGenre is not string.', () => {
            let array = [{ title: "The Da Vinci Code", genre: "Thriller" }];
            let wantedGenre = 12;

            expect(() => bookSelection.suitableTitles(array, wantedGenre)).to.throw(`Invalid input`);
        })

        it('Should return titles of wantedGenre.', () => {
            let array = [{ title: "The Da Vinci Code", genre: "Thriller" }];
            let wantedGenre = 'Thriller';

            expect(bookSelection.suitableTitles(array, wantedGenre)).to.deep.equal(['The Da Vinci Code']);
        })

        it('Should return 0 titles of wantedGenre.', () => {
            let array = [];
            let wantedGenre = 'Thriller';

            expect(bookSelection.suitableTitles(array, wantedGenre)).to.deep.equal([]);
        })
    });
});
