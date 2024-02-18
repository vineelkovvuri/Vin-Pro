function drawCircle(){
		c.strokeStyle = "rgb( "+Math.floor(255*Math.random())+" , "+Math.floor(255*Math.random())+" , "+ Math.floor(255*Math.random())+" )";
		c.fillStyle = "rgb( "+Math.floor(255*Math.random())+" , "+Math.floor(255*Math.random())+" , "+ Math.floor(255*Math.random())+" )";
		c.beginPath();
		c.arc(width*Math.random(),height*Math.random(),100*Math.random(),0,Math.PI*2,false);
		c.fill();	
		c.stroke();
	}		

	setInterval(drawCircle,10);	
