function solve(text, word) {
    let result = text.replaceAll(word, '*'.repeat(word.length));
    console.log(result);
}

function solve2(text, word) {
    let index = text.indexOf(word);

    while (index >= 0) {
        text = text.replace(word, '*'.repeat(word.length));

        index = text.indexOf(word);
    }

    console.log(text);
}

solve2('A small sentence with some words', 'small');