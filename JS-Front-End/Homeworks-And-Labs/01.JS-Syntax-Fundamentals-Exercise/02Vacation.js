function solve(guestCount, guestType, dayType) {
    let singlePrice = 0;

    if (guestType === 'Students') {
        if (dayType === 'Friday') {
            singlePrice = 8.45;
        } else if (dayType === 'Saturday') {
            singlePrice = 9.80;
        } else if (dayType === 'Sunday') {
            singlePrice = 10.46;
        }

    } else if (guestType === 'Business') {
        if (dayType === 'Friday') {
            singlePrice = 10.90;
        } else if (dayType === 'Saturday') {
            singlePrice = 15.60;
        } else if (dayType === 'Sunday') {
            singlePrice = 16;
        }
    } else if (guestType === 'Regular') {
        if (dayType === 'Friday') {
            singlePrice = 15;
        } else if (dayType === 'Saturday') {
            singlePrice = 20;
        } else if (dayType === 'Sunday') {
            singlePrice = 22.50;
        }
    }

    let totalPrice = 0;

    if (guestType === 'Students' && guestCount >= 30) {
        totalPrice = guestCount * singlePrice * 0.85;
    } else if (guestType === 'Business' && guestCount >= 100) {
        guestCount -= 10;
        totalPrice = guestCount * singlePrice;
    } else if (guestType === 'Regular' && guestCount >= 10 && guestCount <= 20) {
        totalPrice = guestCount * singlePrice * 0.95;
    } else {
        totalPrice = guestCount * singlePrice;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

solve(30,
    "Students",
    "Sunday"
);

solve(40,
    "Regular",
    "Saturday"
);