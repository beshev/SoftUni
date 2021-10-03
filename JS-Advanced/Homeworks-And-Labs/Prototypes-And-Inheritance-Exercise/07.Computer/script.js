function createComputerHierarchy() {
    class Product{
        constructor(manufacturer){
            if (new.target === Product) {
                throw new Error();
            }
            this.manufacturer = manufacturer;
        }
    }

    class Keyboard extends Product{
        constructor(manufacturer, responseTime) {
            super(manufacturer);
            this.responseTime = Number(responseTime);
        }
    }

    class Monitor extends Product {
        constructor(manufacturer, width, height) {
            super(manufacturer);
            this.width = Number(width);
            this.height = Number(height);
        }
    }

    class Battery extends Product {
        constructor(manufacturer, expectedLife) {
            super(manufacturer);
            this.expectedLife = Number(expectedLife);
        }
    }

    class Computer extends Product {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
            if (new.target === Computer) {
                throw new Error();
            }
            super(manufacturer);
            this.processorSpeed = Number(processorSpeed);
            this.ram = Number(ram);
            this.hardDiskSpace = Number(hardDiskSpace);
        }
    }

    class Laptop extends Computer {
        _battery;
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.weight = Number(weight);
            this.color = color;
            this.battery = battery;
        }

        get battery(){
            return this._battery;
        }

        set battery(battery) {
            if (!(battery instanceof Battery)) {
                throw new TypeError();
            }
            this._battery = battery;
        }
    }

    class Desktop extends Computer {
        _keyboard;
        _monitor;
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.keyboard = keyboard;
            this.monitor = monitor;
        }

        get keyboard(){
            return this._keyboard;
        }

        set keyboard(keyboard) {
            if (!(keyboard instanceof Keyboard)) {
                throw new TypeError();
            }
            this._keyboard = keyboard;
        }

        get monitor(){
            return this._monitor;
        }

        set monitor(monitor) {
            if (!(monitor instanceof Monitor)) {
                throw new TypeError();
            }
            this._monitor = monitor;
        }
    }

    return {
        Battery,
        Keyboard,
        Monitor,
        Computer,
        Laptop,
        Desktop,
        Product,
    }
}

let classes = createComputerHierarchy();
let Computer = classes.Computer;
let Laptop = classes.Laptop;
let Desktop = classes.Desktop;
let Monitor = classes.Monitor;
let Battery = classes.Battery;
let Keyboard = classes.Keyboard;

let battery = new Battery('Energy', 3);
console.log(battery);
let laptop = new Laptop("Hewlett Packard", 2.4, 4, 0.5, 3.12, "Silver", battery);
console.log(laptop);

let laptopPrototype =  Object.getPrototypeOf(laptop);
console.log(laptopPrototype);

