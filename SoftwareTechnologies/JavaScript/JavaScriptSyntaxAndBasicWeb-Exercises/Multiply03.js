function solve(arr) {

    let firstNum = Number(arr[0]);
    let secondNum = Number(arr[1]);

    let output;

    if(firstNum <= secondNum){
        output = multiply(firstNum, secondNum);
    }else{
        output = divide(firstNum, secondNum);
    }

    console.log(output);

    function multiply(firstNum, secondNum) {
        return firstNum * secondNum;
    }

    function divide(firstNum, secondNum) {
        return firstNum / secondNum;
    }
}
