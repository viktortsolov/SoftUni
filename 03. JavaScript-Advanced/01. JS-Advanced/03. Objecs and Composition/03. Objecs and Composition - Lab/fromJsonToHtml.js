function readJSON(jsonString) {
    let arr = JSON.parse(jsonString);
    let outputArr = ["<table>"];
    outputArr.push(makeKeyRow(arr));
    arr.forEach((obj) => outputArr.push(makeValueRow(obj)));
    outputArr.push("</table>");

    function makeKeyRow(arr) {
        //TODO    
    }

    function makeValueRow(obj) {
        //TODO    
    }

    function escapeHtml(value) {
        //TODO
    }

    console.log(outputArr.join('\n'));
}

readJSON(`
[{"Name":"Stamat",
"Score":5.5},

{"Name":"Rumen",
"Score":6}]`
);