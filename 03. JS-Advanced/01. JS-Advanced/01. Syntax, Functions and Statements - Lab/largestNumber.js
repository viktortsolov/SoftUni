function solution(a, b, c){
    let max = a;
    if(b > max)
    {
        max = b;
    }
    if(c > max)
    {
        max = c;
    }

    console.log(`The largest number is ${max}.`)
}

solution(5, -3, 16);