function solve(firstNumber, secondsNumber, operator) {
    let result = 0;
    switch (operator) {
        case '+': result = firstNumber + secondsNumber;
            break;
        case '-': result = firstNumber - secondsNumber;
            break;
        case '*': result = firstNumber * secondsNumber;
            break;
        case '/': result = firstNumber / secondsNumber;
            break;
        case '%': result = firstNumber % secondsNumber;
            break;
        case '**': result = firstNumber ** secondsNumber;
            break;
    }

    console.log(result);
}

solve(5, 5, '*');