function solve(number) {
    const isEven = x => x % 2 === 0;
    const isOdd = x => x % 2 !== 0;

    const oddSum = calculateSum(number, isOdd);
    const evenSum = calculateSum(number, isEven);

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

function calculateSum(number, filter) {
    const filteredDigits = number
    .toString()
    .split('')
    .map(Number)
    .filter(filter);

    const sum = filteredDigits.reduce((acc, num) => acc + num, 0);

    return sum;
}

solve(1000435);