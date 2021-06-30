function isVowel(char)
{
    if (char.length == 1)
    {
        return /[aeiou]/.test(char);
    }
}

function getCountVowel(str) {
    let count = 0;

    for (let i = 0; i < str.length; i++) {
        if (isVowel(str[i])){
            count++;
        }
    }

    return count;
}

let str1 = "aaaaagggggg";

console.log(getCountVowel(str1));