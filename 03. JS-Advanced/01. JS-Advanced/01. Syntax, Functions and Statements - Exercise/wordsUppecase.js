function solution(input) {
    let pattern = /\w+/g;
    let arr = input.match(pattern);
    let result = [];
    for (let el of arr) {
        let word = el.toUpperCase();
        result.push(word);
    }
    console.log(result.join(`, `));
}

solution("Hi, how are you?");
solution("hello");