// Functions in JS are values, not what it returns but just the function itself is value
// No need to use return, functions in JS return by default
// When declaring the function there are parameters (variables holding values), when we invoke the function with values they are called arguments
// Function declaration - Function Statement
function log() {
    console.log('Some text');
}

// Function expression   - Function Expression
// The variable holds the reference (address) of the function in the heap
const log2 = function() {
    console.log('Some text 2');
}

// Arrow function
const log3 = () => console.log('Some text 3');

// Function invokation 
log();
log2();
log3();

// Invoke function from another function - Like composition in C#
function masterlog(text) {
    console.log(`1 - ${text}`);
    console.log(`2 - ${text}`);
    console.log(`3 - ${text}`);
}

masterlog('PEsho');

// Recursion - The function invokes itself
function countDown(x) {
    console.log(x);
    if (x > 0) {
        countDown(x - 1);
    }
}

countDown(10);