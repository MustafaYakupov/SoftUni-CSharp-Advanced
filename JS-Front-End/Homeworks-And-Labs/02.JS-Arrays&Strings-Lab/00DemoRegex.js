let text = 'I am JavaScript developer, JavaScript is awesome!';

// RegExp literal     // Use the literal always unless it doesn't work, then use the function constructor
let pattern = /JavaScript/ig;  // i flag means insensitive - catches both small and capital letters
                                // g flag means global - doesn't stop searching after the first match and finds all matches

// Reg Exp function constructor
let pattern2 = new RegExp('JavaScript', 'ig');

// test pattern
console.log(pattern.test(text));

// match by pattern
console.log(pattern2.exec(text));
console.log(pattern2.exec(text));
console.log(pattern2.exec(text));

// String regex methods - most used
console.log(text.match(pattern));
console.log('------------------------');
const matches = text.matchAll(pattern);

for (const match of matches) {
    console.log(match);
}

// How to count matches
console.log((Array.from(matches)).length);

// Replace
console.log(text.replace(/JavaScript/g, 'C#'));   // Works in Judge

// Split input with regex
let input = '1     2 3      4';
let regex = /\s+/g;
console.log(input.split(regex));