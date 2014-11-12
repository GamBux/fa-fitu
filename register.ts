function check_registration_form() {
	//Jak przejdzie ścieżkę zdrowia to ok
	var valid : boolean = true;

	// getting username and email from text boxes
	var userString : string = (<HTMLInputElement>document.getElementById('username_text_input')).value;
	var emailString : string = (<HTMLInputElement>document.getElementById('email_text_input')).value;

	//handling of username
	valid = valid && userValidate(userString);

	if(valid == false){
		document.getElementById('username_message').innerHTML = '<p class="error">username is too short 6 characters required!!!</p>';
		return false;
	}
	else document.getElementById('username_message').innerHTML = '<p class="ok">OK</p>';

	//handling of email
	valid = valid && emailValidate(emailString);

	if(valid == false){
		document.getElementById('email_message').innerHTML = '<p class="error">email is not valid!!!</p>';
		return false;
	}
	else document.getElementById('email_message').innerHTML = '<p class="ok">OK</p>';

	///////////////////
	//If everything is fine we return
	//
	
	
	return false;
}


function userValidate(userString : string) : boolean{
	if(userString.length < 6) return false;
	return true;
}

function emailValidate(emailString : string) : boolean{

	// From http://www.whatwg.org/specs/web-apps/current-work/multipage/states-of-the-type-attribute.html#e-mail-state-%28type=email%29
    var emailRegex = /^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/;
	return emailRegex.test(emailString);
}