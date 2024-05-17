const baseUrl = 'http://localhost:3030/jsonstore/tasks';

const mealListElement = document.getElementById('list');
const loadMealsButtonElement = document.getElementById('load-meals');
const editMealButtonElement = document.getElementById('edit-meal');
const addMealButtonElement = document.getElementById('add-meal');
const foodInputElement = document.getElementById('food');
const timeInputElement = document.getElementById('time');
const caloriesInputElement = document.getElementById('calories');
const formElement = document.getElementById('form');

let loadMealsFunc;

loadMealsButtonElement.addEventListener('click', () => {
    loadMealsFunc = function loadMeals() {
        fetch(baseUrl)
            .then(response => response.json())
            .then(mealData => {
                const meals = Object.values(mealData);

                for (const meal of meals) {
                    const food = meal.food;
                    const time = meal.time;
                    const calories = meal.calories;

                    const changeButton = document.createElement('button');
                    changeButton.classList.add('change-meal');
                    changeButton.textContent = 'Change';

                    const deleteButton = document.createElement('button');
                    deleteButton.classList.add('delete-meal');
                    deleteButton.textContent = 'Delete';

                    const buttonsDiv = document.createElement('div');
                    buttonsDiv.id = 'meal-buttons';

                    buttonsDiv.appendChild(changeButton);
                    buttonsDiv.appendChild(deleteButton);

                    const caloriesElement = document.createElement('h3');
                    caloriesElement.textContent = calories;

                    const timeElement = document.createElement('h3');
                    timeElement.textContent = time;

                    const foodElement = document.createElement('h2');
                    foodElement.textContent = food;

                    const mealDiv = document.createElement('div');
                    mealDiv.classList.add('meal');

                    mealDiv.appendChild(foodElement);
                    mealDiv.appendChild(timeElement);
                    mealDiv.appendChild(caloriesElement);
                    mealDiv.appendChild(buttonsDiv);

                    mealListElement.appendChild(mealDiv);

                    changeButton.addEventListener('click', () => {
                        // Save current meal id
                        formElement.setAttribute('data-id', meal._id);

                        foodInputElement.value = food;
                        timeInputElement.value = time;
                        caloriesInputElement.value = calories;

                        // activate edit button
                        editMealButtonElement.disabled = false;

                        // deactivate add button
                        addMealButtonElement.disabled = true;

                        mealDiv.remove();
                    })

                    // Attach on delete
                    deleteButton.addEventListener('click', () => {
                        fetch(`${baseUrl}/${meal._id}`, {
                            method: 'DELETE'
                        });

                        mealDiv.remove();
                    })
                }

                editMealButtonElement.disabled = true;
            })
            .catch(error => console.log('Smth doesnt work'))
    }

    loadMealsFunc();
})

// Edit meal
editMealButtonElement.addEventListener('click', () => {
    const food = foodInputElement.value;
    const time = timeInputElement.value;
    const calories = caloriesInputElement.value;

    const mealId = formElement.getAttribute('data-id');

    fetch(`${baseUrl}/${mealId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            _id: mealId,
            food,
            calories,
            time,
        }),
    })
        .catch(err => {
            return;
        })

    editMealButtonElement.disabled = true;

    addMealButtonElement.disabled = false;

    formElement.removeAttribute('data-id');

    foodInputElement.value = '';
    timeInputElement.value = '';
    caloriesInputElement.value = '';

    loadMealsFunc();
})

addMealButtonElement.addEventListener('click', () => {
    const food = foodInputElement.value;
    const time = timeInputElement.value;
    const calories = caloriesInputElement.value;

    fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            food,
            time,
            calories,
        })
    })
        .catch(err => console.log('Add meal error'));

    foodInputElement.value = '';
    timeInputElement.value = '';
    caloriesInputElement.value = '';
})