function solve(input) {
    const ridersCount = input.shift();

    let riders = [];
    let index = -1;

    // Save riders in array of objects
    for (let i = 0; i < ridersCount; i++) {
        const currentRider = input.shift().split('|');

        const name = currentRider[0];
        const fuelCapacity = Number(currentRider[1]);
        const position = currentRider[2];

        index++;

        const rider = {
            name,
            fuelCapacity,
            position,
            index,
        };

        riders.push(rider);
    }

    // Start race
    let commandLine = input.shift();

    while (commandLine !== 'Finish') {
        commandLine = commandLine.split(' - ');

        const command = commandLine[0];
        const riderName = commandLine[1];

        switch (command) {
            case 'StopForFuel':
                const minimumFuel = Number(commandLine[2]);
                const changedPosition = commandLine[3];

                const currentRider = riders.find(rider => rider.name === riderName);

                if (currentRider.fuelCapacity < minimumFuel) {
                    currentRider.position = changedPosition;
                    console.log(`${currentRider.name} stopped to refuel but lost his position, now he is ${changedPosition}.`);
                } else {
                    console.log(`${currentRider.name} does not need to stop for fuel!`);
                }
                break;
            case 'Overtaking':
                const riderOne = riders.find(rider => rider.name === riderName);
                const riderTwo = riders.find(rider => rider.name === commandLine[2]);

                if (riderOne.position < riderTwo.position) {
                    const temporaryPosition = riderTwo.position;
                    riderTwo.position = riderOne.position;
                    riderOne.position = temporaryPosition;

                    console.log(`${riderOne.name} overtook ${riderTwo.name}!`);
                }
                break;
            case 'EngineFail':
                const lapsLeft = commandLine[2];
                console.log(`${riderName} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);

                const riderToRemoveIndex = riders.find(rider => rider.name === riderName).index;
                riders.splice(riderToRemoveIndex, 1);
                break;
        }

        commandLine = input.shift();
    }

    for (const rider of riders) {
        console.log(rider.name);
        console.log(`  Final position: ${rider.position}`);
    }
}

solve((["3",
    "Valentino Rossi|100|1",
    "Marc Marquez|90|2",
    "Jorge Lorenzo|80|3",
    "StopForFuel - Valentino Rossi - 50 - 1",
    "Overtaking - Marc Marquez - Jorge Lorenzo",
    "EngineFail - Marc Marquez - 10",
    "Finish"])
);