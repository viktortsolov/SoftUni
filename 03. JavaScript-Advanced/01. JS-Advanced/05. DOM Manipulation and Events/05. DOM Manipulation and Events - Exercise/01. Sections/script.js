function create(words) {
   let content = document.getElementById('content');

   for (const word of words) {
      let div = document.createElement('div');
      let p = document.createElement('p');

      p.textContent = word;
      p.style.display = 'none';
      div.appendChild(p);

      content.appendChild(div);
   }

   content.addEventListener('click', (e) => {
      if (e.target.tagName === 'DIV' || e.target.tagName === 'P') {
         let p = e.target.children[0] || e.target;
         let isVisible = p.style.display === 'block';
         p.style.display = isVisible ? 'none' : 'block';
      }
   });
}