function solve(textInput) {
    let startIndex = -1;
    const words = [];

    for (let i = 0; i < textInput.length; i++) {
        if (textInput[i] === textInput[i].toUpperCase()) {
            if (startIndex < 0) {
                startIndex = i;
            } else {
                let word = textInput.substring(startIndex, i);
                words.push(word);
                startIndex = i
            }
        }
    }

    words.push(textInput.substring(startIndex));

    console.log(words.join(', '));
}

function fancySolve(textInput) {
    const matches = textInput.matchAll(/[A-Z][a-z]*/g);

    let result = Array.from(matches).join(', ');

    console.log(result);
}

function lookAhead(textInput) {
    console.log(textInput.split(/(?=[A-Z])/).join(', '));
}

lookAhead('SplitMeIfYouCanHaHaYouCantOrYouCan');