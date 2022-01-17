function solve(year, month, day) {
    const date = Date(`${year}-${month}-${day}`);
    
    const previousDate = Date(date - 1);

    console.log(date);
    console.log(previousDate);
}

solve(2016, 9, 30);
solve(2016, 10, 1);