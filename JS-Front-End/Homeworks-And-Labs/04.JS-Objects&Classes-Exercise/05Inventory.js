function solve(input) {

    let heroArray = [];

    for (const line of input) {
        let [name, level, items] = line.split(' / ');

        let hero = {
            name,
            level,
            items,
        };

        heroArray.push(hero);
    }

    heroArray.sort((a, b) => {
        return a.level - b.level;
    });

    for (const hero of heroArray) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    }
}

function fancySolve(input) {
    input.map(row => {
        let [name, level, items] = row.split(' / ');

        return {
            name,
            level,
            items,
        }
    })
    .sort((a, b) => a.level - b.level)
    .forEach(hero => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    });
}

solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]
);

fancySolve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]
);