function attachEventsListeners() {
    let inputDistanceElement = document.querySelector('#inputDistance');
    let outputDistanceElement = document.querySelector('#outputDistance');
    let inputUnitElement = document.querySelector('#inputUnits');
    let outputUnitElement = document.querySelector('#outputUnits');
    let buttonElement = document.querySelector('#convert');
    
    
    buttonElement.addEventListener('click', (e) => {
        let metersTable = {
            km: 1000,
            m: 1,
            cm: 0.01,
            mm: 0.001,
            mi: 1609.34,
            yrd: 0.9144,
            ft: 0.3048,
            in: 0.0254,
        }

        let inputUnit = inputUnitElement.options[inputUnitElement.selectedIndex].value;
        let outputUnit = outputUnitElement.options[outputUnitElement.selectedIndex].value;
        let valueInMeters = Number(inputDistanceElement.value) * metersTable[inputUnit];
        let convertedValue = valueInMeters / metersTable[outputUnit];

        outputDistanceElement.value = convertedValue;
    });
}