function solution(array){
    let result = '';

    for (let i = 0; i < array.length; i++) {
        if (i % 2 == 0) {
            result += array[i];
            result += ' ';
        }
    }

    console.log(result);
}

solution(['20', '30', '40', '50', '60']);
solution(['5', '10']);