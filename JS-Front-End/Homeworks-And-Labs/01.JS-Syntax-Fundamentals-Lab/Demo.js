// Declare variables

let a = 10;
let b = 20;
console.log(a + b);

var c = 30; // before ES2015 legacy, still  works - Not recommended to use

const pi = 3.14; 


//Conditional statements

if(a <= 10) {
    console.log('a is lower or equal to 10');
} else {
    console.log('a is larger than 10');
}

// Function declaration
function add(first, second) {
    console.log(first + second);
}

// Function invocation
add(3, pi);

// Console print with string concatenation
console.log('The number pi is: ' + pi + '!')

// String interpolation
console.log(`The number pi is: ${pi}!`)

// Fix the number output
let num = 5;
console.log(num.toFixed(2));

// Single vs double quotes for strings
console.log('Pesho');
console.log("Pesho");
// Use one or the other, don't mix

// Rounding vs toFixed
console.log(pi.toFixed(5));
console.log(Math.round(pi)); 

log 