function solution(array) {
    return array
        .sort((a, b) => a - b)
        .slice(array.length / 2);
}

console.log(solution([4, 7, 2, 5]));
console.log(solution([3, 19, 14, 7, 2, 19, 6]));