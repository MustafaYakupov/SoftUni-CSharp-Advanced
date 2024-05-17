function solve(numbersArray, rotations) {
    for (let i = 0; i < rotations; i++) {
        let rotatedNumbers = [];
        let firstNumber = numbersArray[0];

        for (let j = 1; j < numbersArray.length; j++) {
            rotatedNumbers[j - 1] = numbersArray[j];
        }

        rotatedNumbers[rotatedNumbers.length] = firstNumber;
        numbersArray = rotatedNumbers;
    }

    console.log(numbersArray.join(' '));
}

function quickSolve (numbersArray, rotations) {
    for (let i = 0; i < rotations; i++) {
        let firstElement = numbersArray.shift();
        numbersArray.push(firstElement);
    }

    console.log(numbersArray.join(' '));
}

solve([51, 47, 32, 61, 21], 2);
quickSolve([51, 47, 32, 61, 21], 2);