function main(speed,area) {
    let dic = {
        "motorway": 130,
        "interstate": 90,
        "city": 50,
        "residential": 20,
    }

    let speedLimit = dic[area];

    if (speed <= speedLimit) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    } else {
        let difference = speed - speedLimit;
        let status = '';

        if (difference <= 20) {
            status = 'speeding';
        } else if (difference <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}

main(40, 'city');
main(21, 'residential');
main(120, 'interstate');
main(200, 'motorway');