function solve(input) {

    let arr = [];

    for(let line of input){
        let tokens = line.split(' ');

        let command = tokens[0];

        if(command === 'add'){
            let number = Number(tokens[1]);
            arr.push(number);
        }else{
            let index = Number(tokens[1]);
            arr.splice(index, 1);
        }
    }
    console.log(arr.join('\n'));
}

