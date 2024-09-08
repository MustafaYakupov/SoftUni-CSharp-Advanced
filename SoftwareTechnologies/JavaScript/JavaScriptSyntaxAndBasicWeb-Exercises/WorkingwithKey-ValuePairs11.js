function solve(input) {

    let obj ={};

    for (let i = 0; i < input.length - 1; i++){
        let tokens = input[i].split(' ');

        let key = tokens[0];
        let value = tokens[1];

        obj[key] = value;
    }
    let queryKey = input[input.length - 1];

    if(queryKey in obj){
        console.log(obj[queryKey]);
    }else{
        console.log('None');
    }

}

