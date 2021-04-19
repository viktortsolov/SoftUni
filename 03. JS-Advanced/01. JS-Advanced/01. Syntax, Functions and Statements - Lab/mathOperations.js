function solution(a, b, c){
    let result;

    switch (c) {
        case '+': result = a + b; break;
        case '-': result = a - b; break;
        case '*': result = a * b; break;
        case '/': result = a / b; break;
        case '%': result = a % b; break;
        case '**': result = a ** b; break;
    }

    console.log(result);
}

solution(5, 6, '+');
solution(3, 5.5, '*');