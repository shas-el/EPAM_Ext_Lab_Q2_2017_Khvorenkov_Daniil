function splitString(string, separators) {
    var mainSeparator = separators[0];

    for (var i = 1; i < separators.length; i++) {
        var currSeparator = separators[i];
        string = string.split(currSeparator).join(mainSeparator);
    }

    return string.split(mainSeparator);
}

function removeByValue(array, item) {
    var index = 0;

    while (index != -1) {
        index = array.indexOf(item);
        if (index != -1) {
            array.splice(index, 1);
        }
    }

    return array;
}

function findDuplicatesWord(word) {
    var characters = word.split("");
    var duplicates = [];

    for (var i = 0; i < characters.length; i++) {
        if (i != characters.lastIndexOf(characters[i])) {
            duplicates.push(characters[i]);
        }
    }

    return duplicates;
}

function removeDuplicatesWord(word, duplicates) {
    characters = word.split("");
    var output = characters;

    for (var i = 0; i < characters.length; i++) {
        if (duplicates.includes(characters[i])) {
            output = removeByValue(output, characters[i])
        }
    }

    return output.join("");
}

function removeDuplicatesString(inputString) {
    var words = splitString(inputString, [" ", "    ", "?", "!", ";", ":", ",", "."]);
    var duplicates = [];

    for (var i = 0; i < words.length; i++) {
        duplicates = duplicates.concat(findDuplicatesWord(words[i]));
    }

    for (var i = 0; i < words.length; i++) {
        words[i] = removeDuplicatesWord(words[i], duplicates);
    }

    return words.join(" ");
}