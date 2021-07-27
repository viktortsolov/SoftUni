function addItem() {
    let newItemTextElement = document.getElementById('newItemText');
    let itemsElement = document.getElementById('items');

    let liItemElement = document.createElement('li');
    liItemElement.textContent = newItemTextElement.value;

    //Add delete button
    let deleteButton = document.createElement('a');
    deleteButton.setAttribute('href', '#');
    deleteButton.textContent = '[Delete]';

    //Attach event to delete button
    deleteButton.addEventListener('click', (e) => {
        e.currentTarget.parentNode.remove();
    })
    liItemElement.appendChild(deleteButton);

    itemsElement.appendChild(liItemElement);

    newItemTextElement.value = '';
}