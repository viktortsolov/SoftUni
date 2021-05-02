function solution(fruit, grams, price){
    let kilograms = grams / 1000;
    let totalPrice = kilograms * price;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${kilograms.toFixed(2)} kilograms ${fruit}.`)
}

solution('orange', 2500, 1.80)
solution('apple', 1563, 2.35)