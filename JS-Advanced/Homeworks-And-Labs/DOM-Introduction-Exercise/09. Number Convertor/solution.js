function solve() {
    //TODO...

    let selectElement = document.querySelector('#selectMenuTo');
    selectElement.selected = true;
    selectElement.innerHTML = null;

    let hexaElement = document.createElement('option');
    let binaryElement = document.createElement('option');
    
    hexaElement.value = 'hexadecimal';
    hexaElement.textContent = 'Hexadecimal';

    binaryElement.value = 'binary';
    binaryElement.textContent = 'Binary';

    selectElement.appendChild(hexaElement);
    selectElement.appendChild(binaryElement);

    document.querySelector('#container button').addEventListener('click',convert);

    function convert() {
        let number = Number(document.querySelector('#input').value);
        let converTo = {
            'hexadecimal': function (number) {
                return number.toString(16).toUpperCase();;
            },
            'binary': function (number) {
                return (number >>> 0).toString(2);
            }
        }

        document.querySelector('#result').value = converTo[selectElement.value](number);
    }
}