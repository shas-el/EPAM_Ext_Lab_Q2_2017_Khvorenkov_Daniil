function processString(inputString) {
    inputString = inputString.split("=")[0] + "=";
    var result;
    result = getResult(inputString);

    if (isNaN(result)) {
        return inputString + result;
    } else {
        return inputString + result.toFixed(2);
    }
}

function getResult(inputString) {
    inputString = inputString.replace(/\s/g, "");

    if (checkExpression(inputString)) {
        return calculateResult(inputString);
    } else {
        return "error";
    }
}

function checkExpression(inputString) {
    var reg = /^(\d+(\.\d+)?)([-+*/](\d+(\.\d+)?))*=$/;
    return reg.test(inputString);
}

function calculateResult(inputString) {
    var firstToken;
    var secondToken;
    var operator;
    var tokens = [];
    var currentToken;
    var reg = /(\d+(\.\d+)?)|[-+*/=]/g;

    while ((currentToken = reg.exec(inputString)[0]) !== '=') {
        tokens.push(currentToken);
    }

    var i = 0;
    firstToken = tokens[i];
    i++;

    while (i !== tokens.length) {
        operator = tokens[i];
        i++;
        secondToken = tokens[i];
        i++;
        var f = new Function('return ' + firstToken + operator + secondToken);
        firstToken = eval(f());
    }

    return firstToken;
}