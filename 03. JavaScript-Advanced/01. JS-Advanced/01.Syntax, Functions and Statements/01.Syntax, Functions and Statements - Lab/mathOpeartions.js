function solve(numOne, numTwo, operator) {
    let result;

    switch (operator) {
        case '+':
            result = numOne + numTwo;
            break;
        case '-':
            result = numOne - numTwo;
            break;
        case '/':
            result = numOne / numTwo;
            break;
        case '*':
            result = numOne * numTwo;
            break;
        case '%':
            result = numOne % numTwo;
            break;
        case '**':
            result = numOne ** numTwo;
            break;
    }

    console.log(result);
}

solve(5, 6, '+');
solve(3, 5.5, '*');