function solve(kmH, drivingAtmosphere) {
    kmH = Number(kmH);

    let result;
    let status;
    let speeding;

    switch (drivingAtmosphere) {
        case 'motorway':
            speeding = kmH - 130;
            if (kmH <= 130) {
                result = `Driving ${kmH} km/h in a 130 zone`;
            } else if (speeding <= 20) {
                status = 'speeding';
                result = `The speed is ${speeding} km/h faster than the allowed speed of 130 - ${status}`;
            } else if (speeding <= 40) {
                status = 'excessive speeding';
                result = `The speed is ${speeding} km/h faster than the allowed speed of 130 - ${status}`;
            } else {
                status = 'reckless driving';
                result = `The speed is ${speeding} km/h faster than the allowed speed of 130 - ${status}`
            }
            break;

        case 'interstate':
            speeding = kmH - 90;
            if (kmH <= 90) {
                result = `Driving ${kmH} km/h in a 90 zone`;
            } else if (speeding <= 20) {
                status = 'speeding';
                result = `The speed is ${speeding} km/h faster than the allowed speed of 90 - ${status}`;
            } else if (speeding <= 40) {
                status = 'excessive speeding';
                result = `The speed is ${speeding} km/h faster than the allowed speed of 90 - ${status}`;
            } else {
                status = 'reckless driving';
                result = `The speed is ${speeding} km/h faster than the allowed speed of 90 - ${status}`
            }
            break;

        case 'city':
            speeding = kmH - 50;
            if (kmH <= 50) {
                result = `Driving ${kmH} km/h in a 50 zone`;
            } else if (speeding <= 20) {
                status = 'speeding';
                result = `The speed is ${speeding} km/h faster than the allowed speed of 50 - ${status}`;
            } else if (speeding <= 40) {
                status = 'excessive speeding';
                result = `The speed is ${speeding} km/h faster than the allowed speed of 50 - ${status}`;
            } else {
                status = 'reckless driving';
                result = `The speed is ${speeding} km/h faster than the allowed speed of 50 - ${status}`
            }
            break;

        case 'residential':
            speeding = kmH - 20;
            if (kmH <= 20) {
                result = `Driving ${kmH} km/h in a 20 zone`;
            }  else if (speeding <= 20) {
                status = 'speeding';
                result = `The speed is ${speeding} km/h faster than the allowed speed of 20 - ${status}`;
            } else if (speeding <= 40) {
                status = 'excessive speeding';
                result = `The speed is ${speeding} km/h faster than the allowed speed of 20 - ${status}`;
            } else {
                status = 'reckless driving';
                result = `The speed is ${speeding} km/h faster than the allowed speed of 20 - ${status}`
            }
            break;
    }

    return result;
}

console.log(solve(40, 'city'));
console.log(solve(21, 'residential'));
console.log(solve(120, 'interstate'));
console.log(solve(200, 'motorway'));