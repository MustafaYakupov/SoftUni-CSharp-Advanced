function GladiatorArena(input) {
    let players = new Map();
    let playersWithSkills = new Map();
    let listOfGames = [];

    calcPlayers();
    startGame();
    printResults();

    function printResults() {
        let resultFromPlayers = Array.from(playersWithSkills).sort((a, b) => b[1] - a[1]).sort((a, b) => a[0] > b[1]);
        for (const entry of resultFromPlayers) {
            console.log(`${entry[0]}: ${entry[1]} skill`);
            let rsultFromPositions = Array.from(players.get(entry[0])).sort((a, b) => a[0].localeCompare(b[0])).sort((a, b) => b[1] - a[1]);
            for (const tech of rsultFromPositions) {
                console.log(`- ${tech[0]} <::> ${tech[1]}`);
            }
        }
    }

    function startGame() {
        for (const game of listOfGames) {
            let params = game.split(" vs ");
            if (playersWithSkills.has(params[0]) && playersWithSkills.has(params[1])) {
                let posf = Array.from(players.get(params[0])).map(x => x[0]);
                let poss = Array.from(players.get(params[1])).map(x => x[0]);
                let isBothCommon = false;
                for (const tech of posf) {
                    if (poss.some(a => tech === a)) {
                        isBothCommon = true;
                    };
                }

                if (isBothCommon) {
                    if (playersWithSkills.get(params[0]) > playersWithSkills.get(params[1])) {
                        playersWithSkills.delete(params[1]);
                    } else {
                        playersWithSkills.delete(params[0]);
                    }
                }
            }
        }
    }

    function calcPlayers() {
        for (let i = 0; i < input.length - 1; i++) {
            if (input[i].indexOf(" -> ") === -1) {
                listOfGames.push(input[i]);
                continue;
            }
            let args = input[i].split(" -> ");

            if (!players.has(args[0])) {
                players.set(args[0], new Map());
            }
            if (!players.get(args[0]).has(args[1])) {
                players.get(args[0]).set(args[1], 0);
            }

            if (!playersWithSkills.has(args[0])) {
                playersWithSkills.set(args[0], 0)
            }
            let skills = players.get(args[0]).get(args[1]);
            if (skills < Number(args[2])) {
                players.get(args[0]).set(args[1], Number(args[2]));
            }
        }
        for (const item of Array.from(playersWithSkills)) {
            let totalSkill = 0;
            for (const innerItem of Array.from(players.get(item[0]))) {
                totalSkill += innerItem[1];
            }
            playersWithSkills.set(item[0], totalSkill);
        }
    }
}