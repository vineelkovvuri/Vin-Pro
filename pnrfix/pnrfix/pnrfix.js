
// get the parent of actual text fields 
var parent = document.getElementsByName('lccp_pnrno1')[0].parentNode.parentNode;

// remove validation done by submit button in original implementaion(with onclick event)
var submitpnr = document.getElementsByName('submitpnr')[0];
submitpnr.removeAttribute('onclick');

// insert new text field and make the old two text fields as hidden 
parent.innerHTML = '<input name="pnr" id="pnr" type="text" size="10" maxlength="10" alt="Enter PNR" /><input name="lccp_pnrno1" id="lccp_pnrno1" type="hidden" size="3" maxlength="3" alt="PNR First Field" /><input name="lccp_pnrno2" id="lccp_pnrno2" type="hidden" size="7" maxlength="7" alt="PNR Second Field"/>';

// fire up on modifing text field content.....
function updateOldPnrFields(){
	var pnr = document.getElementById('pnr');
	if(pnr.value.length == 10){
		var firstpnr = document.getElementById('lccp_pnrno1');
		var secondpnr = document.getElementById('lccp_pnrno2');
		
		firstpnr.value = pnr.value.substring(0,3);
		secondpnr.value = pnr.value.substring(3);
	}
};

// attach listeners......
var pnr = document.getElementById('pnr');
pnr.addEventListener("change",updateOldPnrFields , false);
pnr.addEventListener("keyup",updateOldPnrFields , false);




