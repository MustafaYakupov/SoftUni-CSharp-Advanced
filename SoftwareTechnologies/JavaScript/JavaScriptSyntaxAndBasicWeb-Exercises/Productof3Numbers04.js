function solve(arr) {

    let num1 = Number(arr[0]);
    let num2 = Number(arr[1]);
    let num3 = Number(arr[2]);

    let negative = 0;

    for(num of arr){
        if(num < 0){
            negative++;
        }
    }

    if(negative % 2 !== 0){
        console.log('Negative');
    }else{
        console.log('Positive');
    }
}


