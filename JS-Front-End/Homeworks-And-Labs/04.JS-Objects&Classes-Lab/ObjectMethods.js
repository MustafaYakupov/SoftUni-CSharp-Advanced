// Define method in object literal 
const cat = {
    name: 'Navcho',
    breed: 'Persian',
    age: 9,
    grades: [5, 6, 5, 6],
    owner: {
        name: 'Ivo',
        age: 24,
    },
    // Function expression value
    makeSound: function () {       // function as a value in object is called method
        console.log('Meow...');
    },
    // Arrow function
    sleep: () => console.log('zzZzzz'),
};

// Call method
let methodName = 'makeSound';
cat.makeSound(); // Most popular choice
cat['makeSound']();
cat[methodName]();

// Add method dynamically
cat.eat = function() {
    console.log('Omnononm');
}

cat.eat2 = () => console.log('Omnononm2');

cat.eat();
cat.sleep();

// Use method notation syntax
const dog = {
    name: 'Sharo',
    breed: 'Ulichna',
    makeSound() {
        console.log('Wof wof');
    },
    ownerName: 'Pesho',
}

// Get all property names of an object
const propertyNames = Object.keys(cat);
console.log(propertyNames);

// Get all property values of an object
const propertyValues = Object.values(cat);
console.log(propertyValues);

// Get object key value pairs
const simpleObject = {
    name: 'Pesho',
    age: 20,
};

const kvps = Object.entries(simpleObject);
console.log(kvps);

// Reverse entries
const originalSimpleObject = Object.fromEntries(kvps);
console.log(originalSimpleObject);

// Check for method and call 
cat.makeSound && cat.makeSound();  // If cat.makeSound si false it's going to brake. Only executes the calling if the first one is true

if (cat.makeSound) {  //  The bove is equivalent od this
    cat.makeSound();
}
