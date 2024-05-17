window.addEventListener("load", solve);

function solve() {
    const placeInputElement = document.getElementById('place');
    const actionInputElement = document.getElementById('action');
    const personInputElement = document.getElementById('person');
    const addButton = document.getElementById('add-btn');
    const taskListElement = document.getElementById('task-list');
    const doneListElement = document.getElementById('done-list');

    // Attach on add button
    addButton.addEventListener('click', () => {
        // Get input fields info
        const place = placeInputElement.value;
        const action = actionInputElement.value;
        const person = personInputElement.value;

        // Check if fields are empty
        if (!place || !action || !person) {
            return;
        }

        // Create DOM structure
        // Create buttons
        const doneButton = document.createElement('button');
        doneButton.classList.add('done');
        doneButton.textContent = 'Done';

        const editButton = document.createElement('button');
        editButton.classList.add('edit');
        editButton.textContent = 'Edit';

        // Create buttons container
        const buttonsDivContainer = document.createElement('div');
        buttonsDivContainer.classList.add('buttons');

        // Append buttons to container
        buttonsDivContainer.appendChild(editButton);
        buttonsDivContainer.appendChild(doneButton);

        // Create info paragraphs
        const placePElement = document.createElement('p');
        placePElement.textContent = `Place:${place}`;
        const actionPElement = document.createElement('p');
        actionPElement.textContent = `Action:${action}`;
        const personPElement = document.createElement('p');
        personPElement.textContent = `Person:${person}`;

        // Create article
        const articleInfoElement = document.createElement('article');

        // Apped paragraphs to article
        articleInfoElement.appendChild(placePElement);
        articleInfoElement.appendChild(actionPElement);
        articleInfoElement.appendChild(personPElement);

        // Create li element
        const taskLiElement = document.createElement('li');
        taskLiElement.classList.add('clean-task');

        // Append article and buttons to li
        taskLiElement.appendChild(articleInfoElement);
        taskLiElement.appendChild(buttonsDivContainer);

        // Append li to list
        taskListElement.appendChild(taskLiElement);

        // Event listeners
        // Attach event on edit button
        editButton.addEventListener('click', () => {
            // Populate input fields with info
            placeInputElement.value = place;
            actionInputElement.value = action;
            personInputElement.value = person;

            // Delete record from list
            taskLiElement.remove();
        })

        // Attach event on done button
        doneButton.addEventListener('click', () => {
            // Delete from the task list
            taskLiElement.remove();

            // Append to done list
            doneListElement.appendChild(taskLiElement);

            // Remove edit button
            editButton.remove();

            // Remove done button
            doneButton.remove();

            // Add delete button
            const deleteButton = document.createElement('button');
            deleteButton.classList.add('delete');
            deleteButton.textContent = 'Delete';

            articleInfoElement.appendChild(deleteButton);

            // Attach event on delete button
            deleteButton.addEventListener('click', () => {
                taskLiElement.remove();
            });
        })

        // Clear input fields
        placeInputElement.value = '';
        actionInputElement.value = '';
        personInputElement.value = '';
    })
}