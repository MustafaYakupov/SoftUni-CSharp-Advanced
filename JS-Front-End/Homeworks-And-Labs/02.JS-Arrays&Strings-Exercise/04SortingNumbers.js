function solve(numbersArray) {
    let resultArray = [];
    numbersArray.sort((a, b) => a - b);

    while (numbersArray.length > 0) {
        let firstNumber = numbersArray.shift();
        let lastNumber = numbersArray.pop();
        resultArray.push(firstNumber);

        if (lastNumber) {
            resultArray.push(lastNumber);
        }
    }

    return resultArray;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));