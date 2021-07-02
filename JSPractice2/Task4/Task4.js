
class Validator {

    constructor() {
    }

    isValid() {
        console.log("Are not implement");
    }
}

class EmailValidator extends Validator {

    constructor() {
        super();
    }

    isValid(string) {
        const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(string).toLowerCase());
    }
}

class PhoneValidator extends Validator{

    constructor() {
        super();
    }

    isValid(string) {
        const re = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
        return re.test(String(string).toLowerCase());
    }
}

let string = "asd@gmail.com";

let validator = new EmailValidator();

alert(validator.isValid(string));