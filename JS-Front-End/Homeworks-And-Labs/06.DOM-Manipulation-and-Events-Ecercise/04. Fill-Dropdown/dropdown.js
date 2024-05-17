function addItem() {
    const newItemTextElement = document.getElementById('newItemText');
    const newItemValueElement = document.getElementById('newItemValue');
    const selectItemElement = document.getElementById('menu');

    const newOptionElement = document.createElement('option');
    
    newOptionElement.textContent = newItemTextElement.value;
    newOptionElement.value = newItemValueElement.value;

    selectItemElement.appendChild(newOptionElement);

    newItemTextElement.value = '';
    newItemValueElement.value = '';
}