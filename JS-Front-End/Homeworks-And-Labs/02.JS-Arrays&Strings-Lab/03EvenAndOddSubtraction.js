function solve(array) {
    let result = 0;

    let evenNumbersSum = 0;
    let oddNumbersSum = 0;

    for (let i = 0; i < array.length; i++) {
        array[i] = Number(array[i]);
        
        if (array[i] % 2 ===  0) {
            evenNumbersSum += array[i];
        } else {
            oddNumbersSum += array[i];
        }
    }

    result = evenNumbersSum - oddNumbersSum;
    console.log(result);
}

function solve2(numbers) {
    let result = numbers.reduce((sum, num) => num % 2 === 0 ? sum + num : sum - num, 0);

    console.log(result);
}

solve([1,2,3,4,5,6]);
solve2([1,2,3,4,5,6]);