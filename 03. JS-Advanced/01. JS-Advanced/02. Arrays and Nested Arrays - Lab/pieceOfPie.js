function solution(array, firstPie, secondPie){
    const start = array.indexOf(firstPie);
    const end = array.indexOf(secondPie) + 1;

    const result = array.slice(start, end);

    return result;
}