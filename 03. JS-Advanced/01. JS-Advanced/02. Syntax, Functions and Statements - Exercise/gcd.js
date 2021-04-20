function solution(numberOne, numberTwo){
    let maxgcd;
    let max = numberOne;
    if(max < numberTwo){
        max = numberTwo;
    }
    for (let i = 1; i <= max; i++) {
    if (numberOne % i == 0 && numberTwo % i == 0) {
        maxgcd = i;
    }
    }
    console.log(maxgcd);
}

solution(2154, 458)
solution(15, 5)