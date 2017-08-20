

// Function invocation pattern

var obj = {
	firstname:"Vineel",
};


obj.method1 = function(){
	console.log(this);
};

obj.method2 = function(){
	var helper = function(){
		console.log(this);
	};
	helper();
};

obj.method1();
obj.method2();



