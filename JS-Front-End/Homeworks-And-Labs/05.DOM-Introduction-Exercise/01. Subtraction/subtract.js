function subtract() {
    const firstNumberElement = document.getElementById('firstNumber');
    const secondNumberElement = document.getElementById('secondNumber');
    const output = document.getElementById('result');

    const result = Number(firstNumber.value) - Number(secondNumber.value);
    output.textContent = result;
}