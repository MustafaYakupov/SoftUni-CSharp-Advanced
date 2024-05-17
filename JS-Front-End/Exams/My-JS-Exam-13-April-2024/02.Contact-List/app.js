window.addEventListener("load", solve);

function solve() {
  const nameInputElement = document.getElementById('name');
  const phoneInputElement = document.getElementById('phone');
  const categoryInputElement = document.getElementById('category');
  const addButton = document.getElementById('add-btn');
  const checkListElement = document.getElementById('check-list');
  const contactListElement = document.getElementById('contact-list');

  addButton.addEventListener('click', () => {
    const name = nameInputElement.value;
    const phone = phoneInputElement.value;
    const category = categoryInputElement.value;

    if (!name || !phone || !category) {
      return;
    }

    // Create DOM structure
    const editButton = document.createElement('button');
    editButton.classList.add('edit-btn');

    const saveButton = document.createElement('button');
    saveButton.classList.add('save-btn');

    // Create buttons container
    const buttonsDivContainer = document.createElement('div');
    buttonsDivContainer.classList.add('buttons');

    // Append buttons to container
    buttonsDivContainer.appendChild(editButton);
    buttonsDivContainer.appendChild(saveButton);


    const nameParagraph = document.createElement('p');
    nameParagraph.textContent = `name:${name}`;

    const phoneParagraph = document.createElement('p');
    phoneParagraph.textContent = `phone:${phone}`;

    const categoryParagraph = document.createElement('p');
    categoryParagraph.textContent = `category:${category}`;

    const articleInfoElement = document.createElement('article');

    // Apped paragraphs to article
    articleInfoElement.appendChild(nameParagraph);
    articleInfoElement.appendChild(phoneParagraph);
    articleInfoElement.appendChild(categoryParagraph);

    // Create li element
    const dataLiElement = document.createElement('li');

    dataLiElement.appendChild(articleInfoElement);
    dataLiElement.appendChild(buttonsDivContainer);

    checkListElement.appendChild(dataLiElement);

    // Event listeners
    // Attach event on edit button
    editButton.addEventListener('click', () => {
      // Populate input fields with info
      nameInputElement.value = name;
      phoneInputElement.value = phone;
      categoryInputElement.value = category;

      // Delete record from list
      dataLiElement.remove();
    })

    // Attach event on save button
    saveButton.addEventListener('click', () => {
      // Delete from the check list
      dataLiElement.remove();

      // Remove buttons
      buttonsDivContainer.remove();

      // Add delete button
      const deleteButton = document.createElement('button');
      deleteButton.classList.add('del-btn');

      articleInfoElement.appendChild(deleteButton);

      // Append to contact list
      contactListElement.appendChild(dataLiElement);

      // Attach event on delete button
      deleteButton.addEventListener('click', () => {
        dataLiElement.remove();
      });
  })

    // Clear input data
    nameInputElement.value = '';
    phoneInputElement.value = '';
    categoryInputElement.value = '';
  })
}
