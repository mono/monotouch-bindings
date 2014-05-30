# Lookback binding for Xamarin.iOS
_version 0.6.3 (May 13, 2014)_

## Instructions to integrate Lookback into your iOS project:

1. sign-up for [Lookback](http://www.lookback.io/) at their site. 
2. download and expand the Lookback SDK to the /Lookback folder. 
3. run **make** from the /binding folder.
4. if building an ad-hoc release, add a reference to LookbackSDK.dll in the /binding/HD folder; if building an app store release, use the .dll in the /binding/Safe folder.
5. Copy resources from the binding/Lookback-Resources folder to your project.
6. Ensure that the storyboard file's build action is set to InterfaceDefinition, and that the image files are set as bundle resources.
7. Add the InitializeLookback() function below to your project to enable within your application, or roll your own:

	private void InitializeLookback ()
	try {
		LookbackSDK.Lookback.SetupWithAppToken("<your Lookback token>");
		LookbackSDK.Lookback lb = LookbackSDK.Lookback.lookback;
		lb.ShakeToRecord = true;
		lb.UserIdentifier = "<user's identifier>";

		//note: you can change these defaults to meet your needs.
		NSUserDefaults.StandardUserDefaults.SetBool (true, "com.thirdcog.lookback.preview.enabled");
		NSUserDefaults.StandardUserDefaults.SetBool (true, "com.thirdcog.lookback.autosplit");

		//this delegate returns a url for the Lookback session.
		NSNotificationCenter.DefaultCenter.AddObserver ("com.thirdcog.lookback.notification.startedUploading", delegate (NSNotification n) 
		{
		NSUrl url =		(NSUrl)n.UserInfo.ObjectForKey("com.thirdcog.lookback.notification.startedUploading.destinationURL".ToNSString());
		UIPasteboard.General.Url = url;});}

	catch { 
		Console.WriteLine ("Unable to initialize Lookback.");
			}
		}
	}

	//Extension method to support Lookback initialization.
	public static class ExtensionMethods
	{
		public static NSString ToNSString(this String str)
		{
			return new NSString(str);
		}
	}

## Building the LookbackSample application
1. follow steps 1-3 listed above.
2. run **make** from the /samples folder.