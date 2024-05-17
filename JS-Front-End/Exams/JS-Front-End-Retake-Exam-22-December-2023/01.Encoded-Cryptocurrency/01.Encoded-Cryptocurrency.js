function solve(input) {
    let encodedMessage = input.shift();
    
    let command = input.shift();

    while (command !== 'Buy') {
        if (command === 'TakeEven') {
            let evenIndicesMessage = '';
            for (let i = 0; i < encodedMessage.length; i+= 2) {
                evenIndicesMessage += encodedMessage[i];
            }

            encodedMessage = evenIndicesMessage;

            console.log(encodedMessage);
        } else if (command.split('?').shift() === 'ChangeAll') {
            const [action, substring, replacement] = command.split('?');
            
            while (encodedMessage.includes(substring)) {
                encodedMessage = encodedMessage.replace(substring, replacement);
            }

            console.log(encodedMessage);
        } else if (command.split('?').shift() === 'Reverse') {
            const substring = command.split('?')[1];
            
            if (encodedMessage.includes(substring)) {

                let result = encodedMessage.replace(substring, '');

                result += Array.from(substring).reverse().join('');
                encodedMessage = result;

                console.log(encodedMessage);
            } else {
                console.log('error');
            }
        }

        command = input.shift();
    }

    console.log(`The cryptocurrency is: ${encodedMessage}`);
}

solve((["PZDfA2PkAsakhnefZ7aZ", 
"TakeEven",
"TakeEven",
"TakeEven",
"ChangeAll?Z?X",
"ChangeAll?A?R",
"Reverse?PRX",
"Buy"])
);