'use strict'
function solve(heroes) {
    let result = [];

    for (const heroInfo of heroes) {
        let [name, level, items] = heroInfo.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];
        result.push({name,level,items});
    }

    return JSON.stringify(result);
}


console.log(solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
));

console.log(solve(['Jake / 1000 / Gauss, HolidayGrenade']));