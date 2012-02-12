//
//  ApiDefinition.cs
//
//
//  Version 1.0
//  Autor: 		Alex Soto.
//	Email: 		alex@alexsoto.me
//	Twitter:	@dalexsoto
//	
//	Revised on: Saturday 11/Feb/2012
//
// 	This code is distributed under the terms and conditions of the MIT license.
//
// 	Copyright (c) 2012 Alex Soto
//
// 	Permission is hereby granted, free of charge, to any person obtaining a copy
// 	of this software and associated documentation files (the "Software"), to deal
// 	in the Software without restriction, including without limitation the rights
// 	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// 	copies of the Software, and to permit persons to whom the Software is
// 	furnished to do so, subject to the following conditions:
//
// 	The above copyright notice and this permission notice shall be included in
// 	all copies or substantial portions of the Software.
//
// 	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// 	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// 	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// 	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// 	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// 	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// 	THE SOFTWARE.

using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace AlexTouch.MBProgressHUD
{	
	[BaseType (typeof (UIView),
	Delegates= new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (MBProgressHUDDelegate) })]
	interface MBProgressHUD 
	{
		[Static]
		[Export ("showHUDAddedTo:animated:")]
		MBProgressHUD ShowHUDAddedToanimated (UIView view, bool animated);
		
		[Static]
		[Export ("hideHUDForView:animated:")]
		bool HideHUDForViewanimated (UIView view, bool animated);
		
		[Export ("initWithWindow:")]
		IntPtr Constructor (UIWindow window);

		[Export ("initWithView:")]
		IntPtr Constructor (UIView view);
		
		[Export ("customView", ArgumentSemantic.Retain)]
		UIView CustomView { get; set; }
		
		[Export ("mode", ArgumentSemantic.Assign)]
		MBProgressHUDMode Mode { get; set; }
		
		[Export ("animationType", ArgumentSemantic.Assign)]
		MBProgressHUDAnimation AnimationType { get; set; }
		
		[Export ("labelText", ArgumentSemantic.Copy)]
		string LabelText { get; set; }
		
		[Export ("detailsLabelText", ArgumentSemantic.Copy)]
		string DetailsLabelText { get; set; }

		[Export ("opacity", ArgumentSemantic.Assign)]
		float Opacity { get; set;  }

		[Export ("xOffset", ArgumentSemantic.Assign)]
		float XOffset { get; set;  }

		[Export ("yOffset", ArgumentSemantic.Assign)]
		float YOffset { get; set;  }

		[Export ("margin", ArgumentSemantic.Assign)]
		float Margin { get; set;  }

		[Export ("dimBackground", ArgumentSemantic.Assign)]
		bool DimBackground { get; set;  }

		[Export ("graceTime", ArgumentSemantic.Assign)]
		float GraceTime { get; set;  }

		[Export ("minShowTime", ArgumentSemantic.Assign)]
		float MinShowTime { get; set;  }

		[Export ("taskInProgress", ArgumentSemantic.Assign)]
		bool TaskInProgress { get; set;  }

		[Export ("removeFromSuperViewOnHide", ArgumentSemantic.Assign)]
		bool RemoveFromSuperViewOnHide { get; set;  }
		
		[Export ("labelFont", ArgumentSemantic.Retain)]
		UIFont LabelFont { get; set; }
		
		[Export ("detailsLabelFont", ArgumentSemantic.Retain)]
		UIFont DetailsLabelFont { get; set; }
		
		[Export ("progress", ArgumentSemantic.Assign)]
		float Progress { get; set; }
		
		[Export ("minSize", ArgumentSemantic.Assign)]
		SizeF MinSize { get; set; }

		[Export ("square", ArgumentSemantic.Assign)]
		bool Square { [Bind ("isSquare")] get; set; }

		[Export ("show:")]
		void Show (bool animated);

		[Export ("hide:")]
		void Hide (bool animated);

		[Export ("hide:afterDelay:")]
		void HideafterDelay (bool animated, double delay);

		[Export ("showWhileExecuting:onTarget:withObject:animated:")]
		void ShowWhileExecutingonTargetwithObjectanimated (Selector method, NSObject target, NSObject Object, bool animated);
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
	
		[Wrap ("WeakDelegate")][NullAllowed]
		MBProgressHUDDelegate Delegate { get; set; }

	}

	[BaseType (typeof (NSObject))]
	interface MBProgressHUDDelegate 
	{
		[Export ("hudWasHidden:"), EventArgs("MBProgressHUDWasHidden")]
		void WasHidden (MBProgressHUD sender);
	}

	[BaseType (typeof (UIView))]
	interface MBRoundProgressView 
	{
		[Export ("progress", ArgumentSemantic.Assign)]
		float Progress { get; set; }

	}

}

