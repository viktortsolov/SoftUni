function solve(array) {
    let result = [];

    for (const number of array) {
        if (number < 0) {
            result.unshift(number);
        } else {
            result.push(number)
        }
    }

    return result.join('\n');
}

console.log(solve([7, -2, 8, 9]));
console.log(solve([3, -2, 0, -1]));