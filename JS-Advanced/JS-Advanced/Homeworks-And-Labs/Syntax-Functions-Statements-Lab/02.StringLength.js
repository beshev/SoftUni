function main(one, two, three){
    let totalLength = one.length + two.length + three.length;
    let avgLength = Math.floor(totalLength / 3);
    console.log(totalLength);
    console.log(avgLength);
}

main('chocolate', 'ice cream', 'cake')