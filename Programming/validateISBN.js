function validateISBN(isbn) {
	var i = 0;
	var charcount = 0;
	var checksum = 0;
	var validLength = 13;

	isbn = isbn || '';

	if (isbn.length > validLength)
		return false;

	for (i = 0; i < validLength - 1 && i < isbn.length; i++) {
		var char = isbn.charAt(i);
		if (((i == 2 || i == 6 || i == 10) && char !== '-') ||
			!(char >= '0' && char <= '9'))
			return false;
		checksum += (++charcount) * (char - '0');
	}

	if (i == validLength - 1) {
		checksum %= 11;
		if (checksum < 10)
			return isbn.charAt(i) == checksum;
		return isbn.charAt(i).toLowerCase() === 'x';
	}
	return false;
}
