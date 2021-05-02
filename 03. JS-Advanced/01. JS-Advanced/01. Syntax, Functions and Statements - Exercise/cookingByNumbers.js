function solution(numberAsString, operationOne, operationTwo, operationThree, operationFour, operationFive) {
    let array = [operationOne, operationTwo, operationThree, operationFour, operationFive];
    let number = Number(numberAsString);

    array.forEach(element => {
        switch (element) {
            case 'chop':
            number /= 2;
                break;

            case 'dice':
            number = Math.sqrt(number);
                break;

            case 'spice':
            number += 1;
                break;

            case 'bake':
            number *= 3;
                break;

            case 'fillet':
            number -= number * 0.2;
                break;
        }

        console.log(number);
    });
}

solution('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solution('9', 'dice', 'spice', 'chop', 'bake', 'fillet');