const baseUrl = 'http://localhost:3030/jsonstore/games';

const loadGamesButton = document.getElementById('load-games');
const gamesListElement = document.getElementById('games-list');
const editButton = document.getElementById('edit-game');
const addGameButton = document.getElementById('add-game');
const nameInputElement = document.getElementById('g-name');
const typeInputElement = document.getElementById('type');
const playersInputElement = document.getElementById('players');

let gameId = null;

// Load games
loadGamesButton.addEventListener('click', loadGames);

// Add game
addGameButton.addEventListener('click', addGame)

// Edit game
editButton.addEventListener('click', editGame)

async function editGame() {
    // Get data from inputs
    const name = nameInputElement.value;
    const type = typeInputElement.value;
    const players = playersInputElement.value;

    // PUT request to server 
    await fetch(`${baseUrl}/${gameId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            _id: gameId,
            name,
            type,
            players,
        })
    })

    // Deactivate edit button
    editButton.disabled = true;
    
    // Activate add button
    addGameButton.disabled = false;

    // Clear input fields
    clearInputData();

    // Clear id
    giftId = null;
    
    // List presents
    loadGames();
}

async function addGame() {
    // Get data from input fields
    const name = nameInputElement.value;
    const type = typeInputElement.value;
    const players = playersInputElement.value;

    // Post request
    const response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            name,
            type,
            players,
        }),
    })

    // List all games
    loadGames();

    // Clear input fields
    clearInputData();
}

async function loadGames() {
    // Get all games
    const response = await fetch(baseUrl);
    const data = await response.json();

    // Clear html
    gamesListElement.innerHTML = '';

    // Append all to DOM
    for (const game of Object.values(data)) {
        const name = game.name;
        const type = game.type;
        const players = game.players;

        const changeButton = document.createElement('button');
        changeButton.classList.add('change-btn');
        changeButton.textContent = 'Change';

        const deleteButton = document.createElement('button');
        deleteButton.classList.add('delete-btn');
        deleteButton.textContent = 'Delete';

        const buttonsContainer = document.createElement('div');
        buttonsContainer.classList.add('buttons-container');

        buttonsContainer.appendChild(changeButton);
        buttonsContainer.appendChild(deleteButton);

        // Attach event on change button
        changeButton.addEventListener('click', async () => {
            // Populate input fields
            nameInputElement.value = name;
            typeInputElement.value = type;
            playersInputElement.value = players;

            // Save game Id
            gameId = game._id;

            // Activate edit button
            editButton.disabled = false;

            // Deactivate add button
            addGameButton.disabled = true;
        })

        // Attach event on delete button
        deleteButton.addEventListener('click', async () => {
            // Delete item request
            await fetch(`${baseUrl}/${game._id}`, {
                method: 'DELETE'
            });

            // Remove item from DOM
            boardGameContainer.remove();

            // Load presents
            loadGames();
        })

        const gameNameP = document.createElement('p');
        gameNameP.textContent = name;

        const playersP = document.createElement('p');
        playersP.textContent = players;

        const typeP = document.createElement('p');
        typeP.textContent = type;

        const paragraphsDivContainer = document.createElement('div');
        paragraphsDivContainer.classList.add('content');

        paragraphsDivContainer.appendChild(gameNameP);
        paragraphsDivContainer.appendChild(playersP);
        paragraphsDivContainer.appendChild(typeP);

        const boardGameContainer = document.createElement('div');
        boardGameContainer.classList.add('board-game');

        boardGameContainer.appendChild(paragraphsDivContainer);
        boardGameContainer.appendChild(buttonsContainer);

        gamesListElement.appendChild(boardGameContainer);
    }

    // Deactivate edit button
    editButton.disabled = true;

}

function clearInputData() {
    nameInputElement.value = '';
    typeInputElement.value = '';
    playersInputElement.value = '';
}