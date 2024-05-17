function solve(numbersCountToTake, input) {
    let result = '';

    for (let i = numbersCountToTake - 1; i >= 0; i--) {
        result += input[i] + ' ';
    }

    console.log(result);
}

function solve2(numbersCountToTake, input) {
    let result = input
    .slice(0, numbersCountToTake)
    .reverse()
    .join(' ');

    console.log(result);
}

solve(3, [10, 20, 30, 40, 50]);
solve2(3, [10, 20, 30, 40, 50]);