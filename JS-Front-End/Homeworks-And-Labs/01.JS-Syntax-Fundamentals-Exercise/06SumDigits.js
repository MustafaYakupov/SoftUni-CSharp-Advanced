function solve(number) {
    let sum = 0;

    while (number > 0) {
        sum += number % 10;

        number = Math.trunc(number / 10);
    }

    console.log(sum);
}

function solveWithStrings(number) {
    let textNumber = number.toString();
    let sum = 0;

    for (let i = 0; i < textNumber.length; i++) {
        sum += Number(textNumber[i]);
    }

    console.log(sum);
}

solve(245678);
solveWithStrings(245678);