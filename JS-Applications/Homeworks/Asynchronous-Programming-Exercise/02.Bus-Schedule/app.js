function solve() {
    let departButton = document.getElementById('depart');
    let arriveButton = document.getElementById('arrive');
    let infoBox = document.querySelector('#info span');
    let stop = {
        name: '',
        next: 'depot',
    }

    async function depart() {
        try {
            let url = `http://localhost:3030/jsonstore/bus/schedule/${stop.next}`;
            let response = await fetch(url);
            stop = await response.json();
            infoBox.textContent = `Next stop ${stop.name}`;

            changeButtons();
        } catch (error) {
            infoBox.textContent = 'Error';
            departButton.disabled = true;
            arriveButton.disabled = true;
        }
    }

    function arrive() {
        infoBox.textContent = `Arriving at ${stop.name}`;
        changeButtons();
    }

    function changeButtons() {
        departButton.disabled = !departButton.disabled;
        arriveButton.disabled = !arriveButton.disabled;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();