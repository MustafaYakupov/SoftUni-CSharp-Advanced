function solve(firstName, lastName, hairColor) {
    const object = {
        name: firstName,
        lastName,
        hairColor,
    };

    const objectToJSON = JSON.stringify(object);

    console.log(objectToJSON);
}

solve('George', 'Jones', 'Brown'); 