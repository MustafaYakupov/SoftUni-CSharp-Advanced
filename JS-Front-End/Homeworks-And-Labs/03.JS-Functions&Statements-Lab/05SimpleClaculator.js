function solve(a, b, operator) {
    const operation = getOperation(operator);

    const result = operation(a, b);

    console.log(result);

    function getOperation(operator) {
        switch (operator) {
            case 'multiply':
                return (a, b) => a * b;
                break;
            case 'divide':
                return (a, b) => a / b;
                break;
            case 'add':
                return (a, b) => a + b;
                break;
            case 'subtract':
                return (a, b) => a - b;
                break;
        }
    }
}

function fancySolve(a, b, operator) {
    const operations = {
        multiply: (a, b) => a * b,
        divide: (a, b) => a / b,
        add: (a, b) => a + b,
        subtract: (a, b) => a - b,
    }

    console.log(operations[operator](a, b));
}

solve(5,
    5,
    'multiply'
);

fancySolve(5,
    5,
    'multiply'
);