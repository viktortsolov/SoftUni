function solve(param) {
    let result;

    if (typeof(param) == 'number') {
        result = Math.pow(param, 2) * Math.PI;
        console.log(result.toFixed(2));
    } else{
        result = `We can not calculate the circle area, because we receive a ${typeof(param)}.`;
        console.log(result);
    }
}

solve(5);
solve('Viktor');