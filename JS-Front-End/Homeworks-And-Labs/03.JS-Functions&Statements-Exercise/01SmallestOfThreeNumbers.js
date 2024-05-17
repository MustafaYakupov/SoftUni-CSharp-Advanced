function solve(...numbers) {
    function smallestNumber(numbers) {
        let smallestNumberResult = Number.MAX_SAFE_INTEGER;
        
        for (const number of numbers) {
            if (number < smallestNumberResult) {
                smallestNumberResult = number;
            }
        }

        return smallestNumberResult;
    }

    const result = smallestNumber(numbers);
    console.log(result);
}

solve(2, 3, 4);