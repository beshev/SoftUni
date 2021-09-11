function main(one, two){
    let numberOne = Number(one);
    let secondNumber = Number(two);

    if (numberOne == secondNumber) {
      return secondNumber;  
    }

    let sum = numberOne;
    sum += main(numberOne + 1, secondNumber)

    return sum;
}


console.log(main('1', '5'));