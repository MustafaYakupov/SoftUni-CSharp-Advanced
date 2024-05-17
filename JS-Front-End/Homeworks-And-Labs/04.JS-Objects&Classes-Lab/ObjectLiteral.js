// Create an object
let person = { name: 'Pesho', age: 20 }; // object literal {}

// Create an object with non classic identifier
let person2 = { 'full-name': 'Ivan Ivanov' };

// Use dot syntax to get property value
console.log(person.name);

// Use bracket syntax to get property value
console.log(person['age']);
console.log(person2['full-name']);    // The only way to acces non classic identifier is with bracket syntax

// Create an empty object and dynamically add values
let animal = {};

// Add with dot syntax
animal.name = 'Navcho'; // adding property and value at once

// Add with breacket syntax
animal['min-weight'] = 2;

// Add dynamic name property
let propName = 'type';
animal[propName] = 'Cat'; // Allows using variables instead of name 

console.log(animal);

// Add dynamic name property in the literal
const dynamicPropName = 'fullName';
const person3 = {
    [dynamicPropName]: 'Ivan Ivanov'
};

console.log(person3);

// Multiline object literal (over 2 properties)
let firstName = 'Ivo';
let lastName = 'Papazov';
let age = 25;
let height = 182;

const personInfo = {
    firstName: firstName,
    lastName: lastName,
    age: age,
};

// Object literal with shorthand syntax
const shortPersonINfo = {   // When the variable name is matching the property name
    firstName,
    lastName,
    age,
    height,
}

// Get undefined property
console.log(animal.nonExistent); // returns undefined

// Delete entry
delete shortPersonINfo.firstName;
console.log(shortPersonINfo);

// Object destructuring assignment
let person4 = { name: 'Gosho', age: 21 };
const { age: personAge, name } = person4;

// Object destructuring assignment with rest
const { lastName: surName, ...restPersonalInfo } = shortPersonINfo;
console.log(surName);
console.log(restPersonalInfo);

