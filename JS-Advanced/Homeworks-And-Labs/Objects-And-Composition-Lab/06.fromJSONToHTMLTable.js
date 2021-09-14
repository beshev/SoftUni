function jsonToHtmlTable(json) {

    let arr = JSON.parse(json);
    
    let outputArr = ["<table>"];
    
    outputArr.push(makeKeyRow(arr));
    
    arr.forEach((obj) => outputArr.push(makeValueRow(obj)));
    
    outputArr.push("</table>");
    
    function makeKeyRow(arr) { 
        let result = '   <tr>';
        let keys = [];
        for (const obj of arr) {
            for (const key of Object.keys(obj)) {
                if (!keys.includes(key)) {
                    keys.push(key);
                    result += `<th>${escapeHtml(key)}</th>`;
                }
            }
        }
        result += '</tr>';
        return result;
     }
    
    function makeValueRow(obj) { 
        let values = Object.values(obj);
        let result = `   <tr>`;
        for (const value of values) {
            result += `<td>${escapeHtml(value)}</td>`;
        }
        result += `</tr>`;

        return result;
     };
    
    function escapeHtml(value) { 
        return value.toString()
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#39;")
     };
     

    console.log(outputArr.join('\n'));
    
};

jsonToHtmlTable(`[{"Name":"Stamat",
"Score":5.5},
{"Name":"Rumen",
"Score":6}]
`);

jsonToHtmlTable(`[{"Name":"Pesho",
"Score":4,
"Grade":8},
{"Name":"Gosho",
"Score":5,
"Grade":8},
{"Name":"Angel",
"Score":5.50,
"Grade":10}]
`);