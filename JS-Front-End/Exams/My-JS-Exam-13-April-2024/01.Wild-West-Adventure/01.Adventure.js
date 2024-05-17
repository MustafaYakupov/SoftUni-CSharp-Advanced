function solve(input) {
    const charactersCount = input.shift();

    let team = [];
    let index = -1;


    for (let i = 0; i < charactersCount; i++) {
        const hero = input.shift().split(' ');

        const name = hero[0];
        const hitPoints = Number(hero[1]);
        const bullets = Number(hero[2]);

        index++;

        const currentHero = {
            name,
            hitPoints,
            bullets,
            index,
        };

        team.push(currentHero);
    }

    let commandLine = input.shift();

    while (commandLine !== 'Ride Off Into Sunset') {
        const commands = commandLine.split(' - ');
        
        const action = commands[0];
        const name = commands[1];
        const hero = team.find(hero => hero.name === name);

        switch (action) {
            case 'FireShot':
                const target = commands[2];

                if (hero.bullets > 0) {
                    hero.bullets--;
                    console.log(`${name} has successfully hit ${target} and now has ${hero.bullets} bullets!`);
                } else {
                    console.log(`${name} doesn't have enough bullets to shoot at ${target}!`);
                }

                break;
            case 'TakeHit':
                const damage = Number(commands[2]);
                const attacker = commands[3];

                hero.hitPoints -= damage;

                if (hero.hitPoints > 0) {
                    console.log(`${name} took a hit for ${damage} HP from ${attacker} and now has ${hero.hitPoints} HP!`);
                } else {
                    team.splice(hero.index, 1);
                    console.log(`${name} was gunned down by ${attacker}!`);
                }

                break;
            case 'Reload':
                if (hero.bullets < 6) {
                    const reloadedBullets = 6 - hero.bullets;
                    hero.bullets = 6;

                    console.log(`${name} reloaded ${reloadedBullets} bullets!`);
                } else {
                    console.log(`${name}'s pistol is fully loaded!`);
                }

                break;
            case 'PatchUp':
                const amount = Number(commands[2]);
                if (hero.hitPoints === 100) {
                    console.log(`${name} is in full health!`);
                } else {
                    let recoveredHealthPoints;

                    if (hero.hitPoints + amount > 100) {
                        recoveredHealthPoints = 100 - hero.hitPoints;
                        hero.hitPoints = 100;
                    } else {
                        recoveredHealthPoints = amount;
                        hero.hitPoints += amount;
                    }

                    console.log(`${name} patched up and recovered ${recoveredHealthPoints} HP!`);
                }
                break;
        }

        commandLine = input.shift();
    }

    for (const hero of team) {
        console.log(hero.name);
        console.log(` HP: ${hero.hitPoints}`);
        console.log(` Bullets: ${hero.bullets}`);
    }
}

solve(["2",
"Jesse 100 4",
"Walt 100 5",
"FireShot - Jesse - Bandit",
 "TakeHit - Walt - 30 - Bandit",
 "PatchUp - Walt - 20" ,
 "Reload - Jesse",
 "Ride Off Into Sunset"])
