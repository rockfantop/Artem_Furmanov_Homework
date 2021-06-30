window.onload = loadHandler;

let numb = Math.floor(Math.random() * 20) + 1;

function loadHandler() {
    let button = document.getElementById("answerSubmit");
    button.onclick = guessNumber;
}

function guessNumber() {
    let value = document.getElementById("answer").value;

    if (!Number.isInteger(parseInt(value))){
        alert("Wrong Input");
        return;
    }

    if (value == numb){
        alert("You are won!");
    }
    else if (value > numb){
        alert("Guessed number is lower");
    }
    else {
        alert("Guessed number is bigger");
    }
}