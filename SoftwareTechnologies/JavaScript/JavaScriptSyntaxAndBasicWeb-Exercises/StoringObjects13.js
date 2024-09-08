function solve(input) {

    let students = [];
    for (let line of input){
        line = line.split(' -> ');
 let str = 
        let student = {
            name: line[0],
            age: Number(line[1]),
            grade: Number(line[2]).toFixed(2)
        };

        students.push(student);
    }

    for (let student of students) {
        console.log(`Name: ${student.name}`);
        console.log(`Age: ${student.age}`);
        console.log(`Grade: ${student.grade}`);
    }
}

solve([
    'Pesho -> 13 -> 6.00',
    'Ivan -> 12 -> 5.57',
    'Toni -> 13 -> 4.90']);

