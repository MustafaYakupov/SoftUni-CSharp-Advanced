// Function as return value
function loggerBuilder(date) {
    return function(text) {
        console.log(`${date}: ${text}`);
    }
}

const logger = loggerBuilder('05.03.2024');

logger('Hello Pesho');
logger('Hello Gosho');
logger('Hello Stamat');