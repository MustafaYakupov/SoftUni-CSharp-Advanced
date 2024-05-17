function search() {
   const townListElement = document.getElementById('towns');
   const searchTextElement = document.getElementById('searchText');
   const resultElement = document.getElementById('result');

   let matchCount = 0;
   const townElements = Array.from(townListElement.children);

   for (const town of townElements) {
      if (town.textContent.toLowerCase()
         .includes(searchTextElement.value.toLowerCase())) {
         town.style.textDecoration = 'underline';
         town.style.fontWeight = 'bold';
         matchCount++;
      }
   }

   resultElement.textContent = `${matchCount} matches found`;
}
