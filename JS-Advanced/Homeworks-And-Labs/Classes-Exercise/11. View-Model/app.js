class Textbox {
    _invalidSymbols;
    _elements = [];
    _currentValue;

    constructor(selector, regex) {
        this._elements = document.querySelectorAll(selector);

        for (const el of this._elements) {
            el.addEventListener('input', (e) => {
                this.value = e.target.value;
            })
        }

        this._invalidSymbols = regex;
    }

    get value(){
        return this._currentValue;
    }

    set value(value){
        this._currentValue = value

        for (const el of this._elements) {
            el.value = this._currentValue;
        }
    }

    get elements(){
        return this._elements
    }

    isValid = function () {
        for (const input of this._elements) {
            if (this._invalidSymbols.test(input.value)) {
                return false;
            }
        }

        return true;
    }
}

let textbox = new Textbox(".textbox", /[^a-zA-Z0-9]/);


console.log($(this.selector).val(value));
