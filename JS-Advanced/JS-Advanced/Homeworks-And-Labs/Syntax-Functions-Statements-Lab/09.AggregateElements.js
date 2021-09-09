function main(array){
    let sum =  0;
    let inverseSum = 0;
    let arrayAsSrting = '';

    for (let i = 0; i < array.length; i++) {
        sum += array[i];
        inverseSum += 1 / array[i];
        arrayAsSrting = arrayAsSrting.concat(array[i]);
    }

    console.log(sum);
    console.log(inverseSum);
    console.log(arrayAsSrting);
}

main([2, 4, 8, 16]);