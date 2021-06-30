function getSundays() {
    for (let year = 2014; year < 2051; year++){
        let date = new Date(year, 1, 1);

        if (date.getDay() === 0){
            console.log(year);
        }
    }
}

getSundays();