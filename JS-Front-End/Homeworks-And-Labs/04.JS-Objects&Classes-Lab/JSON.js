let person = {
    name: 'Pesho',
    age: 20,
}

// Convert JS object to JSON
const data = JSON.stringify(person, null, 2);
console.log(data);

// Convert from JSON to JS object
const originalObject = JSON.parse(data);
console.log(originalObject); 