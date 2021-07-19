function extractText() {
    let listItems = document.querySelectorAll('#items li');
    let result = '';

    for (const listItem of listItems) {
        result+=listItem.textContent.trim() + '\n';
    }

    let resultElement = document.getElementById('result');
    resultElement.textContent = result.trim();
}