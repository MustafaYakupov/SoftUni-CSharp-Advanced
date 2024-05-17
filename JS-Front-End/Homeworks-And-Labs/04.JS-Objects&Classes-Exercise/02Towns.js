function solve(input) {
    const towns = [];

    for (const line of input) {
        let [city, latitude, longitude] = line.split(' | ');

        let town = {
            town: city,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2),
        }

        towns.push(town);
    }

    towns.forEach(town => console.log(town))
}

function fancySolve(input) {
    input
        .map(row => row.split(' | '))
        .map(([city, latitude, longitude]) => ({
            town: city,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2),
        }))
        .forEach(town => console.log(town));
}

solve(['Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625']
);

fancySolve(['Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625']
);