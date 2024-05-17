console.log('Hello from an external javascript!');

const textInputElement = document.getElementById('uName');
console.log(textInputElement);

setTimeout(() => {
    textInputElement.value = 'ivaylo';
}, 2000)

const fancyInputElements = document.getElementsByClassName('fancy-input');
console.log(fancyInputElements);

// Get first input type text
const firstInputText = document.querySelector('.fancy-input[type=text]');
console.log(firstInputText);

// Get all input type text elements
const inputTextElements = document.querySelectorAll('.fancy-input[type=text]');
console.log(inputTextElements);

// NodeList vs HTMLCollection
console.log('NodeList vs HTMLCollection');
const contentStaticNodeList = document.querySelectorAll('#content > *');
const contentElement = document.querySelector('#content');
const contentLiveNodeList = contentElement.childNodes;   // Returns Node List with all nodes, not only html elements
const contentLiveHtmlCollection = contentElement.children;
console.log(contentStaticNodeList);
console.log(contentLiveNodeList);
console.log(contentLiveHtmlCollection);

// Remove element
setTimeout(() => {
    contentLiveHtmlCollection.item(0).remove();
}, 3000);

// Iterate collections
console.log('Iterate html collection');
for (const htmlElement of contentLiveHtmlCollection) {
    console.log(htmlElement);
}

console.log('Iterate node list');
for (const nodeElement of contentLiveNodeList) {
    console.log(nodeElement);
}

// Use foreach 
contentLiveNodeList.forEach(nodeElement => console.log(nodeElement))

// Convert htmlColletion to array
let htmlElementsArray = Array.from(contentLiveHtmlCollection);
// let htmlElementsArray = [...contentLiveHtmlCollection];   // spread operator equal to array from
console.log(htmlElementsArray);

// Get parent
console.log(firstInputText.parentElement);
console.log(firstInputText.parent);
