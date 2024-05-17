function solve(input) {
    const schedule = {};

    for (const line of input) {
        const [day, name] = line.split(' ');

        if (schedule.hasOwnProperty([day])) {
            console.log(`Conflict on ${day}!`);
        } else {
            schedule[day] = name;
            console.log(`Scheduled for ${day}`);
        }
    }
}

solve(['Monday Peter',
'Wednesday Bill',
'Monday Tim',
'Friday Tim']
);