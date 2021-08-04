const pizzUni = require('./pizza-place');
const { expect, assert } = require('chai');

describe("Pizza place tests", function () {
    describe("makeAnOrder tests", () => {
        it('Should return confirmation message when pizza is ordered', () => {
            let order = {
                orderedPizza: 'Margaritta',
            }

            expect(pizzUni.makeAnOrder(order)).to.equal(`You just ordered ${order.orderedPizza}`);
        });

        it('Should return confirmation message when pizza AND drink is ordered', () => {
            let order = {
                orderedPizza: 'Margaritta',
                orderedDrink: 'Coke'
            }

            expect(pizzUni.makeAnOrder(order)).to.equal(`You just ordered ${order.orderedPizza} and ${order.orderedDrink}.`);
        });

        it('Should throw exc message when pizza is not ordered', () => {
            let order = {};

            expect(() => pizzUni.makeAnOrder(order)).to.throw();
        });

        it('Should throw exc message when there is no order', () => {
            expect(() => pizzUni.makeAnOrder()).to.throw();
        });
    });

    describe("getRemainingWork tests", () => {
        it('Should return all orders completed', () => {
            let statusArr = [
                {
                    status: 'ready',
                    pizzaName: 'Margaritta'
                }
            ];

            expect(pizzUni.getRemainingWork(statusArr)).to.equal('All orders are complete!');
        });

        it('Should return remaining pizza (one)', () => {
            let statusArr = [
                { status: 'preparing', pizzaName: 'Margaritta' },
                { status: 'ready', pizzaName: 'Italiana' }
            ];

            expect(pizzUni.getRemainingWork(statusArr)).to.equal(`The following pizzas are still preparing: Margaritta.`);
        });

        it('Should return remaining pizzas (more)', () => {
            let statusArr = [
                { status: 'preparing', pizzaName: 'Margaritta' },
                { status: 'preparing', pizzaName: 'Italiana' }
            ];

            expect(pizzUni.getRemainingWork(statusArr)).to.equal(`The following pizzas are still preparing: Margaritta, Italiana.`);
        });
    });

    describe("orderType tests", () => {
        it('Should return total sum then type of order is Delivery', () => {
            expect(pizzUni.orderType(10, 'Delivery')).to.equal(10);
        });
        it('Should return total sum then type of order is Carry Out', () => {
            expect(pizzUni.orderType(10, 'Carry Out')).to.equal(10 * 0.9);
        });
    });
});