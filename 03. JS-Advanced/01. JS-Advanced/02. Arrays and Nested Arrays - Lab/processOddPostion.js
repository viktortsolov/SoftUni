function solution(array){
    const result = array.forEach((x, i) => i % 2 != 0);

    return result;
}

console.log(solution([10, 15, 20, 25]));