function solve(number, op1, op2, op3, op4, op5) {
    let result = Number(number);
    let operations = op1[0] + op2[0] + op3[0] + op4[0] + op5[0];

    for (let i = 0; i < operations.length; i++) {
        switch (operations[i]) {
            case 'c':
                result /= 2;
                break;
            case 'd':
                result = Math.sqrt(result);
                break;
            case 's':
                result += 1;
                break;
            case 'b':
                result *= 3;
                break;
            case 'f':
                result -= result * 0.2;
                break;
        }

        console.log(result);
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');