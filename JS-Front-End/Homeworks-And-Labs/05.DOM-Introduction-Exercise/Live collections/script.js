const movieListElement = document.getElementById('movies');

const liveElementsCollection = movieListElement.children; // HTML collection - always live
const liveNodeList = movieListElement.childNodes; // Live Node list - live
const staticNodeList = document.querySelectorAll('#movies li'); // Statick Node list

console.log(liveElementsCollection);
console.log(liveNodeList);
console.log(staticNodeList);
console.log('-------------------');

setTimeout(() => {
    const movieLiElement = document.createElement('li');
    movieLiElement.textContent = 'Case for Christ';
    movieListElement.appendChild(movieLiElement);

    console.log(liveElementsCollection);
    console.log(liveNodeList);
    console.log(staticNodeList);
}, 3000)
