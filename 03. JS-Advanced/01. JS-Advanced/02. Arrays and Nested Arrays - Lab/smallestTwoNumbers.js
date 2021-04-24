function solution(array){
    function compareNumbers(a,b){
        return a - b; // b - a (reversed)
    }

    array.sort(compareNumbers);

    console.log(array[0], array[1]);
}

solution([30, 15, 50, 5]);
solution([3, 0, 10, 4, 7, 3]);