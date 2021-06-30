function combine(strings, del) {
    let result = "";

    for (let i = 0; i < strings.length ; i++){
        if (strings.length - 1 != i){
            result += strings[i] + del;
        }
    }

    return result;
}