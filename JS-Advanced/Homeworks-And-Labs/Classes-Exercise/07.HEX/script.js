class Hex {
    constructor(number){
        this.number = number;
    }

    valueOf(){
        return this.number;
    }

    toString(){
        return `0x${this.number.toString(16).toUpperCase()}`;
    }

    plus(hexObj){
        return new Hex(hexObj.number + this.number);
    }

    minus(hexObj){
        return new Hex(this.number - hexObj.number);
    }

    static parse(string){
        return parseInt(string,16);
    }
}

let FF = new Hex(255);
console.log(FF instanceof Hex);
console.log(FF.valueOf() === 255);

let act = FF.toString();
let exp = "0xFF";
console.log(act === exp);

console.log(FF.valueOf() - 1  == 254);

let a = new Hex(10);
let b = new Hex(5);
let c = new Hex(155);
let act2 = a.plus(c).toString();
let exp2 = "0xA5";

console.log(act2 == exp2);

let act3 = a.minus(b).toString();
let exp3 = "0x5";

console.log(act3);
console.log(exp3);
console.log(act3 == exp3);

