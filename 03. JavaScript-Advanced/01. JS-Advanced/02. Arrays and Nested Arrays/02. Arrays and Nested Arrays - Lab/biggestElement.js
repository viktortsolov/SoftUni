function solve(array) {
    let max = array[0][0];

    for (let i = 0; i < array.length; i++) {
        for (let j = 0; j < array[i].length; j++) {
            if (max < array[i][j]) {
                max = array[i][j];
            }
        }
    }

    return max;
}

console.log(solve([[20, 50, 10],
    [8, 33, 145]]
));
console.log(solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
));