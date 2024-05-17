function solve (array, step) {
    let resultArray = [];

    for (let i = 0; i < array.length; i += step) {
        resultArray.push(array[i]);
    }

    return resultArray;
}

function quickSolve(array, step) {
    const resultArray = array.filter((element, index) => index % step === 0);
    return resultArray;
}

console.log(solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2
));

console.log(quickSolve(['5', 
'20', 
'31', 
'4', 
'20'], 
2
));