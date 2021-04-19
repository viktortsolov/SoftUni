function solution(a, b){
    let result = 0;

    a = Number(a);
    b = Number(b);

    for (let i = a; i <= b; i++) {
        result += i;
    }

    return result;
}

console.log(solution('1', '5'));
console.log(solution('-8', '20'));