let cars = ['BMW', 'Audi', 'Mercedes', 'Toyota', 'Honda'];

console.log(cars);

// Mutating methods - they change the array
// Get and remove last item
let lastCar = cars.pop();
console.log(lastCar);
console.log(cars);

// Add last item
let newLength = cars.push('Peugeot', 'Opel', 'VW'); // returns the new arr count
console.log(newLength);
console.log(cars);

// Remove first element
let firstCar = cars.shift(); // Like dequeue, Removes the 1st element
console.log(firstCar);
console.log(cars);

// Add first element
cars.unshift("BMW"); // Adds element at the 1st position, unlike enqueue
console.log(cars);

// Remove item with splice
let deletedCars = cars.splice(2, 1); // At index 2 delete 1 elements count
console.log(deletedCars);
console.log(cars);

// Add item to array with splice
cars.splice(2, 0, 'Mercedes'); // At index 2, delete 0 elements, add 'Mercedes' at that index
console.log(cars);

// Add and remove items with splice
cars.splice(1, 3, 'VW', 'Audi');  // At index 1, delete 3 elements, add 'VW', 'Audi'
console.log(cars);

// Reverese array
cars.reverse();
console.log(cars);


// Non-mutation methods - they don't change the array
// Join array as string
let carsString = cars.join(', ');  // Converts an array to string and joins them with whatever we want - ', '
console.log(carsString);
console.log(cars);         // Does not change the original array

// Slice (not splice) 
let middleCars = cars.slice(1, 3); // start from index to index, inclusive the 1st index on the left, exclusive on the right
console.log(middleCars);
console.log(cars);

// Create shallow copy
let shallowCopy = cars.slice(); // Copy the array without changing it, separate arrray with a different reference in the heap
console.log(shallowCopy);

// Slice from middle to end
let endCars = cars.slice(1); // from start index to the end
console.log(endCars);

// Check if element exists in array
let isBMWIncluded = cars.includes('BMW');
console.log(isBMWIncluded);

// Find index of element 
let audiIndex = cars.indexOf('Audi');
console.log(cars);
console.log(audiIndex);

// If there is no such item in the array
let mercedesIndex = cars.indexOf('Mercedes'); // returns -1 because it does not exist
console.log(mercedesIndex);

// Find specific element
// audiElement = cars.find(function (car) {          // 2nd option, another syntax
//     return car === 'Audi';
// })
let audiElement = cars.find(car => car === 'Audi');
console.log(audiElement);

// Find all indexes of toyotas
let topCars = ['Toyota', 'BMW', 'Toyota', 'Audi'];

let tIndex = topCars.indexOf('Toyota');

while (tIndex >= 0) {
    console.log(tIndex);
    tIndex = topCars.indexOf('Toyota', tIndex + 1);
}

// ForEach
cars.forEach(car => console.log(car));  // JavaScript expression // sometimes statements are not allowed, only expressions

// for (const iterator of object) {  //  JavaScript statement

// }

// Map - Like Select in C#
let numbers = [1, 2, 3, 4, 5];
let doubleNumbers = numbers.map(number => number * 2);
console.log(numbers);
console.log(doubleNumbers);

// Filter - Similar to Where in C#
let oddNumbers = numbers.filter(number => number % 2 !== 0); // Takes all the elements that return true on the expression. Does not change the original array
console.log(numbers);
console.log(oddNumbers);

// Reduce - Iterates and "reduce" an array's values into one value
let numbersSum = numbers.reduce((sum, number) => {
    return sum += number;
})
console.log(numbersSum);

// Chaining
let doubleOddNumbers = numbers
    .filter(number => number % 2 !== 0)
    .map(number => number * 2);
    console.log(doubleOddNumbers);
