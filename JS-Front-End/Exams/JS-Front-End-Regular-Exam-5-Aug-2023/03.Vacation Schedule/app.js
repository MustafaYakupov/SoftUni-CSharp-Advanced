const baseUrl = 'http://localhost:3030/jsonstore/tasks';

const loadVacationsButton = document.getElementById('load-vacations');
const listVacationsElement = document.getElementById('list');
const editVacationButton = document.getElementById('edit-vacation');
const addVacationButton = document.getElementById('add-vacation');
const nameInputElement = document.getElementById('name');
const daysInputElement = document.getElementById('num-days');
const dateInputElement = document.getElementById('from-date');

let id = null;

// Load vacations
loadVacationsButton.addEventListener('click', loadVacations);

// Add vacation
addVacationButton.addEventListener('click', addVacation);

// Edit vacation
editVacationButton.addEventListener('click', editVacation);

async function editVacation() {
    // Get data from inputs
    const name = nameInputElement.value;
    const days = daysInputElement.value;
    const date = dateInputElement.value;

    // PUT request to server 
    await fetch(`${baseUrl}/${id}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            _id: id,
            name,
            days,
            date,
        })
    })

    // Deactivate edit button
    editVacationButton.disabled = true;
    
    // Activate add button
    addVacationButton.disabled = false;

    // Clear input fields
    clearInputFields();

    // Clear id
    id = null;
    
    // List vacations
    loadVacations();
}

async function addVacation() {
    // Get input values
    const name = nameInputElement.value;
    const days = daysInputElement.value;
    const date = dateInputElement.value;

    // Post request
    await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            name,
            days,
            date,
        }),
    })

    // Clear input fields
    clearInputFields();

    // Load all vacations
    loadVacations();
}

function clearInputFields() {
    nameInputElement.value = '';
    daysInputElement.value = '';
    dateInputElement.value = '';
}

async function loadVacations() {
    // Get request for all vacations
    const response = await fetch(baseUrl);
    const data = await response.json();

    // Clear list vacations element
    listVacationsElement.innerHTML = '';

    // Append vacations to DOM
    for (const vacation of Object.values(data)) {
        const name = vacation.name;
        const days = vacation.days;
        const date = vacation.date;

        const doneButton = document.createElement('button');
        doneButton.classList.add('done-btn');
        doneButton.textContent = 'Done';

        // Attach event on done button
        doneButton.addEventListener('click', async () => {
            await fetch(`${baseUrl}/${vacation._id}`, {
                method: 'DELETE',
            })

            containerDiv.remove();

            loadVacations();
        })

        const changeButton = document.createElement('button');
        changeButton.classList.add('change-btn');
        changeButton.textContent = 'Change';

        // Attach event on change button
        changeButton.addEventListener('click', async () => {
            // Populate input fields
            nameInputElement.value = name;
            daysInputElement.value = days;
            dateInputElement.value = date;

            // Save id
            id = vacation._id;

            // Remove record from DOM
            containerDiv.remove();

            // Activate edit vactaion button
            editVacationButton.disabled = false;

            // Deactivate add button
            addVacationButton.disabled = true;
        })

        const daysH3 = document.createElement('h3');
        daysH3.textContent = days;

        const dateH3 = document.createElement('h3');
        dateH3.textContent = date;

        const nameH2 = document.createElement('h2');
        nameH2.textContent = name;

        const containerDiv = document.createElement('div');
        containerDiv.classList.add('container');

        containerDiv.appendChild(nameH2);
        containerDiv.appendChild(dateH3);
        containerDiv.appendChild(daysH3);
        containerDiv.appendChild(changeButton);
        containerDiv.appendChild(doneButton);

        listVacationsElement.appendChild(containerDiv);
    }

    // Deactivate edit button
    editVacationButton.disabled = true;

}