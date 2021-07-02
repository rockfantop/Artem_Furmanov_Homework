
let customObj = {
    prop1: 123,
    prop2: 123,
    prop3: 123,
    prop4: 123,
    prop5: 123,
    prop6: 123,
    qwerty: () => "hello"
}

function getArrayOfProperties(obj) {
    let array = [];

    for (let key in obj){
        let tempArray = [];

        tempArray.push(key);
        tempArray.push(obj[key]);

        array.push(tempArray);
    }

    return array;
}

getArrayOfProperties(customObj);