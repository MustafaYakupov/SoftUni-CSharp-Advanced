function lockedProfile() {
    const profileElements = document.querySelectorAll('.profile');
    
    for (const profile of profileElements) {
        const showButtonElement = profile.querySelector('button');
        const lockButtonElement = profile.querySelector('input[type=radio][value=lock]');
        
        showButtonElement.addEventListener('click', (e) => {
            if (lockButtonElement.checked) {
                return;
            }

            const additionInfoElement = showButtonElement.previousElementSibling;

            if (showButtonElement.textContent === 'Show more') {
                showButtonElement.textContent = 'Hide it';
                additionInfoElement.style.display = 'block';

            } else {
                additionInfoElement.style.display = 'none';
                showButtonElement.textContent = 'Show more';
            }
        })
    }
}