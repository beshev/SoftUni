function attachEventsListeners() {
    let daysButtonElement = document.getElementById('daysBtn');
    let hoursButtonElement = document.getElementById('hoursBtn');
    let minutesButtonElement = document.getElementById('minutesBtn');
    let secondsButtonElement = document.getElementById('secondsBtn');

    let daysElement = document.getElementById('days');
    let hoursElement = document.getElementById('hours');
    let minutesElement = document.getElementById('minutes');
    let secondsElement = document.getElementById('seconds');

    let days = 0;
    let hours = 0;
    let minutes = 0;
    let seconds = 0;

    daysButtonElement.addEventListener('click', (e) => {
         days = Number(daysElement.value);
         hours = days * 24;
         minutes = days * 24 * 60;
         seconds = days * 24 * 60 * 60;
         setTimeValues(days,hours,minutes,seconds);
    });

    hoursButtonElement.addEventListener('click', (e) => {
         hours = Number(hoursElement.value);
         days = hours / 24;
         minutes = days * 24 * 60;
         seconds = days * 24 * 60 * 60;

         setTimeValues(days,hours,minutes,seconds);
    });

    minutesButtonElement.addEventListener('click', (e) => {
        minutes = Number(minutesElement.value);
        hours = minutes / 60;
        days = hours / 24;
        seconds = days * 24 * 60 * 60;

        setTimeValues(days,hours,minutes,seconds);
    });

    secondsButtonElement.addEventListener('click', (e) => {
         seconds = Number(secondsElement.value);
         minutes = seconds / 60;
         hours = minutes / 60;
         days = hours / 24;

        setTimeValues(days,hours,minutes,seconds);
    });


    function setTimeValues(days,hours,minutes,seconds){
        daysElement.value = days;
        hoursElement.value = hours;
        minutesElement.value = minutes;
        secondsElement.value = seconds;
    }
}