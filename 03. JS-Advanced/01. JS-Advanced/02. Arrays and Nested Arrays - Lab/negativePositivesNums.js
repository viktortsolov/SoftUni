function solution(array){
    const result = [];

    for (let num of array){
        if(num < 0){
            result.unshift(num);
        }
        else{
            result.push(num);
        }
    }

    console.log(result.join('\n'));
}

solution([7, -2, 8, 9]);
solution([3, -2, 0, -1]);