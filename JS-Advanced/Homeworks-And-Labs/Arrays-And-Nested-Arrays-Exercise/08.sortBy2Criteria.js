function main(array) {
    array.sort(comparer);

    return array.join('\n');

    function comparer(a, b) {
        let comparer = a.length < b.length ? -1 : a.length > b.length ? 1 : 0;

        if (comparer == 0) {
            comparer = a.localeCompare(b);
        }

        return comparer;
    }
}

console.log(main(['alpha', 
'beta', 
'gamma']
));

main(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']
);

main(['test', 
'Deny', 
'omen', 
'Default']
);