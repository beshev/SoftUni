function main(x1,y1,x2,y2) {

    ValidateDistance(x1,y1,0,0);
    ValidateDistance(x2,y2,0,0);
    ValidateDistance(x1,y1,x2,y2);

    function ValidateDistance(x1,y1,x2,y2) {
        let x = x1 - x2;
        let y = y1 - y2;
    
        let distance =  Math.sqrt(x ** 2 + y ** 2);
        
        let status = 'valid';
        if (!Number.isInteger(distance)) {
            status = 'invalid';
        }
    
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${status}`);
    }
}

main(2, 1, 1, 1);