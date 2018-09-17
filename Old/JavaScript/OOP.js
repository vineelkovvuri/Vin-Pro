

// create a  shape class
// with properties color ( this is required or else color will be mapped to global namespace )
//
shape = function(color){
	this.color = color;
	console.log(this);
};


// create a  circle class
// with properties radius, circumference, area
// and inherits color property from shape using prototype
//
circle = function(radius){
	this.radius = radius;
	this.circurmference = 2*Math.PI*radius;
	this.area = function(){
		return Math.PI*radius*radius;
	};
	console.log(this);
};
circle.prototype = new shape("red");

var c1 = new circle(10);
console.log(c1.area());

// create a  circle class
// with properties length, bredth, area
// and inherits color property from shape using prototype
//
rectangle = function(len,bre){
	this.len = len;
	this.bre = bre;
	this.area = function(){
		return this.len*this.bre;
	};

	// this perimeter is declared as "var perimeter" which makes the function private
	// so it is not visible to the outside world
	//
	// This function can be invoked only from current class
	// inside perimeter function 'this' refers to global namespace
	// this is because the invocation of perimeter function is as shown
	// below
	//
	//   <noprefix>.perimeter(); // see the console.log(perimeter()) statement
	// 	 since there cannot be any prefix(because perimeter is a local variable)
	//	 'this' inside perimeter refers to global namespace
	//
	//	 so referring len and bre as this.len and this.bre is wrong
	var perimeter = function(){
		return 2 * (len + bre);
	};
	console.log(perimeter());
	console.log(this);
};

rectangle.prototype = new shape("blue");

var r1 = new rectangle(10,20);
console.log(r1.area());


