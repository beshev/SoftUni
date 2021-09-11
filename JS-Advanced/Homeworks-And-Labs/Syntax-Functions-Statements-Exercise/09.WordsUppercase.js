function main(input) {
    const words = input
    .toUpperCase()
    .split(/[^a-zA-Z]/)
    .filter(w => w.length > 0)
    .join(", ");

    console.log(words);
}

function solve(text) {
    let result = text.toUpperCase()
      .match(/\w+/g)
      .join(', ');
    
    console.log(result);
}

solve('s s');