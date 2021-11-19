function attachEvents() {
    let submitButton = document.getElementById('submit');
    submitButton.addEventListener('click', getForecaster);

    let currentDivElement = document.getElementById('current');
    let upcomingDivElement = document.getElementById('upcoming');

    let errorElement = e('h1', {}, 'Error');

    async function getForecaster() {
        if (currentDivElement.children.length > 1) {
            currentDivElement.children[1].remove();
        }

        if (upcomingDivElement.children.length > 1) {
            upcomingDivElement.children[1].remove();
        }

        let locationElement = document.getElementById('location');
        document.getElementById('forecast').style.display = 'block';

        try {
            let cities = await getCities();
            let city = cities.find(x => x.name == locationElement.value);
            if (!city) {
                throw Error();
            }
            await loadLocation(city.code);
            await loadUpcoming(city.code);
        } catch (error) {
            currentDivElement.appendChild(errorElement);
        }
    }

    async function loadUpcoming(code) {
        let upcoming = await getUpcoming(code);
        let symbols = getSymbolsCodes();

        let div = e('div', 'forecast-info');

        upcoming.forecast.forEach(forecast => {
            let spanCondition = e('span', 'forecast-data', forecast.condition);
            let spanDegrees =
                e('span', 'forecast-data', `${forecast.low}${symbols.Degrees}/${forecast.high}${symbols.Degrees}`);
            let spanSymbol = e('span', 'symbol', symbols[forecast.condition]);
            let span = e('span', 'upcoming');
            
            span.appendChild(spanSymbol);
            span.appendChild(spanDegrees);
            span.appendChild(spanCondition);

            div.appendChild(span);
        });

        upcomingDivElement.appendChild(div);
    }

    async function loadLocation(code) {
        let location = await getLocation(code);
        let symbols = getSymbolsCodes();

        let spanCondition = e('span', 'forecast-data', location.forecast.condition);

        let spanDegrees =
            e('span', 'forecast-data', `${location.forecast.low}${symbols.Degrees}/${location.forecast.high}${symbols.Degrees}`);
        let spanLocaionName = e('span', 'forecast-data', location.name);

        let spanInfo = e('span', 'condition');

        let spanSymbol = e('span', 'condition symbol', symbols[location.forecast.condition]);

        spanInfo.appendChild(spanLocaionName);
        spanInfo.appendChild(spanDegrees);
        spanInfo.appendChild(spanCondition);

        let div = e('div', 'forecast');
        div.appendChild(spanSymbol);
        div.appendChild(spanInfo);
        currentDivElement.appendChild(div);
    }

    function getSymbolsCodes() {
        return {
            Sunny: '&#x2600;', // ☀
            ['Partly sunny']: '&#x26C5;', // ⛅
            Overcast: '&#x2601;',  // ☁
            Rain: '&#x2614;',  // ☂
            Degrees: '&#176;'    // °
        }
    }

    async function getUpcoming(code) {
        let url = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;
        let res = await fetch(url);
        let data = await res.json();


        return data;
    }

    async function getLocation(code) {
        let url = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
        let res = await fetch(url);
        let data = await res.json();

        return data;
    }

    async function getCities() {
        let url = `http://localhost:3030/jsonstore/forecaster/locations`;
        let response = await fetch(url);
        let cities = await response.json();

        return cities;
    }

    function e(type, className, text) {
        const el = document.createElement(type);
        if (className) {
            el.className = className;
        }
        if (text) {
            el.innerHTML = text;
        }
        return el;
    }
}

attachEvents();