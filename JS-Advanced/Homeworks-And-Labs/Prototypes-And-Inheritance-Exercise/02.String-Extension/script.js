(function solve(params) {
    String.prototype.ensureStart = function (str) {
        if (this.startsWith(str)) {
            return this.substr(0);
        }
        return str + this;
    }
    String.prototype.ensureEnd = function (str) {
        if (this.endsWith(str)) {
            return this.substr(0);
        }
        return this + str;
    }
    String.prototype.isEmpty = function () {
        return !this.length > 0;
    }
    String.prototype.truncate = function (n) {
        if (this.length <= n) {
            return this.toString();
        }
        if (n < 4) {
            return '.'.repeat(n);
        }

        if (!this.toString().includes(' ')) {
            return this.substr(0, n - 3) + '...';
        }

        let index = this.lastIndexOf(' ');
        let newStr = this.slice(0, index);
        while (newStr.length > n - 3) {
            index = newStr.lastIndexOf(' ');
            newStr = this.slice(0, index);
        }

        return newStr + '...';
    }
    String.format = function (string, ...params) {
        for (let i = 0; i < params.length; i++) {
            string =  string.replace(`{${i}}`,params[i]);
        }
        return string;
    }
})()

let str = '123456 7';

str = str.truncate(7);
console.log(str);
