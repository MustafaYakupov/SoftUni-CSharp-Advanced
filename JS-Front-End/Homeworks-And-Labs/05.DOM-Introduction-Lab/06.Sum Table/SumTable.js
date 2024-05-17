function sumTable() {
    const tdCostElements = document.querySelectorAll('tr td:not(#sum):nth-child(2n)');
    const result = document.getElementById('sum');
    
    result.textContent = Array.from(tdCostElements)
    .reduce((acc, element) => acc + Number(element.textContent), 0);
}