function solve(input) {

    let students = input.map(JSON.parse);

    for (let student of students){
        console.log(`Name: ${student.name}`);
        console.log(`Age: ${student.age}`);
        console.log(`Date: ${student.date}`);
    }
}

solve(
    '{"name":"Gosho","age":10,"date":"19/06/2005"}',
    '{"name":"Tosho","age":11,"date":"04/04/2005"}'
    );