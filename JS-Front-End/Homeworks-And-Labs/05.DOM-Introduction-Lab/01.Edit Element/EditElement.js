function editElement(element, match, replacer) {
    // This doesn't work in judge
    // element.textContent = element.textContent.replaceAll(match, replacer);

    while (element.textContent.includes(match)) {
        element.textContent = element.textContent.replace(match, replacer);
    }
}