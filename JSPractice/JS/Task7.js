function isFirstOrLastIs1(array) {
    if (array.length > 1){
        if (array[0] == 1 || array[-1] == 1){
            return true;
        }
        else {
            return false;
        }
    }
    else {
        if (array[0] == 1){
            return true;
        }
        else {
            return false;
        }
    }
}

let array1 = [1, 2, 3];

console.log(isFirstOrLastIs1(array1));