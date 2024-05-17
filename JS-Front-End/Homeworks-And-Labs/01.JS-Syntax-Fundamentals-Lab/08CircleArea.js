function solve(input) {
    if(typeof(input) === 'string') {
        console.log('We can not calculate the circle area, because we receive a string.');
    } else {
        let result = Math.pow(input, 2) * Math.PI;
        console.log(result.toFixed(2));
    }
}

solve(5);