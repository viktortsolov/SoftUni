function solution(input) {
    const result = {};

    input.forEach((entry) => {
        const [key, value] = entry.split(" <-> ");
        if (result[key]) {
            result[key] += Number(value);
        }
        else {
            result[key] = Number(value);
        }
    })

    return result;
}

console.log(solution(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000'])
)