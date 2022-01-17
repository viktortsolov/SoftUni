function solve(n, m) {
    let nAsNum = Number(n);
    let mAsNum = Number(m);

    let result = 0;

    for (let index = nAsNum; index <= mAsNum; index++) {
        result += index;
    }

    return result;
}

console.log(solve('1', '5'));
console.log(solve('-8', '20'));