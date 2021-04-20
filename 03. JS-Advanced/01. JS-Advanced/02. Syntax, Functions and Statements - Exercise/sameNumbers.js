function solution(number){
    let areSame = true;
    let numberAsString = String(number);
    let total = 0;

    for (let i = 0; i < numberAsString.length - 1; i++) {
        if (numberAsString[i] != numberAsString[i + 1]) {
            areSame = false;
        }
        total += Number(numberAsString[i]);
    }

    total += Number(numberAsString[numberAsString.length - 1]);
    console.log(areSame);
    console.log(total);
}

solution(1234)