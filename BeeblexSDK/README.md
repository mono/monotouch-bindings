Beeblex-SDK
===========

The Beeblex SDK allows you to connect to Beeblex's services.

	// On FinishedLaunching ---
	BBXBeeblex.InitializeWithAPIKey("Your API Key Here");
	// ---
	
	...
	SKPaymentTransaction skTrans = //Your SKPaymentTransaction here

	BBXIAPTransaction bbxTransaction = new BBXIAPTransaction(skTrans);

	bbxTransaction.Validate((error)=> 
	{
		if (bbxTransaction.TransactionVerified) 
		{
			if (bbxTransaction.TransactionIsDuplicate) 
			{
				// The transaction is valid, but duplicate - it has already been
				// sent to Beeblex in the past.
			} 
			else 
			{
				// The transaction has been successfully validated
				// and is unique.
			}
				
		} 
		else 
		{
			// Check whether this is a validation error, or if something
			// went wrong with Beeblex.
					
			if (bbxTransaction.HasServerError) 
			{
				// The error was not caused by a problem with the data, but is
				// most likely due to some transient networking issues.
			} 
			else 
			{		
				// The transaction supplied to the validation service was not valid according to Apple.						
			}
		}
	});


For more information, visit [http://www.beeblex.com].
