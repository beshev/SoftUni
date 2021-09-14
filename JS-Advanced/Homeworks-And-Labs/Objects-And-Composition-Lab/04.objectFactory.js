let library = {
    print: function () {
      console.log(`${this.name} is printing a page`);
    },
    scan: function () {
      console.log(`${this.name} is scanning a document`);
    },
    play: function (artist, track) {
      console.log(`${this.name} is playing '${track}' by ${artist}`);
    },
  };
  
  let orders = [
    {
      template: { name: 'ACME Printer'},
      parts: ['print']      
    },
    {
      template: { name: 'Initech Scanner'},
      parts: ['scan']      
    },
    {
      template: { name: 'ComTron Copier'},
      parts: ['scan', 'print']      
    },
    {
      template: { name: 'BoomBox Stereo'},
      parts: ['play']      
    },
  ];
  

  function main(library, orders) {
    let result = [];

    for (let order of orders) {
        let currentObj = {
            name: order.template.name,
        };
        order.parts.forEach(key => {
            currentObj[key] = library[key];
        });
        
        result.push(currentObj);
    }

    return result;
}

let result = main(library,orders);
console.log(result[0].print()); 