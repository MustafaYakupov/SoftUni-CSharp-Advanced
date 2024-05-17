// indexOf
let text = 'I am JavaScript developer';
let indexOfJava = text.indexOf('Java');
console.log(indexOfJava);

// Substring
let theBestLanguage = text.substring(5, 15); // Start index and end index
console.log(theBestLanguage);

// Replace
let cSharpDevText = text.replace('JavaScript', 'C#'); // Replaces the first found match. There is replaceAll to replace all matches
console.log(cSharpDevText);

// Split
let words = text.split(' '); // Splits by single spaces, if there are more spaces empty string are given
console.log(words);

// Includes
console.log(text.includes('JavaScript')); // Returns true

// Repeat
console.log('Tro ' + 'lo '.repeat(10));
console.log('Tro ' + '*'.repeat(10));

// Check string start and end
console.log(text.startsWith('I am'));
console.log(text.endsWith('developer'));

// Pad string
console.log('10'.padStart(10, '0'));
console.log('10101'.padStart(10, '0'));
console.log('10111010'.padStart(10, '0'));

// Reverse string
let reversedString = text.split('')
.reverse()
.join('');

console.log(reversedString);

