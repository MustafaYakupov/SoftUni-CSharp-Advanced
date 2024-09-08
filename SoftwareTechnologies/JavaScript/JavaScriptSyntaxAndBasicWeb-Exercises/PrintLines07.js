function solve(arr) {

    let index = 0;

    while(true){

        let line = arr[index++];

        if(line === 'Stop'){
            break;
        }else{
            console.log(line);
        }
    }
}