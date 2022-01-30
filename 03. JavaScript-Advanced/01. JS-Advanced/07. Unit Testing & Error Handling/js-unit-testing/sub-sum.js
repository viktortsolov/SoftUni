function subSum(numbers, start, end) {
    let result = numbers.slice(start, end).reduce((a, x) => a + x, 0);

    return result;
}

function test1_subSum() {
    //Arrange
    let numbers = [10, 20, 30, 40, 50, 60];
    let start = 3;
    let end = 300;

    let expectedResult = 150;

    //Act
    let actualResult = subSum(numbers, start, end);
    
    //Assert
    if (actualResult === expectedResult) {
        console.log('Test 1 passed!');
    } else {
        console.error('Test 1 failed!');
    }
}

test1_subSum();