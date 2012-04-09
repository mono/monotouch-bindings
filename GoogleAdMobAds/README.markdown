AlexTouch.GoogleAdMobAds
========================

This is a MonoTouch Binding for AdMob library, you just need to add the AlexTouch.GoogleAdMobAds.dll to you project references and add the following using statement to your source file.

			using AlexTouch.GoogleAdMobAds;

Also it uses the c# events =) so Have Fun!!
			
			var ad = new GADBannerView(new RectangleF(new PointF(0,0), GADBannerView.GAD_SIZE_300x250))
			{
				AdUnitID = "Use Your AdMob Id here",
				RootViewController = this //or your RootViewController	
			};
			
			ad.DidReceiveAd += delegate 
			{
				this.View.AddSubview(ad);
				Console.WriteLine("AD Received");
			};
			
			ad.DidFailToReceiveAdWithError += delegate(object sender, GADBannerViewDidFailWithErrorEventArgs e) {
				Console.WriteLine(e.Error);
			};
			
			ad.WillPresentScreen += delegate {
				Console.WriteLine("showing new screen");
			};
			
			ad.WillLeaveApplication += delegate {
				Console.WriteLine("I will leave application");
			};
			
			ad.WillDismissScreen += delegate {
				Console.WriteLine("Dismissing opened screen");
			};
			
			Console.Write("Requesting Ad");
			ad.LoadRequest(new GADRequest());


Also visit the official documentation of this API 
==================================================

http://code.google.com/mobile/ads/docs/ios/fundamentals.html
http://code.google.com/mobile/ads/docs/ios/intermediate.html
http://code.google.com/mobile/ads/docs/ios/advanced.html

---------
Alex Soto 
	@dalexsoto 
	https://github.com/dalexsoto/