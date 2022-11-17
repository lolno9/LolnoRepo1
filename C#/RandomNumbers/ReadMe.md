#V0.0.1
Created class RandomNumbers that uses System.Security.Cryptography.RandomNumberGenerator
Created methods
	BreakIntoBytes
		Recieve a number and split it into his byte representation (using 8 bits "Int64")
	GetInt16/32/64
		Recieve an array byte[8] and convert it into his Int16/32/64 representation
	ToString (Override)
		Returns a string: "Byte: " + Next() + " \tInt64: " + v + " \t" + "Bytes forming the int" foreach value un our array of numbers
	Next
		Call this method to retrieve 1 by 1 the numbers in our array
	ShowContent
		Methods to show the contents of the array
	GetLongs
		Returns an array of Int64 based on a recieved byte[] array
	FillNumbers
		Fill the array with random numbers

//TODO
Group bytes in packs of 8 and pass them to the GetInt methods.