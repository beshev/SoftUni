function solve(input, sortedCriteria) {
    class Ticked {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }
    let result = [];
    input.forEach(el => {
        let [destination, price, status] = el.split('|');
        result.push(new Ticked(destination, price, status));
    });

    if (sortedCriteria === 'destination') {
        result.sort((a, b) => a.destination.localeCompare(b.destination))
    } else if (sortedCriteria === 'price') {
        result.sort((a, b) => a.price - b.price)
    } else if (sortedCriteria === 'status') {
        result.sort((a, b) => a.status.localeCompare(b.status))
    }

    return result;
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
));

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'
));

