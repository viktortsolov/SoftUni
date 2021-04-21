function solution(kmPerHour, area){
    let result;

    switch (area) {
        case 'motorway':
            if (kmPerHour <= 130) {
                result = `Driving ${kmPerHour} km/h in a 130 zone`;
            }
            else{
                if (kmPerHour - 130 <= 20) {
                    result = `The speed is ${kmPerHour - 130} km/h faster than the allowed speed of 130 - speeding`;
                }
                else if (kmPerHour - 130 <= 40) {
                    result = `The speed is ${kmPerHour - 130} km/h faster than the allowed speed of 130 - excessive speeding`;
                }
                else{
                    result = `The speed is ${kmPerHour - 130} km/h faster than the allowed speed of 130 - reckless driving`;
                }
            }
            return result;
            break;
    
        case 'interstate':
            if (kmPerHour <= 90) {
                result = `Driving ${kmPerHour} km/h in a 90 zone`;
            }
            else{
                if (kmPerHour - 90 <= 20) {
                    result = `The speed is ${kmPerHour - 90} km/h faster than the allowed speed of 90 - speeding`;
                }
                else if (kmPerHour - 90 <= 40) {
                    result = `The speed is ${kmPerHour - 90} km/h faster than the allowed speed of 90 - excessive speeding`;
                }
                else{
                    result = `The speed is ${kmPerHour - 90} km/h faster than the allowed speed of 90 - reckless driving`;
                }
            }
            return result;
            break;

        case 'city':
            if (kmPerHour <= 50) {
                result = `Driving ${kmPerHour} km/h in a 50 zone`;
            }
            else{
                if (kmPerHour - 50 <= 20) {
                    result = `The speed is ${kmPerHour - 50} km/h faster than the allowed speed of 50 - speeding`;
                }
                else if (kmPerHour - 50 <= 40) {
                    result = `The speed is ${kmPerHour - 50} km/h faster than the allowed speed of 50 - excessive speeding`;
                }
                else{
                    result = `The speed is ${kmPerHour - 50} km/h faster than the allowed speed of 50 - reckless driving`;
                }
            }
            return result;
            break;

        case 'residential':
            if (kmPerHour <= 20) {
                result = `Driving ${kmPerHour} km/h in a 20 zone`;
            }
            else{
                if (kmPerHour - 20 <= 20) {
                    result = `The speed is ${kmPerHour - 20} km/h faster than the allowed speed of 20 - speeding`;
                }
                else if (kmPerHour - 20 <= 40) {
                    result = `The speed is ${kmPerHour - 20} km/h faster than the allowed speed of 20 - excessive speeding`;
                }
                else{
                    result = `The speed is ${kmPerHour - 20} km/h faster than the allowed speed of 20 - reckless driving`;
                }
            }
            return result;
            break;
    }
}

console.log(solution(40, 'city'));
console.log(solution(21, 'residential'));
console.log(solution(120, 'interstate'));
console.log(solution(200, 'motorway'));