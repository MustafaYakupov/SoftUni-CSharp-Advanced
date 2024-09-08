function solve(arr) {
    arr = arr.map(Number).sort((a, b) => b - a);

    let total = Math.min(arr.length, 3);

    for(let i = 0; i < total; i++){
    console.log(arr[i]);
    }

}

