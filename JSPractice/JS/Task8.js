function getLastElementsOfArray(array, n) {
    let newArr = [];

    if (n === undefined){
        newArr.push(array[array.length - 1]);
        return newArr;
    }
    for (let i = array.length - 1; i > 0 && n > 0; n--, i--){
        newArr.push(array[i]);
    }

    return newArr;
}

let arr = [ 7, 9, 0, -2];

console.log(getLastElementsOfArray(arr));