function calculator() {
    let num1Element;
    let num2Element;
    let resultElement;
    
    return {
        init: function(num1Id, num2Id, resultId) {
            num1Element = document.querySelector(num1Id);
            num2Element = document.querySelector(num2Id);
            resultElement = document.querySelector(resultId);
        },
        add: function () {
            let result = Number(num1Element.value) + Number(num2Element.value);
            resultElement.value = result;
        },
        subtract: function () {
            let result = Number(num1Element.value) - Number(num2Element.value);
            resultElement.value = result;
        }
    }
}

const calculate = calculator(); 
calculate.init ('#num1', '#num2', '#result');







