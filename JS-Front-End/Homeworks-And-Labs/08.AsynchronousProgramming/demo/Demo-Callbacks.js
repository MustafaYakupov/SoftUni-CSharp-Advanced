// Async programming with callback - old option, not used nowadays

console.log('start');

delayStart(() => {
    console.log('delayed start1')
}, 2000);

console.log('finish');

delayStart(() => {
    console.log('delayed start2')
}, 1000);

function delayStart(callback, time = 2000) {
    setTimeout(() => {
        callback();
    }, time );
}

