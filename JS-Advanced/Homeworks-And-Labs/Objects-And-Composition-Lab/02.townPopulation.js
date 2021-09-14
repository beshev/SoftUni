function main(input) {
    let cities = {};
    for (const inputInfo of input) {
        const tokens = inputInfo.split(' <-> ');
        const name = tokens[0];
        const population = tokens[1];

        if (!cities[name]) {
            cities[name] = 0;
        }
        
        cities[name] += Number(population);
    }
       
    for (const key in cities) {
      console.log( key + ' : ' + cities[key]);
        
    }
    
}

main(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']);

// console.log(main(['Sofia <-> 1200000',
// 'Montana <-> 20000',
// 'New York <-> 10000000',
// 'Washington <-> 2345000',
// 'Las Vegas <-> 1000000']
// ));

// console.log(main(['Istanbul <-> 100000',
// 'Honk Kong <-> 2100004',
// 'Jerusalem <-> 2352344',
// 'Mexico City <-> 23401925',
// 'Istanbul <-> 1000']
// ));