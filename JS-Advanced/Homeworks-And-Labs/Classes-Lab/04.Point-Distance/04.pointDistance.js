class Point {
    constructor(x, y){
        this.x = x;
        this.y = y;
    }

    static distance(pointA, pointB){
        let xPoint = ((pointA.x - pointB.x) ** 2);
        let yPoint = ((pointA.y - pointB.y) ** 2);
        let distance = Math.sqrt(xPoint + yPoint);

        return distance;
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
