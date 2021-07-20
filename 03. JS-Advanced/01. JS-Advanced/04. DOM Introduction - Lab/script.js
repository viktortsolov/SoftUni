// Change heading
let headingElement = document.getElementById('superhero-list-heading');
headingElement.textContent += ' from MCU and DCU';

// Show inner HTML
let superheroSectionElement = document.getElementById('superhero-section');
console.log(superheroSectionElement.innerHTML);
console.log(superheroSectionElement.textContent);

// Change background
let siteWrapper = document.getElementById('wrapper');
siteWrapper.style.backgroundColor = 'pink';

// Get value from input
function addSuperhero() {
    let superheroNameInputElement = document.getElementById('superhero-name')
    let superheroName = superheroNameInputElement.value;
    console.log(superheroName);

    // Delete value when add button is clicked
    superheroNameInputElement.value = '';

    //Add hero to list
    let superheroListElement = document.getElementById('superhero-list');
    superheroListElement.innerHTML += `<li class='good'>${superheroName}</li>`; //Dangerous
}

//Targeting elements by class, returns HTMLCOllection
let goodSuperheroesLiElements = document.getElementsByClassName('good');
goodSuperheroesLiElements[0].textContent += ' The Strongest Avenger';

for (const heroElement of goodSuperheroesLiElements) { //Works in Judje!
    console.log('good superhero: ', heroElement.textContent);
}

//Targeting with CSS selector, returns NodeList
let allSuperheroesLiElements = document.querySelectorAll('#superhero-list li');
allSuperheroesLiElements.forEach((x) => { //Doesn't work in Judje!
    console.log(x.textContent);
});

//Convert HTMLCollection and NodeList to JS Array
let goodSuperheroes = Array.from(goodSuperheroesLiElements); //Judje safe!
let goodSuperheroes2 = [...goodSuperheroesLiElements]; //NOT Judje safe!

console.log(Array.isArray(goodSuperheroes));

//Get parent element and change background
let bodyElement = siteWrapper.parentElement;
bodyElement.style.backgroundColor = 'pink';

//Get children of element
let superheroListElement = document.getElementById('superhero-list');
let childrenElements = superheroListElement.children;

//Use show/hide css logic
function toggleSuperheroes() {
    let toggleHeroesButtonElement = document.getElementById('toggle-heroes-button');

    if (superheroListElement.style.display == 'none') {
        superheroListElement.style.display = 'block';
        toggleHeroesButtonElement.textContent = 'Hide';
    } else {
        superheroListElement.style.display = 'none';
        toggleHeroesButtonElement.textContent = 'Show';
    }
}

//Add striped style
let oddHeroes = document.querySelectorAll('#superhero-section li:nth-of-type(2n)');
for (const hero of oddHeroes) {
    hero.style.backgroundColor = 'lightgray';
}