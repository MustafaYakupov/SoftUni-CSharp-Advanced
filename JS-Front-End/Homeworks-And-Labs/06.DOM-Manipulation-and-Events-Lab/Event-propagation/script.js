const orangeElement = document.querySelector('.orange');
const greenElement = document.querySelector('.green');
const yellowElement = document.querySelector('.yellow');

orangeElement.addEventListener('click', () => {
    console.log('orange clicked');
}, { capture: false })

greenElement.addEventListener('click', (event) => {
    event.stopPropagation();
    console.log('green clicked');
}, { capture: false })

yellowElement.addEventListener('click', () => {
    console.log('yellow clicked');
}, { capture: false })