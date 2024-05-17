class Person {
    constructor(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    greet(to) {
        console.log(`${this.firstName} says hello to ${to.firstName}`);
    }
}

const firstPerson = new Person('Pesho', 'Ivanov');
const secondPerson = new Person('Gosho', 'Petkov');

console.log(firstPerson instanceof Person);

console.log(firstPerson);
console.log(secondPerson);

//firstPerson.greet('yosho');
firstPerson.greet(secondPerson);