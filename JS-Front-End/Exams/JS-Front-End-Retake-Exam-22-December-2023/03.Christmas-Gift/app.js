const baseUrl = 'http://localhost:3030/jsonstore/gifts';

const loadPresentsButtonElement = document.getElementById('load-presents');
const giftListElement = document.getElementById('gift-list');
const editPresentButtonElement = document.getElementById('edit-present');
const addPresentButtonElement = document.getElementById('add-present');
const giftInputElement = document.getElementById('gift');
const forInputElement = document.getElementById('for');
const priceInputElement = document.getElementById('price');

let giftId = null;

// Load presents
loadPresentsButtonElement.addEventListener('click', loadPresents);

// Add present
addPresentButtonElement.addEventListener('click', addPresent);

// Edit present
editPresentButtonElement.addEventListener('click', editPresent);

async function editPresent() {
    // Get data from inputs
    const gift = giftInputElement.value;
    const forr = forInputElement.value;
    const price = priceInputElement.value;

    // PUT request to server 
    await fetch(`${baseUrl}/${giftId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            _id: giftId,
            gift,
            price,
            for: forr,
        })
    })

    // Deactivate edit button
    editPresentButtonElement.disabled = true;
    
    // Activate add button
    addPresentButtonElement.disabled = false;

    // Clear input fields
    clearInputData();

    // Clear id
    giftId = null;
    
    // List presents
    loadPresents();
}

async function addPresent() {
    // Get input fields info
    const gift = giftInputElement.value;
    const forr = forInputElement.value;
    const price = priceInputElement.value;

    // Post request
    const response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            gift,
            for: forr,
            price,
        }),
    })

    // Clear input fields
    clearInputData();

    // List all gifts
    loadPresents();
}

async function loadPresents() {
    // Get all presents 
    const response = await fetch(baseUrl);
    const data = await response.json();

    // clear gift list element
    giftListElement.innerHTML = '';

    // Attach to DOM
    for (const present of Object.values(data)) {
        const gift = present.gift;
        const forr = present.for;
        const price = present.price;

        const changeButton = document.createElement('button');
        changeButton.classList.add('change-btn');
        changeButton.textContent = 'Change';

        const deleteButton = document.createElement('button');
        deleteButton.classList.add('delete-btn');
        deleteButton.textContent = 'Delete';

        // Attach event on change button
        changeButton.addEventListener('click', async () => {
            // Populate input fields
            giftInputElement.value = gift;
            forInputElement.value = forr;
            priceInputElement.value = price;

            // Save present Id
            giftId = present._id;

            // Remove present from DOM
            giftSockElement.remove();

            // Activate edit button
            editPresentButtonElement.removeAttribute('disabled');

            // Deactivate add button
            addPresentButtonElement.setAttribute('disabled', 'disabled');
        })

        // Attach event on delete button
        deleteButton.addEventListener('click', async () => {
            // Delete item request
            await fetch(`${baseUrl}/${present._id}`, {
                method: 'DELETE'
            });

            // Remove item from DOM
            giftSockElement.remove();

            // Load presents
            loadPresents();
        })

        const buttonsContainer = document.createElement('div');
        buttonsContainer.classList.add('buttons-container');

        buttonsContainer.appendChild(changeButton);
        buttonsContainer.appendChild(deleteButton);

        const presentNameP = document.createElement('p');
        presentNameP.textContent = gift;

        const forPersonNameP = document.createElement('p');
        forPersonNameP.textContent = forr;

        const priceP = document.createElement('p');
        priceP.textContent = price;

        const paragraphsDivContainer = document.createElement('div');
        paragraphsDivContainer.classList.add('content');

        paragraphsDivContainer.appendChild(presentNameP);
        paragraphsDivContainer.appendChild(forPersonNameP);
        paragraphsDivContainer.appendChild(priceP);

        const giftSockElement = document.createElement('div');
        giftSockElement.classList.add('gift-sock');

        // Append all to DOM
        giftSockElement.appendChild(paragraphsDivContainer);

        giftSockElement.appendChild(buttonsContainer);

        giftListElement.appendChild(giftSockElement);

        // Deactivate edit button
        editPresentButtonElement.disabled = true;
    }
}

function clearInputData() {
    giftInputElement.value = '';
    forInputElement.value = '';
    priceInputElement.value = '';
}