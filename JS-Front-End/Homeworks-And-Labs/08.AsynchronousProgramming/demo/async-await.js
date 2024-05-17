const { log } = require("console");

// Normal function that returns promise
function calculateMeaningOfLife() {
    const result = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve(42);
        }, 5000);
    })

    return result;
}

async function getName() {
    return 'Pesho';
}

// Async function declaration
async function solve() {
    const meaningOfLife = await calculateMeaningOfLife();
    const name = getName();

    console.log(meaningOfLife);
    console.log(name);
}

solve();

// Async function expression
// const solve = async function() {

// }

// Sync arrow function
// const solve = async () => {

// }