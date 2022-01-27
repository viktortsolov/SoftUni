function addItem() {
    const inputTextElement = document.querySelector('#newItemText');
    let itemsElement = document.querySelector('#items');

    let newHeroItemElement = document.createElement('li');
    newHeroItemElement.textContent = inputTextElement.value;
    itemsElement.appendChild(newHeroItemElement);
}