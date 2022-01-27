function solve() {
   let addProductButtons = document.querySelectorAll('.add-product');
   let textAreaElement = document.querySelector('textarea');
   let checkoutButtonElement = document.querySelector('.checkout');

   let products = [];
   let totalMoney = 0;

   for (let addProductButton of addProductButtons) {
      addProductButton.addEventListener('click', (e) => {
         let currentProductElement = e.currentTarget.parentElement.parentElement;

         let productName = currentProductElement
            .querySelector('.product-title')
            .textContent;

         if (!products.includes(productName)) {
            products.push(productName);
         }

         let productPrice = Number
            (currentProductElement
               .querySelector('.product-line-price')
               .textContent);

         totalMoney += productPrice;
         textAreaElement.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`
      });
   }

   checkoutButtonElement.addEventListener('click', (e) => {
      textAreaElement.textContent += `You bought ${products.join(', ')} for ${totalMoney.toFixed(2)}.`;

      for (let addProductButton of addProductButtons) {
         addProductButton.disabled = true;
      }
      checkoutButtonElement.disabled = true;
   });
}