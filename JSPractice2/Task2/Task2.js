
let customObj = {
    asds: 123,
    qwerty: () => "hello"
}

function getProperties(obj) {
    for (let key in obj){
        alert(key);
    }
}