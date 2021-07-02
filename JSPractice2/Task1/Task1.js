
class Shape {

    constructor() {
    }

    getSquare() {

    }
}

//Prot

var Shape2 = function () {

}

Shape2.prototype.getSquare = function () {}

//

class Square extends Shape {

    constructor(side) {
        super();
        this.side = side;
    }

    getSquare() {
        return this.side * this.side;
    }
}

//Prot

function Square2(side) {
    this.side = side;

    this.getSquare = function () { return this.side * this.side; }
}

var shape2 = new Shape2();

Square2.prototype = shape2;

//

class Circle extends Shape {

    constructor(radius) {
        super();
        this.radius = radius;
    }

    getSquare() {
        return this.radius * this.radius * Math.PI;
    }
}

//Prot

function Circle2(side) {
    this.side = side;

    this.getSquare = function () { return this.radius * this.radius * Math.PI; }
}

Circle2.prototype = shape2;

//

let square = new Square(5);

alert(square.getSquare());