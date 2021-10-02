function solve() {
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }

        get area() {

        }

        changeUnits(newUnits) {
            if (newUnits === 'm' || newUnits === 'cm' || newUnits === 'mm') {
                this.units = newUnits;
            }
        }

        scaleParam(param) {
            switch (this.units) {
                case 'm':
                    param /= 10;
                    break;
                case 'cm':
                    break;
                case 'mm':
                    param *= 10;
                    break;
                default:
                    break;
            }
            return param;
        }

        toString() {
            return `Figures units: ${this.units}`;
        }
    }

    class Circle extends Figure {
        constructor(radius) {
            super();
            this._radius = Number(radius);
        }

        get radius(){
            return this.scaleParam(this._radius)
        }

        get area() {
            return Math.PI * (this.radius ** 2);
        }

        toString() {
            return super.toString() + ` Area: ${this.area} - radius: ${this.radius}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);
            this._widthInCM = Number(width);
            this._heightInCM = Number(height);
        }

        get width(){
            return this.scaleParam(this._widthInCM);
        }

        get height(){
            return this.scaleParam(this._heightInCM);
        }

        get area() {

            return this.width * this.height;
        }

        toString() {
            return super.toString() + ` Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    }
}


let Circle = new solve().Circle;
let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5


c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) 

console.log('-'.repeat(20));

let Rectangle = new solve().Rectangle;
let r = new Rectangle(3, 4, 'mm');

console.log(r.area); // 1200 
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString());



