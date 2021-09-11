function main(one, two, operation){
    
    let result = undefined;

    switch (operation) {
        case '+':
            result = one + two
            break;
        case '-':
            result = one - two
            break;
        case '*':
            result = one * two
            break;
        case '/':
            result = one / two
            break;
        case '%':
            result = one % two
            break;
        case '**':
            result = one ** two
            break;
        }

        console.log(result);
}

main(1,2,'+');
main(1,2,'-');
main(1,2,'*');
main(1,2,'/');
main(1,2,'%');
main(1,2,'**');
