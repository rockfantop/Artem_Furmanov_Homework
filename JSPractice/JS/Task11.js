function removeDuplicates(array) {
    return array.filter((value, index) => array.indexOf(value) === index);
}