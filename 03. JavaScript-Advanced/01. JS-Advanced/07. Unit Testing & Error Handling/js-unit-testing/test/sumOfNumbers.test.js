const assert = require('chai').assert;
const sum = require('../sumOfNumbers');

describe('Test sum functionallity', () => {

    it('Should add positive numbers!', () => {
        let input = [1, 2, 3, 4, 5];
        let expected = 15;

        let actual = sum(input);

        assert.strictEqual(actual, expected);
    });

    it('Should return flase when adding positive numbers!', () => {
        let input = [10, 20, 30, 40, 50];
        let expected = 15;

        let actual = sum(input);

        assert.notEqual(actual, expected);
    });

    it('Should pass when adding negative numbers!', () => {
        let input = [-1, -2, -3];
        let expected = -6;

        let actual = sum(input);

        assert.strictEqual(actual, expected);
    });
});