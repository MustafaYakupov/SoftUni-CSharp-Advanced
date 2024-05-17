let fullName = 'Stamat Petkov';
let fullName2 = 'Gosho Goshev';

let phoneBook = {
    'Ivan Ivanonv': '+35988123123',
    'Ginka Stamenova': '+3594546545',
    [fullName]: '+359651564654'
};

phoneBook['Pesho gerov'] = '+35912156485';
phoneBook[fullName2] = '+35912156426';

console.log(phoneBook);

// Use for in loop - the only way to iterate through objects
for (const key in phoneBook) {
    console.log(`${key} ->>> ${phoneBook[key]}`);   // Acces key and value
}

// Use for in for array - !!!Don't use for arrays
const names = ['Pesho', 'Gosho', 'Stamat'];
for (const name in names) {
    console.log(name);
}

// Check if person is in phoneBook by value in the phonebook
if (phoneBook['Ivaylo Papazov']) {
    console.log('found');
} else {
    console.log('not found');
}

// Check propertyName
if (phoneBook.hasOwnProperty('Ivaylo Papazov')) {
    console.log('Name found');
} else {
    console.log('Name not found');
}

console.log('Ivaylo Papazov' in phoneBook); // Returns bool

// Sort an object alphabetically ascending by key
let sortedArray = Object
    .entries(phoneBook) // turns it into array
    .sort((a, b) => a[0].localeCompare(b[0]))
    //.sort(([keyA], [keyB]) => keyA.localeCompare(keyB));

console.log(sortedArray);

// Reverse sorting
console.log(Object.fromEntries(sortedArray)); // turns it from array to object
