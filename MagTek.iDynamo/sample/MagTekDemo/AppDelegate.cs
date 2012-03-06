// 
// AppDelegate.cs
//  
// Author: Jeffrey Stedfast <jeff@xamarin.com>
// 
// Copyright (c) 2012 Xamarin Inc.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 
using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using MagTek.iDynamo;

namespace MagTekDemo
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		const string gMagTekProtocolString = "com.magtek.idynamo";
		const MTSCRADeviceType gMagTekReader = MTSCRADeviceType.MagTekAudioReader;
		
		// class-level declarations
		MagTekDemoViewController viewController;
		MTSCRA mtSCRALib;
		UIWindow window;
		
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			mtSCRALib = new MTSCRA ();
			mtSCRALib.ListenForEvents (MTSCRATransactionEvent.OK | MTSCRATransactionEvent.Start | MTSCRATransactionEvent.Error);
			
			if (gMagTekReader == MTSCRADeviceType.MagTekIDynamo) {
				mtSCRALib.SetDeviceType (MTSCRADeviceType.MagTekIDynamo);
				mtSCRALib.SetDeviceProtocolString (gMagTekProtocolString);
			} else {
				mtSCRALib.SetDeviceType (MTSCRADeviceType.MagTekAudioReader);
			}
			
			mtSCRALib.OpenDevice ();
			
			viewController = new MagTekDemoViewController (mtSCRALib);
			window.RootViewController = viewController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
		
		public override void DidEnterBackground (UIApplication application)
		{
			mtSCRALib.CloseDevice ();
		}
		
		public override void WillEnterForeground (UIApplication application)
		{
			mtSCRALib.OpenDevice ();
		}
		
		public override void WillTerminate (UIApplication application)
		{
			mtSCRALib.CloseDevice ();
		}
	}
}
