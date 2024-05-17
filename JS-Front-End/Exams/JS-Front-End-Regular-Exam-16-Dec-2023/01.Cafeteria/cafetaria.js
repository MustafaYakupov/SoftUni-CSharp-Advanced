function solve(input) {
    const baristaCount = input.shift();
    let team = {};

    for (let i = 0; i < baristaCount; i++) {
        const [name, shift, drinks] = input[i].split(' ');
        let drinksArr = drinks.split(',');

        team[name] = {
            shift,
            drinksSkillSet: drinksArr,
        }
    }

    let commandLine = input.shift();

    while (commandLine !== 'Closed') {
        const [command, name, argOne, argTwo] = commandLine.split(' / ');
        let shift;
        let coffeType;

        switch (command) {
            case 'Prepare':
                shift = argOne;
                coffeType = argTwo;

                if (team[name].shift === shift && team[name].drinksSkillSet.includes(coffeType)) {
                    console.log(`${name} has prepared a ${coffeType} for you!`);
                } else {
                    console.log(`${name} is not available to prepare a ${coffeType}.`);
                }

                break;
            case 'Change Shift':
                shift = argOne;

                 team[name].shift = shift;
                 
                 console.log(`${name} has updated his shift to: ${shift}`);

                break;
            case 'Learn':
                coffeType = argOne;

                if (team[name].drinksSkillSet.includes(coffeType)) {
                    console.log(`${name} knows how to make ${coffeType}.`);
                } else {
                    team[name].drinksSkillSet.push(coffeType);
                    console.log(`${name} has learned a new coffee type: ${coffeType}.`);
                }

                break;
        }

        commandLine = input.shift();
    }

    for (const baristaName in team) {
        console.log(`Barista: ${baristaName}, Shift: ${team[baristaName].shift}, Drinks: ${team[baristaName].drinksSkillSet.join(', ')}`);
    }
}

solve([
    '3',
      'Alice day Espresso,Cappuccino',
      'Bob night Latte,Mocha',
      'Carol day Americano,Mocha',
      'Prepare / Alice / day / Espresso',
      'Change Shift / Bob / night',
      'Learn / Carol / Latte',
      'Learn / Bob / Latte',
      'Prepare / Bob / night / Latte',
      'Closed'
    ]);
