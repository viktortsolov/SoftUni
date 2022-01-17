function solve(input) {
    let inputAsString = String(input);
    let areTheNumbersTheSame = true;
    let sum = Number(inputAsString[0]);

    for (let index = 0; index < inputAsString.length - 1; index++) {
        if(inputAsString[index] != inputAsString[index + 1]){
            areTheNumbersTheSame = false;
        }

        sum += Number(inputAsString[index + 1]);
    }

    if (areTheNumbersTheSame) {
        console.log(areTheNumbersTheSame);
    } else {
        console.log(areTheNumbersTheSame);
    }

    console.log(sum);
}

solve(2222222);
solve(1234);