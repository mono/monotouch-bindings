AlexTouch.MBProgressHUD
=======================

This is a MonoTouch Binding for Matej Bukovinski's MBProgressHUD Objective-C library

[![](http://dl.dropbox.com/u/378729/MBProgressHUD/1-thumb.png)](http://dl.dropbox.com/u/378729/MBProgressHUD/1.png)
[![](http://dl.dropbox.com/u/378729/MBProgressHUD/2-thumb.png)](http://dl.dropbox.com/u/378729/MBProgressHUD/2.png)
[![](http://dl.dropbox.com/u/378729/MBProgressHUD/3-thumb.png)](http://dl.dropbox.com/u/378729/MBProgressHUD/3.png)
[![](http://dl.dropbox.com/u/378729/MBProgressHUD/4-thumb.png)](http://dl.dropbox.com/u/378729/MBProgressHUD/4.png)
[![](http://dl.dropbox.com/u/378729/MBProgressHUD/5-thumb.png)](http://dl.dropbox.com/u/378729/MBProgressHUD/5.png)

see more on https://github.com/jdg/MBProgressHUD

Adding AlexTouch.MBProgressHUD to your project
==============================================

Just add AlexTouch.MBProgressHUD.dll to your project references in MonoDevelop.

1. [![](http://dl.dropbox.com/u/2058130/GitImages/AlexTrouchMbProgressHud/1.png)](http://dl.dropbox.com/u/2058130/GitImages/AlexTrouchMbProgressHud/1.png)
2. [![](http://dl.dropbox.com/u/2058130/GitImages/AlexTrouchMbProgressHud/2.png)](http://dl.dropbox.com/u/2058130/GitImages/AlexTrouchMbProgressHud/2.png) 
3. [![](http://dl.dropbox.com/u/2058130/GitImages/AlexTrouchMbProgressHud/3.png)](http://dl.dropbox.com/u/2058130/GitImages/AlexTrouchMbProgressHud/3.png)

4. Add using AlexTouch.MBProgressHUD; to your c# file

Usage
=====

You can create your hud using c# like this

			var hud = new MBProgressHUD(this.View);
			hud.Mode = MBProgressHUDMode.Determinate;
			hud.LabelText = "Loading...";
			hud.DetailsLabelText = "Some Description here";
			this.View.AddSubview(hud);
			hud.Show(true);
			
Also you can know when the hud was hidden using the following event

 			hud.WasHidden += delegate
			{
				Console.WriteLine("Hud hidden");
			};

--------------------
Alex Soto 
	@dalexsoto 
	https://github.com/dalexsoto/