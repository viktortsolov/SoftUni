function sumTable() {
    let tableElements = document
        .querySelectorAll('table tr td');
    
    let sum = 0;
    
    for (let i = 1; i < tableElements.length - 2; i+=2) {
        let number = Number(tableElements[i].textContent);
        sum += number;
    }

    let sumElement = document.querySelector('table tr td#sum');

    sumElement.textContent = sum;
}