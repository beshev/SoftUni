function main(array,n) {
    let result = [];
    for (let i = 0; i < array.length; i+= n) {
      result.push(array[i]);
    }

    return result;
}

console.log(main(['5', 
'20', 
'31', 
'4', 
'20'], 
2
));
console.log(main(['dsa',
'asd', 
'test', 
'tset'], 
2
));