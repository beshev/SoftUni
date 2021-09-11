function main(number = 5){
    let star = '*';

    for(let j = 0; j < number; j++){
        console.log(`${star} `.repeat(number));
    }
}

main(5);