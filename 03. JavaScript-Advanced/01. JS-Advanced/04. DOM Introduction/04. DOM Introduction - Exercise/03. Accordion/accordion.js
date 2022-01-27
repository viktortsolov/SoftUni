function toggle() {

    let buttonElement = document.getElementsByClassName("button")[0];
    let paragraphElement = document.querySelector('div#extra');
    
    if (paragraphElement.style.display == 'none') {
        paragraphElement.style.display = 'block';
        buttonElement.textContent = 'Less';
    } else {
        paragraphElement.style.display = 'none';
        buttonElement.textContent = 'More';
    }

}