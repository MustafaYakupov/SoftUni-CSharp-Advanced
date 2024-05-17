function create(words) {
   const contentElement = document.getElementById('content')

   // Create div with paragraph
   const divElements = words
      .map(word => {
         // Create div
         const divElement = document.createElement('div');

         // Create paragraph
         const pElement = document.createElement('p');

         // Add text content
         pElement.textContent = word;

         // Hide p content
         pElement.style.display = 'none';

         // Append paragraph to div
         divElement.appendChild(pElement);

         // Return div
         return divElement;
      })

   // Attach multiple event listeners without event delegation
   // divElements
   //    .forEach(divElement => {
   //       divElement.addEventListener('click', () => {
   //          const pElement = divElement.querySelector('p');
   //          pElement.style.display = 'block';
   //       })
   //    })

   // Append all to DOM
   // for (const div of divElements) {
   //    contentElement.appendChild(div);
   // }

   // contentElement.append(...divElements); - Does not work in Judge. Better solution but not the most effiecient

   // Using document fragment
   const divElementsFragment = document.createDocumentFragment();  // Create a separate Fragment tree structure, append all elements to it then append to DOM tree. More efficient!!!
   divElements.forEach(element => divElementsFragment.appendChild(element));
   contentElement.appendChild(divElementsFragment);

   // Attach "multiple" events using event delegation
   contentElement.addEventListener('click', (e) => {
      if (e.target.tagName === 'DIV') {
         const pElement = e.target.querySelector('p');
         pElement.style.display = 'block';
      }

   })
}