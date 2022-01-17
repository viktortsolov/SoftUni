function solve(numberOne, numberTwo) {

    while (numberTwo != 0) {
        let temp = numberTwo;
        numberTwo = numberOne % numberTwo;
        numberOne = temp;
    }

    return numberOne;
}

console.log(solve(15, 5));
console.log(solve(2154, 458));