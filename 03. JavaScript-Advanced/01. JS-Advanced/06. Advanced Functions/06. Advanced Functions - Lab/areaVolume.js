function solve(area, volume, input) {
    let coordinatesArr = JSON.parse(input);
    let resultArr = [];

    for (const coordinates of coordinatesArr) {
        resultArr.push({
            area: area.call(coordinates),
            vol: vol.call(coordinates)
        });
    }

    console.log(resultArr);
}


function area() {
    return Math.abs(this.x * this.y);
}

function vol() {
    return Math.abs(this.x * this.y * this.z);
}

solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`
    );