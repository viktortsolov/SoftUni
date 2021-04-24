function solution(array){
    array.sort((a, b) => a - b);

    console.log(array[0], array[1]);
}

solution([30, 15, 50, 5]);
solution([3, 0, 10, 4, 7, 3]);