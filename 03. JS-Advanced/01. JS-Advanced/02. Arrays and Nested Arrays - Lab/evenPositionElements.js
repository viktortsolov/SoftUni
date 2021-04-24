function solution(array){
    let result = [];

    for (let i = 0; i < array.length; i+=2) {
            result[result.length] = array[i];
    }

    console.log(result.join(' '));
}

solution(['20', '30', '40', '50', '60']);
solution(['5', '10']);