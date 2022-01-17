function solve(fruit, weight, price) {
    const weightKilograms = weight / 1000;
    let money = weightKilograms * price;

    return `I need $${money.toFixed(2)} to buy ${weightKilograms.toFixed(2)} kilograms ${fruit}.`;
}

console.log(solve('orange', 2500, 1.80));
console.log(solve('apple', 1563, 2.35));