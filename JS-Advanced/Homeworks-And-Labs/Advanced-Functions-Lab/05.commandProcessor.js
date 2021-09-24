function solution() {
    let result = '';

    return {
        append(value){
            result += value;
        },
        removeStart(n){
            result = result.substr(n);
        },
        removeEnd(n){
            result = result.substr(0,result.length - n);
        },
        print(){
            console.log(result);
        },
    }

}


let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
