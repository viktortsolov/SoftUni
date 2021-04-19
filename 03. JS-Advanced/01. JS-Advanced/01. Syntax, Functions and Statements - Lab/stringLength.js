function strlen(a, b, c){
    let total = 0;

    total += a.length + b.length + c.length;

    let average = Math.floor(total / 3);
    
    console.log(total);
    console.log(average);
}

strlen('chocolate', 'ice cream', 'cake');
strlen('pasta', '5', '22.3');