function search() {
   let townsElements = Array.from(document.querySelectorAll('ul#towns li'));

   let matches = 0;

   let inputText = document.querySelector('input#searchText').value;

   for (let i = 0; i < townsElements.length; i++) {
      if (townsElements[i]
         .textContent
         .includes(inputText)) {
         townsElements[i].style.textDecoration = 'underline';
         townsElements[i].style.fontWeight = 'bold';

         matches++;
      }
   }

   document.querySelector('div#result').textContent = `${matches} matches found`;
}
