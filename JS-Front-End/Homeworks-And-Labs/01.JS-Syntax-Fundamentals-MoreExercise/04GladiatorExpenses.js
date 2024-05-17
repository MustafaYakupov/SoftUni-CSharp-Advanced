function solve(lostFightsCount, helmetPirce, swordPrice, shieldPrice, armorPrice) {
    let brokenHelmetCount = 0;
    let brokenSwordCount = 0;
    let brokenShieldCount = 0;
    let brokenArmourCount = 0;

    let totalExpense = 0;

    for (let i = 0; i < lostFightsCount; i++) {
        if (i > 0 && i % 2 === 0) {
            brokenHelmetCount++;
        }

        if (i > 0 && i % 3 === 0) {
            brokenSwordCount++;
        }

        if (i > 0 && i % 2 === 0 && i % 3 === 0) {
            brokenShieldCount++;

            if (brokenShieldCount % 2 === 0) {
                brokenArmourCount++;
            }
        }
    }

    totalExpense = helmetPirce * brokenHelmetCount
        + swordPrice * brokenSwordCount
        + shieldPrice * brokenShieldCount
        + armorPrice * brokenArmourCount;

    console.log(`Gladiator expenses: ${totalExpense.toFixed(2)} aureus`);    
}

solve(7,
    2,
    3,
    4,
    5
    );