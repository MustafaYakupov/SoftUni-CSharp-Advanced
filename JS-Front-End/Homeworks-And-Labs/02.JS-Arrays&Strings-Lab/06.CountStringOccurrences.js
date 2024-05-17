function solve(text, word) {
    let words = text.split(' ');
    let result = 0;
    
    for (const currentWord of words) {
        if (currentWord === word) {
            result++;
        }
    }

    console.log(result);
}

function solve2(text, word) {
    let result = text
    .split(' ')
    .filter(element => element === word)
    .length;

    console.log(result);
}

solve('This is a word and it also is a sentence','is');
solve2('This is a word and it also is a sentence','is');