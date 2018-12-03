function solve(lostFight,helmetCost,swordCost,shieldCost,armorCost) {
    let helmetBroke = Math.floor(lostFight / 2);
    let swordBroke = Math.floor(lostFight / 3);
    let shieldBroke = 0;
    for (let i = 1; i <= lostFight; i++) {
        if(i % 2 === 0 && i % 3 === 0) {
            shieldBroke += 1;
        }
    }
    let armorBroke = Math.floor(shieldBroke / 2 );
    let moneyForHelmet = helmetBroke*helmetCost;
    let moneyForSword = swordBroke*swordCost;
    let moneyForShield = shieldBroke*shieldCost;
    let moneyForArmor = armorBroke*armorCost;

    let total = moneyForHelmet+moneyForSword+moneyForShield+moneyForArmor;
    console.log(`Gladiator expenses: ${total.toFixed(2)} aureus`);
}