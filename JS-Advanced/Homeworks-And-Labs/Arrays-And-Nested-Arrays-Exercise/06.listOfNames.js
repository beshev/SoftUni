function main(array) {
    let number = 1;
   return array
          .sort((a,b) => a
          .localeCompare(b))
          .map(x => `${number++}.${x}`)
          .join('\n');
}

console.log(main(["John", "Bob", "Christina", "Ema"]));