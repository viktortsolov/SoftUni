function solve(array) {
    array.sort((a, b) => a - b);

    return `${array[0]} ${array[1]}`;
}

console.log(solve([30, 15, 50, 5]));
console.log(solve([3, 0, 10, 4, 7, 3]));