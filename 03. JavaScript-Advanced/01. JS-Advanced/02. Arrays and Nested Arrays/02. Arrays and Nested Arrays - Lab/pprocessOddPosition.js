function solve(array) {
    let result = [];

    for (let i = 0; i < array.length; i++) {
        if (i % 2 != 0) {
            result.push(array[i]);
        }
    }

    result = result
        .map(x => x *= 2)
        .reverse();

    return result.join(' ');
}

console.log(solve([10, 15, 20, 25]));
console.log(solve([3, 0, 10, 4, 7, 3]));