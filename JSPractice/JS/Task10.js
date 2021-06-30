function getMaxMultiple(array) {
    let max = 0;

    for (let i = 0; i < array.length - 1; i++){
        if (array[i] * array[i + 1] > max){
            max = array[i] * array[i + 1];
        }
    }

    return max;
}