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

//With HTML Attributes event
function heroesMouseOverHandler(e){
    console.log(`Show hero: ${e.target.textContent}`);
}

//With DOM element properties
let heroNameElement = document.getElementById('hero-name');
heroNameElement.onfocus = function(e){
    console.log('Start typing a hero...');
};
heroNameElement.onblur = (e) => console.log('Stop typing a hero!');

//With DOM event hanдler - preferred method
function heroNameInputHandler(event){
    console.log(event.currentTarget.value);
}

heroNameElement.addEventListener('input', heroNameInputHandler);

//Click on hero, but NOT the best way!
//let heroListItemElements = document.querySelectorAll('#hero-list li');
//for (const heroElement of heroListItemElements) {
//    heroElement.addEventListener('click', (e) => {
//        console.log(`You clicked on hero: ${e.target.textContent}`);
//    });
//}

//Click on hero, but THE BEST way
let heroListElement = document.getElementById('hero-list');
heroListElement.addEventListener('click', (e) => {
    if (e.target.tagName != 'LI') {
        return;
    }
    console.log(`You clicked on hero: ${e.target.textContent}`);
});
 