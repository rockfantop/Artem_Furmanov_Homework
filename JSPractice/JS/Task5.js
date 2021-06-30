function addRuToString(str) {
    if (str === "" || (str[0] === 'R' && str[1] === 'u')){
        return str;
    }
    else {
        str = "Ru" + str;
        return str;
    }
}

let str1 = "asdfsadfasdf";
let str2 = "Ruasdfsadfasdf";
let str3 = "";

console.log(addRuToString(str1));
console.log(addRuToString(str2));
console.log(addRuToString(str3));