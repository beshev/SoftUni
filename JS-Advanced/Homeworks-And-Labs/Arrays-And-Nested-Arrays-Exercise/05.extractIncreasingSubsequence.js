function main(array) {
    let result = [];
    array.reduce((acc,curr,index) => {
        if (acc <= curr) {
            result.push(acc);
            acc = curr;
        }
        
        if (index == array.length - 1) {
            result.push(acc);
        }
        return acc;
    })

    return result;
}

main([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    );

main([1, 
    2, 
    3,
    4]
    );
    
main([20, 
    3, 
    2, 
    15,
    6, 
    1]
    );