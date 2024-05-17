function classicSolve(grade) {
    const result = formatGrade(grade);

    console.log(result);

    function formatGrade(grade) {

        let formattedGrade = '';

        if (grade < 3.00) {
            formattedGrade = `Fail (2)`;
        } else if (grade < 3.50) {
            formattedGrade = `Poor (${grade.toFixed(2)})`;
        } else if (grade < 4.50) {
            formattedGrade = `Good (${grade.toFixed(2)})`;
        } else if (grade < 5.50) {
            formattedGrade = `Very good (${grade.toFixed(2)})`;
        } else {
            formattedGrade = `Excellent (${grade.toFixed(2)})`;
        }

        return formattedGrade;
    }
}

function solve(grade) {
    const result = formatGrade(grade); // Function hoisting - In JS we can invoke a function before its declaration if it is in the same scope. It doesn't work with func expression and arrow functions only with function statements

    console.log(result);

    function formatGrade(grade) {

        let formattedGrade = '';

        if (grade < 3.00) {
            return `Fail (2)`;
        }

        if (grade < 3.50) {
            return `Poor (${grade.toFixed(2)})`;
        }

        if (grade < 4.50) {
            return `Good (${grade.toFixed(2)})`;
        }

        if (grade < 5.50) {
            return `Very good (${grade.toFixed(2)})`;
        }

        if (grade >= 5.50 ) {
            return `Excellent (${grade.toFixed(2)})`;
        }
    }
}

solve(2.99);
classicSolve(2.99);