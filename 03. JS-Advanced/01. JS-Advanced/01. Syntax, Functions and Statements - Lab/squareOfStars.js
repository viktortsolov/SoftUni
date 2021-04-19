function solution(a){
    if(typeof(a) !== 'Null'){

        for (let i = 0; i < a; i++) {
            console.log('*'.repeat(a));
        }
    }
    else
    {
        console.log('A')
        for (let i = 0; i < 5; i++) {
            console.log('*'.repeat(5));
        }
    }
}


solution();