function solve(input) {

    let student = {};
    for (let line of input) {
        let tokens = line.split(' -> ');
        let name = tokens[0];
        let value = isNaN(tokens[1]) ? tokens[1] : Number(tokens[1]);

         student[name] = value;

    }
    let output = JSON.stringify(student);
    console.log(output);
}

solve([
    'name -> Angel',
    'surname -> Georgiev',
    'age -> 20',
    'grade -> 6.00'
]);