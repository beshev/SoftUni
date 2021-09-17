function generateReport() {
    //TODO
    let indexes = [];

       let headers = Array.from(document.querySelectorAll('th [type=checkbox]'));

       headers.forEach((element, i) => {
            if (element.checked) {
                indexes.push(i);
            }
        });

    
    let result = [];
    let tableRows = document.querySelectorAll('tbody tr')

    for (const row of tableRows) {
        let currentObj = {};
           
        indexes.forEach(index => {
            currentObj[headers[index].name] = row.children[index].textContent;
        });

        result.push(currentObj);
    }

    document.querySelector('#output').textContent = JSON.stringify(result,null,4);

}