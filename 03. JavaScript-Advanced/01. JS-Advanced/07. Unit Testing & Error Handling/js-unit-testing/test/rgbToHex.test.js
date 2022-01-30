const rgbToHex = require('../rgbToHex');
const assert = require('chai').assert;

describe('Test RgbToHexColor functionallity', () => {
    it('Should work when the intervals are 0-255!', () => {
        let red = 1;
        let green = 1;
        let blue = 1;
        let expected = '#010101';

        let actual = rgbToHex(red, green, blue);

        assert.equal(actual, expected);
    });

    it('Should return undefined when the intervals are not in 0-255!', () => {
        let red = 255;
        let green = 255;
        let blue = 256;
        let expected = undefined;

        let actual = rgbToHex(red, green, blue);

        assert.equal(actual, expected);
    });

    it('Should return undefined when the intervals are not the same type!', () => {
        let red = '1';
        let green = 255;
        let blue = 255;
        let expected = undefined;

        let actual = rgbToHex(red, green, blue);

        assert.equal(actual, expected);
    });
});