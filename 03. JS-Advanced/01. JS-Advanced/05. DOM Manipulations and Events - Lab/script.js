//Add hero function to list
function addHero() {
    let heroNameInputElement = document.getElementById('hero-name');
    let heroListElement = document.getElementById('hero-list');

    //Adding hero dangerously, avoid using!!!
    //heroListElement.innerHTML+=`<li>${heroNameElement.value}</li>`;

    //Add hero correctly by creating element
    let newHeroItemElement = document.createElement('li');
    newHeroItemElement.textContent = heroNameInputElement.value;
    heroListElement.appendChild(newHeroItemElement); //Goes as last child

    //Add hero by clone element (also correct)
    let firstListItemElement = heroListElement.children[0];
    let newClonedItemElement = firstListItemElement.cloneNode();
    newClonedItemElement.textContent = heroNameInputElement.value;
    heroListElement.prepend(newClonedItemElement); //Goes as first child

    //Clear input
    heroNameInputElement.value = '';
}

//Delete last hero from the list
function deleteHero() {
    let heroListElement = document.querySelector('#hero-list');
    let heroListChildrenElements = heroListElement.children;
    let lastHeroElement = heroListChildrenElements[heroListChildrenElements.length - 1];

    //heroListElement.removeChild(lastHeroElement); //Delete from parent
    lastHeroElement.remove();
}