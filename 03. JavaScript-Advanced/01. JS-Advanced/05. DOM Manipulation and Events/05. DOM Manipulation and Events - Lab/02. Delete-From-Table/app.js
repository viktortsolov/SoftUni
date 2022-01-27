function deleteByEmail() {
    let input = document.querySelector('input[name="email"]').value;
    let tableElements = document.querySelectorAll('table tbody tr');

    for (const tableElement of tableElements) {
        if (tableElement.textContent.includes(input)) {
            tableElement.removeChild(input);
        }
    }
}