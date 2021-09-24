function solve(area,vol,obj) {
    let cordinatesObjs = JSON.parse(obj);
    let result = [];

    for (const objCoredinate of cordinatesObjs) {
        let currObj = {
            area: area.call(objCoredinate),
            volume: vol.call(objCoredinate),
        };

        result.push(currObj);
    }

    return result;
}   

console.log(solve(area,vol,`[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]
    `));

function vol() {
    return Math.abs(this.x * this.y * this.z);
};

function area() {
    return Math.abs(this.x * this.y);
};

