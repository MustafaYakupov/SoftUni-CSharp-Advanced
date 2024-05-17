function solve(numbersArray) {
    numbersArray.forEach(printPalindromeResult);
}

function isPalindrome(number) {
    let forwardNumber = number.toString();
    let reversedNUmber = forwardNumber.split('').reverse().join('');
    
    return forwardNumber === reversedNUmber;
}

function printPalindromeResult(number) {
    console.log(isPalindrome(number))
}

solve([123,323,421,121]);