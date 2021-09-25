function solution() {
    let macros = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    }

    let productsTable = { 
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    }

     return function(command) {
         let [commnadType, value, quantity] = command.split(' ').filter(x => x != '');
        ;
         if (commnadType == 'restock') {
           return restock(value,quantity);
        } else if (commnadType == 'prepare') {
            return preparing(value,Number(quantity));
        } else if (commnadType == 'report') {
           return report();
        }
     }  
    
     function preparing(product, quantity) {
         for (const key in productsTable[product]) {
             if (productsTable[product][key] * quantity > macros[key]) {
                return `Error: not enough ${key} in stock`;
             }
         }

         for (const key in productsTable[product]) {
            macros[key] -= productsTable[product][key] * quantity;
         }

         return 'Success';
     }

    function restock(macroName, quantity) {
        macros[macroName] += Number(quantity);
        return 'Success';
    }

    function report () {
        return `protein=${macros.protein} carbohydrate=${macros.carbohydrate} fat=${macros.fat} flavour=${macros.flavour}`;
    }
}


let manager = solution ();

    // console.log(manager('restock flavour 50'));
    // console.log(manager('prepare lemonade 4 '));
    // console.log(manager('restock carbohydrate 10'));
    // console.log(manager('prepare apple 1'));
    // console.log(manager('restock fat 10'));
    // console.log(manager('prepare burger 1'));
    // console.log(manager('report'));

    console.log(manager('restock carbohydrate 10'));
    console.log(manager('restock flavour 10'));
    console.log(manager('prepare apple 1'));
    console.log(manager('restock fat 10'));
    console.log(manager('prepare burger 1'));
    console.log(manager('report'));

    // console.log(manager('prepare turkey 1'));
    // console.log(manager('restock protein 10'));
    // console.log(manager('prepare turkey 1'));
    // console.log(manager('restock carbohydrate 10'));
    // console.log(manager('prepare turkey 1'));
    // console.log(manager('restock fat 10'));
    // console.log(manager('prepare turkey 1'));
    // console.log(manager('restock flavour 10'));
    // console.log(manager('prepare turkey 1'));
    // console.log(manager('report'));

