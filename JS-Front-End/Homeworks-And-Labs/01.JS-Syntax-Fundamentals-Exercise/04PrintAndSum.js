function solve(startNum, endNum) {
    let sum = 0;
    let result = '';

    for (let index = startNum; index <= endNum; index++) {
        result += index + ' ';
        sum += index;
    }

    console.log(`${result.trim()}`);
    console.log(`Sum: ${sum}`);
}

solve(5, 10);
solve(0, 26);