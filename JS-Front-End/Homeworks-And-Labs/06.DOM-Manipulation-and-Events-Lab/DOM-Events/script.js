const decrementButtonElement = document.getElementById('decrement-button');
const counterElement = document.getElementById('count');
const resetButtonElement = document.getElementById('reset-button');


// Using DOM event handler = preferred method
const eventListener = () => {
    counterElement.textContent = 0;
};

resetButtonElement.addEventListener('click', eventListener);

// Using DOM element properties
decrementButtonElement.onclick = function() {
    counterElement.textContent = Number(counterElement.textContent) - 1;
}

// With HTML Attribute
function onIncrement() {
    counterElement.textContent = Number(counterElement.textContent) + 1;
}

// Remove event listener for reset after 10 seconds
setTimeout(() => {
    resetButtonElement.removeEventListener('click', eventListener);
}, 10000);

// Use input event
const inputNumberElement = document.getElementById('number');

inputNumberElement.addEventListener('input', (event) => {
    counterElement.textContent = event.target.value;
})



