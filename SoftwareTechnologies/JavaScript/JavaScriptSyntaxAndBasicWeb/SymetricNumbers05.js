function solve(arr) {
    let n = Number(arr[0]);

    let result  = '';
    for(let i = 1; i <= n; i++){
        if(isSum(i)){
            result += i + ' ';
        }
    }

    console.log(result);

    function isSum(number) {
        number = number.toString();
        let length = number.length;
        for(let i = 0; i < length / 2; i++){
            if(number[i] !== number[length - i - 1]){
                 return false;
            }
        }

        return true;
    }
}

