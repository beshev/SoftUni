function solve(input) {
    let [town, latitude, longitude] = input[0].split(/[ |]/).filter(x => x != '');
    let table = [];
   for (let i = 1; i < input.length; i++) {
       let [currentTown, currentLatitude, currentLongitude] = input[i].split(/[|]/).filter(x => x != '');

       table.push({
           [town]: currentTown.trim(),
           [latitude]: Number(Number(currentLatitude).toFixed(2)),
           [longitude]: Number(Number(currentLongitude).toFixed(2)),
       });
   }
   
   return JSON.stringify(table);
}


solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
);
solve(['| Town | Latitude | Longitude |',
'| Veliko Turnovo | 43.0757 | 25.6172 |',
'| Monatevideo | 34.50 | 56.11 |']
);