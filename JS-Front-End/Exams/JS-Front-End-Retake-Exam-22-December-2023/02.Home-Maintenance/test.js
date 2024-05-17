window.addEventListener("load", solve);

function solve() {
    const expenseTypeInputElement = document.querySelector('#form-container #expense');
    const amountInputElement = document.querySelector('#form-container #amount');
    const dateInputElement = document.querySelector('#form-container #date');
    const addButtonElement = document.querySelector('#form-container #add-btn');
    const deleteButtonElement = document.querySelector('.delete');
    const previewListElement = document.querySelector('#right-container #preview-list');
    const expensesListElement = document.querySelector('#right-container #expenses-list');

    addButtonElement.addEventListener('click', () => {
        const currentExpenseType = expenseTypeInputElement.value;
        const currentAmout = amountInputElement.value;
        const currentDate = dateInputElement.value;

        if (!currentExpenseType || !currentAmout || !currentDate) {
            return;
        }

        const expenseTypeLine = document.createElement('p');
        const amountLine = document.createElement('p');
        const dateLine = document.createElement('p');

        expenseTypeLine.textContent = `Type: ${currentExpenseType}`;
        amountLine.textContent = `Amount: ${currentAmout}$`;
        dateLine.textContent = `Date: ${currentDate}`;

        const expenseArticle = document.createElement('article');

        expenseArticle.appendChild(expenseTypeLine);
        expenseArticle.appendChild(amountLine);
        expenseArticle.appendChild(dateLine);

        const expenseItemLiElement = document.createElement('li');
        expenseItemLiElement.classList.add('expense-item');

        expenseItemLiElement.appendChild(expenseArticle);

        previewListElement.appendChild(expenseItemLiElement);

        const editButton = document.createElement('button');
        editButton.textContent = 'edit';
        editButton.classList.add('btn', 'edit');

        const okButton = document.createElement('button');
        okButton.textContent = 'ok';
        okButton.classList.add('btn', 'ok');

        const divButtons = document.createElement('div');
        divButtons.classList.add('buttons');
        divButtons.appendChild(editButton);
        divButtons.appendChild(okButton);

        expenseItemLiElement.appendChild(divButtons);

        previewListElement.appendChild(expenseItemLiElement);

        expenseTypeInputElement.value = '';
        amountInputElement.value = '';
        dateInputElement.value = '';

        addButtonElement.disabled = true;

        // Edit button
        editButton.addEventListener('click', () => {
            expenseTypeInputElement.value = currentExpenseType;
            amountInputElement.value = currentAmout;
            dateInputElement.value = currentDate;

            expenseItemLiElement.remove();

            addButtonElement.disabled = false;
        })

        // Ok button - add to expenses
        okButton.addEventListener('click', () => {
            const expenseButtonElement = expenseItemLiElement.querySelector('.buttons');
            expenseButtonElement.remove();
            expensesListElement.appendChild(expenseItemLiElement);

            addButtonElement.disabled = false;
        })
    })

    // Reload app when delete button is clicked
    deleteButtonElement.addEventListener('click', () => {
        expensesListElement.innerHTML = '';
    })
}