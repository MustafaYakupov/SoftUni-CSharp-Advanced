
function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/messenger';

    const sendButtonElement = document.getElementById('submit');
    const refreshButtonElement = document.getElementById('refresh');
    const authorInputElement = document.querySelector('#controls input[name=author]');
    const contentInputElement = document.querySelector('#controls input[name=content]');
    const textAreaElements = document.getElementById('messages');

    sendButtonElement.addEventListener('click', () => {
        fetch(baseUrl, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify({
                author: authorInputElement.value,
                content: contentInputElement.value,
            })
        })
    });

    refreshButtonElement.addEventListener('click', () => {
        fetch(baseUrl)
            .then((res) => res.json())
            .then(entry => {
                Object.values(entry)
                .forEach(user => {
                    textAreaElements.textContent += `${user.author}: ${user.content}\n`;
                })
            })
    })
}

attachEvents();