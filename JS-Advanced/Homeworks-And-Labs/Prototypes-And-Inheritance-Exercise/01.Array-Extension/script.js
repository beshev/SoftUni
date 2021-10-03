(function solve() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    }
    Array.prototype.skip = function (n) {
        return this.slice(n);
    }
    Array.prototype.take = function (n) {
        return this.slice(0,n);
    }
    Array.prototype.sum = function () {
        return this.reduce((acc, x) => acc + x, 0);
    }
    Array.prototype.average = function () {
        return this.reduce((acc, x) => acc + x, 0) / this.length;
    }
})();


let arr = [1,2,5,7,10,3];
let newArr = arr.skip(3);
let firstN = arr.take(3);
console.log(arr);
console.log(newArr);
console.log(firstN);
console.log(firstN.sum());
console.log(firstN.average());