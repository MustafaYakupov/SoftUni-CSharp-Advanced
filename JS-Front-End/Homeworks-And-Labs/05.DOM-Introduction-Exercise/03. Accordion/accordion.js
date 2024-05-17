function toggle() {
    const extraInformationElement = document.getElementById('extra');
    const buttonElement = document.querySelector('.head .button');

    const currentButtonText = buttonElement.textContent;
    
    if (currentButtonText === 'More') {
        extraInformationElement.style.display = 'block';
        buttonElement.textContent = 'Less';
    } else {
        extraInformationElement.style.display = 'none';
        buttonElement.textContent = 'More';
    }
}