function solve(currentSpeed, area) {
    let speedLimit = 0;

    switch (area) {
        case 'motorway':
            speedLimit = 130;
            break;
        case 'interstate':
            speedLimit = 90;
            break;
        case 'city':
            speedLimit = 50;
            break;
        case 'residential':
            speedLimit = 20;
            break;
    }

    const speedDifference = currentSpeed - speedLimit;

    if (speedDifference <= 0) {
       return console.log(`Driving ${currentSpeed} km/h in a ${speedLimit} zone`);
    } 

    //speeding
    let status = '';
    if (speedDifference <= 20) {
        status = 'speeding'; 
    } else if (speedDifference <= 40) {
        status = 'excessive speeding';
    } else {
        status = 'reckless driving';
    }

    console.log(`The speed is ${speedDifference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
}

solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');