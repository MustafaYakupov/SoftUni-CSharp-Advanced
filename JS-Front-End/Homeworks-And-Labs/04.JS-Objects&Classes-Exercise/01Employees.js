function solve(input) {
    for (const line of input) {
        const employee = {
            name: line,
            personalNumber: line.length,
        }

        console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`);
    }
}

function fancySolve(input) {
    input
    .map((name) => ({
        name,
        personalNumber: name.length,
    }))
    .forEach(employee => console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`));
}

solve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
]
);

fancySolve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
]
);