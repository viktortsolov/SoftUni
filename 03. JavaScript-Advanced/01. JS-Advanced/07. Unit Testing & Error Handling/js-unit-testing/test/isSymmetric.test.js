const isSymmetric = require('../isSymmetric');
const assert = require('chai').assert;

describe('Test isSymemetric functionallity', () => {
    it('Should pass when symmetric array is provided!', () => {
        let input = [1, 2, 3, 2, 1];
        let expected = true;

        let actual = isSymmetric(input);

        assert.equal(actual, expected);
    });

    it('Should fail when non-symmetric array is provied!', () => {
        let input = [1, 2, 3, 2, 2];
        let expected = false;

        let actual = isSymmetric(input);

        assert.equal(actual, expected);
    });

    it('Should fail when non-array is provied as an argument!', () => {
        assert.equal(isSymmetric(null), false);
        assert.equal(isSymmetric({}), false);
        assert.equal(isSymmetric(''), false);
        assert.equal(isSymmetric(0), false);
        assert.equal(isSymmetric(true), false);
        assert.equal(isSymmetric(undefined), false);
    });

    it('Should pass when an empty array is provided!', () => {
        assert.equal(isSymmetric([]), true);
    });

    it('Should pass when it is diff. type!', () => {
        assert.equal(isSymmetric(['pesho', 'gosho', 'pesho']), true);
    });

    it('Should fail when 1 != string(1)!', () => {
        assert.equal(isSymmetric([1, '1']), false);
    });
})