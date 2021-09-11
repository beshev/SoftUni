function main(input) {
    let numberAsSrting = input.toString();
    let areSame = true;
    let totalSum = 0;
    for (let i = 0; i < numberAsSrting.length - 1; i++) {
        if (numberAsSrting[i] != numberAsSrting[i + 1]) {
            areSame = false;
        }

        totalSum += Number(numberAsSrting[i]);
    }
    totalSum += Number(numberAsSrting[numberAsSrting.length - 1]);

    console.log(areSame);
    console.log(totalSum);
}

main(1234);