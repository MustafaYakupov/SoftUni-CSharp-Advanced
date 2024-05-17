function solve(inStockProducts, orderedProducts) {
    const store = {};

    for (let i = 0; i < inStockProducts.length; i += 2) {

        let productName = inStockProducts[i];
        let quantity = Number(inStockProducts[i + 1]);

        store[productName] = quantity;
    }

    for (let i = 0; i < orderedProducts.length; i += 2) {

        let productName = orderedProducts[i];
        let quantity = Number(orderedProducts[i + 1]);

        if (!store[productName]) {
            store[productName] = 0;
        }

        store[productName] += quantity;
    }

    for (const product in store) {
        console.log(`${product} -> ${store[product]}`);
    }
}

function fancySolve(inStockProducts, orderedProducts) {
    const getProducts = (list) => {
        const products = {};
        
        for (let i = 0; i < list.length; i += 2) {
            const product = list[i]
            const quantity = Number(list[i + 1]);
    
            if (!products[product]) {
                products[product] = 0;
            }

            products[product] += quantity;
        }

        return products;
    }

    // const store = getProducts(stock.concat(delivery));
    const store = getProducts([...inStockProducts, ...orderedProducts]);

    Object.keys(store)
        .forEach(product => console.log(`${product} -> ${store[product]}`))
}

solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
);

fancySolve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
);