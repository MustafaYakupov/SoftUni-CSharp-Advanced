function solve(wordToFind, text) {
    text = text.split(' ');

    for (const word of text) {
        if (word.toUpperCase() === wordToFind.toUpperCase()) {
            console.log(wordToFind);
            return;
        }
    }

    console.log(`${wordToFind} not found!`);
}

solve('javascript',
'JavaScript is the best programming language'
);

solve('python',
'JavaScript is the best programming language'
);