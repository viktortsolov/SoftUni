function solution(array){
    let first = Number([...array].shift());  
    let last = Number([...array].pop());

    console.log(first + last);
}

solution(['20', '30', '40']);
solution(['5', '10']);