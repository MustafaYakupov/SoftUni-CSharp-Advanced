function attachEvents() {
    const phonebookUrl = 'http://localhost:3030/jsonstore/phonebook';

    const loadButtonElement = document.getElementById('btnLoad');
    const phonebookElement = document.getElementById('phonebook');
    const createButtonElement = document.getElementById('btnCreate');
    const personInputElement = document.getElementById('person');
    const phoneInputElement = document.getElementById('phone');

    loadButtonElement.addEventListener('click', () => {
        phonebookElement.innerHTML = '';

        fetch(phonebookUrl)
            .then(response => response.json())
            .then(phonebookData => {
                Object.values(phonebookData)
                    .forEach(entry => {
                        phonebookElement.appendChild(createEntryElement(entry));
                    })

            })
    })

    createButtonElement.addEventListener('click', () => {
        // POST request to the server when creating element

        fetch(phonebookUrl, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify({
                person: personInputElement.value,
                phone: phoneInputElement.value
            })
        })
            .then((res) => res.json())   // POST request respond is the same as from GET request
            .then(entry => {
                const liElement = createEntryElement(entry);
        
                phonebookElement.appendChild(liElement)
        
                personInputElement.value = '';
                phoneInputElement.value = '';
            })
    })

    function createEntryElement({ _id, person, phone }) {
        const personName = person;
        const personPhone = phone;

        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';

        
        const liElement = document.createElement('li');
        liElement.textContent = `${personName}: ${personPhone}`;
        
        // DELETE request to the server
        deleteButton.addEventListener('click', () => {
            fetch(`${phonebookUrl}/${_id}`, {   // Deletes from server
                method: 'DELETE'
            })
                .then(() => {
                    liElement.remove();   // Deletes in HTML
                })
        });

        liElement.appendChild(deleteButton);

        return liElement;
    }

}

attachEvents();