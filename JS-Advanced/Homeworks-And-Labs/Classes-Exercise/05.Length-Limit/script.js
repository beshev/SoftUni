class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = Number(innerLength);
    }

    increase(value) {
        this.innerLength += Number(value);
    }

    decrease(value) {
        this.innerLength = this.innerLength - Number(value) < 0 ? 0 : this.innerLength - Number(value);
    }

    toString(){
        return this.innerString.length > this.innerLength ? this.innerString.substring(0,this.innerLength) + '...' : this.innerString;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
