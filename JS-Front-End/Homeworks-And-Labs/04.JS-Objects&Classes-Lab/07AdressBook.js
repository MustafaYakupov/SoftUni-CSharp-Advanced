function solve(input) {
    const adressBook = {};

    for (const line of input) {
        const [name, address] = line.split(':');

        adressBook[name] = address;
    }

    Object
        .entries(adressBook)
        .sort((a, b) => a[0].localeCompare(b[0]))
        .forEach(([name, address]) => console.log(`${name} -> ${address}`));
}

solve(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
);