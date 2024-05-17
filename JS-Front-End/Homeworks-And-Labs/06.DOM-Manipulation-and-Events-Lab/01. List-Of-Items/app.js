function addItem() {
    const itemsElement = document.getElementById('items');
    const textInputElement = document.getElementById('newItemText');

    // Input text
    const textToAdd = textInputElement.value;

    // Create the new element 
    const newElement = document.createElement('li');

    // Add text content
    newElement.textContent = textToAdd;

    // Add the new element to the DOM tree
    itemsElement.appendChild(newElement);

    // Clear input element
    textInputElement.value = '';
}