function addItem() {
    let newItemTextElement = document.getElementById('newItemText');
    let itemsElement = document.getElementById('items');

    let liItemElement = document.createElement('li');
    liItemElement.textContent = newItemTextElement.value;
    itemsElement.appendChild(liItemElement);

    newItemTextElement.value = '';

    
}