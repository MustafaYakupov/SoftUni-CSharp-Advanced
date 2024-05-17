// DOM Query
const movieListElement = document.getElementById('movies');
const firstMovieElement = document.querySelector('.first-movie');

// Create Element - not in DOM tree yet
const secondMovieElement = document.createElement('li');
secondMovieElement.textContent = 'Man of Steel';

// Append new element to DOM
movieListElement.appendChild(secondMovieElement); 

// Append existing element to DOM - saves the element at the last position
movieListElement.appendChild(firstMovieElement);

// Clone existing element and prepend
const firstMovieCloneElement = firstMovieElement.cloneNode(true); // NO TRUE -  Clones just the node, does not clone the textContent. TRUE says clone the node nad its children (text)
movieListElement.prepend(firstMovieCloneElement); // Saves the element at the first position
firstMovieCloneElement.textContent = 'Fast and Furious';

// append element on a specific place before another element
const thirdMovieElement = document.createElement('li');
thirdMovieElement.textContent = 'Lord of the Rings';

movieListElement.insertBefore(thirdMovieElement, secondMovieElement);

const fourthMovieElement = document.createElement('li');
fourthMovieElement.textContent = 'Breaking Bad';

thirdMovieElement.after(fourthMovieElement); // or before