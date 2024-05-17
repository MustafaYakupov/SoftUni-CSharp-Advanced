function solve(number) {
    let numberText = number.toString();
    let currentDigit = numberText[0];
    let isSame = true;
    let sum = Number(currentDigit);

    for (let i = 1; i < numberText.length; i++) {
        if (currentDigit !== numberText[i]) {
            isSame = false;
        }

        currentDigit = numberText[i];
        sum += Number(currentDigit);
    }

    console.log(isSame);
    console.log(sum);
}

solve(2222222);