/*
 * A MonoTouch implementation of RedLaser's SDK sample
 * 
 * Chris Branson, November 2009
 * Chris Branson, August 2010 - updated to support RedLaser SDK 2.8.2
 * Chris Branson, April 2011 - updated to support RedLaser SDK 3.0.0
 * 
 * This is the sample view controller and demonstrates initialisation of
 * the barcode picker controller, setting of properties and handling
 * of events.
 * 
 * Please refer to README.TXT for important information regarding this solution.
 * 
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.AVFoundation;
using MonoTouch.AudioToolbox;
using MonoTouch.CoreGraphics;
using MonoTouch.CoreAnimation;

using RedLaser;

namespace RedLaserSample
{
	public partial class OverlayController : CameraOverlayViewController
	{
		CAShapeLayer _rectLayer;
		bool _isSilent;
		
		public OverlayController (IntPtr handle) : base (handle) { }  
		
		internal void BeepOrVibrate ()
		{
			if (!_isSilent)
			{
				SystemSound.FromFile ("Sounds/beep.wav").PlayAlertSound ();
			}
		}
		
		partial void cancelPressed (MonoTouch.UIKit.UIBarButtonItem sender)
		{
			if (ParentPicker != null)
			{
				// Tell the picker we're done
				ParentPicker.DoneScanning ();
			}
		}
		
		partial void flashPressed (MonoTouch.UIKit.UIBarButtonItem sender)
		{
			if (flashButton.Style == UIBarButtonItemStyle.Bordered)
			{
				flashButton.Style = UIBarButtonItemStyle.Done;
				ParentPicker.FlashEnabled = true;
			}
			else
			{
				flashButton.Style = UIBarButtonItemStyle.Bordered;
				ParentPicker.FlashEnabled = false;
			}
		}
		
		// Optionally, you can change the active scanning region.
		// The region specified below is the default, and lines up
		// with the default overlay.  It is recommended to keep the
		// active region similar in size to the default region.
		// Additionally, the iPhone 3GS may not focus as well if
		// the region is too far away from center.
		//
		// In portrait mode only the top and bottom of this rectangle
		// is used. The x-position and width specified are ignored.

		void setPortraitLayout ()
		{
			// Set portrait
			ParentPicker.Orientation = UIImageOrientation.Up;
			
			// Set the active scanning region for portrait mode
			ParentPicker.ActiveRegion = new RectangleF (0, 100, 320, 250);
			
			// Activate the new settings
			ParentPicker.ResumeScanning ();
			
			// Animate the UI changes
			CGAffineTransform transform = CGAffineTransform.MakeRotation (0);
			//this.View.Transform = transform;
			UIView.BeginAnimations ("rotateToPortrait");
			//UIView.SetAnimationDelegate = this;
			UIView.SetAnimationCurve (UIViewAnimationCurve.Linear);
			UIView.SetAnimationDuration (0.5f);
			
			redlaserLogo.Transform = transform;
			
			setActiveRegionRect ();
			
			UIView.CommitAnimations (); // Animate!
		}
		
		void setLandscapeLayout ()
		{
			// Set landscape
			ParentPicker.Orientation = UIImageOrientation.Right;
			
			// Set the active scanning region for portrait mode
			ParentPicker.ActiveRegion = new RectangleF (100, 0, 120, 436);
			
			// Activate the new settings
			ParentPicker.ResumeScanning ();
			
			// Animate the UI changes
			CGAffineTransform transform = CGAffineTransform.MakeRotation (3.14159f/2.0f);
			//this.View.Transform = transform;
			UIView.BeginAnimations ("rotateToLandscape");
			//UIView.SetAnimationDelegate = this;
			UIView.SetAnimationCurve (UIViewAnimationCurve.Linear);
			UIView.SetAnimationDuration (0.5f);
			
			redlaserLogo.Transform = transform;
			
			setActiveRegionRect ();
			
			UIView.CommitAnimations (); // Animate!
		}
		
		partial void rotatePressed (MonoTouch.UIKit.UIBarButtonItem sender)
		{
			// Swap the orientation
			if (ParentPicker.Orientation == UIImageOrientation.Up)
			{
				setLandscapeLayout ();
			}
			else 
			{
				setPortraitLayout ();
			}
		}
		
		CGPath newPathInRect (RectangleF rect)
		{
			CGPath path = new CGPath ();
			path.AddRect (rect);
			return path;
		}
		
		void setActiveRegionRect ()
		{
			_rectLayer.Frame = new RectangleF (ParentPicker.ActiveRegion.X,
			                                   ParentPicker.ActiveRegion.Y,
			                                   ParentPicker.ActiveRegion.Width,
			                                   ParentPicker.ActiveRegion.Height);
			
			CGPath path = newPathInRect (_rectLayer.Bounds);
			_rectLayer.Path = path;
			_rectLayer.SetNeedsLayout ();
		}
		
		internal void SetArrows (bool inRange, bool animated)
		{
			if (inRange)
				_rectLayer.StrokeColor = UIColor.Green.CGColor;
			else
				_rectLayer.StrokeColor = UIColor.White.CGColor;
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Create active region rectangle
			_rectLayer = new CAShapeLayer ();
			_rectLayer.FillColor = UIColor.FromRGBA (1.0f, 0.0f, 0.0f, 0.2f).CGColor;
			_rectLayer.StrokeColor = UIColor.White.CGColor;
			_rectLayer.LineWidth = 3;
			_rectLayer.AnchorPoint = PointF.Empty;
			this.View.Layer.AddSublayer (_rectLayer);
			
			// get is device silent flag
			_isSilent = NSUserDefaults.StandardUserDefaults.BoolForKey("silent_pref");
			
			// set camera view
			//parentPicker.CameraView = cameraView;
		}
		
		public override void ViewWillAppear (bool animated)
		{
			if (ParentPicker.Orientation == UIImageOrientation.Up)
				setPortraitLayout ();
			else
				setLandscapeLayout ();
			
			if (!ParentPicker.FlashEnabled)
			{
				flashButton.Enabled = false;
			}
			else
			{
				flashButton.Enabled = true;
				flashButton.Style = UIBarButtonItemStyle.Bordered;
			}
			
			textCue.Text = "";
		}
		
		// In the status dictionary:
	
		// "FoundBarcodes" key is a NSSet of all discovered barcodes this scan session
		// "NewFoundBarcodes" is a NSSet of barcodes discovered in the most recent pass.
			// When a barcode is found, it is added to both sets. The NewFoundBarcodes
			// set is cleaned out each pass.
		
		// "Guidance" can be used to help guide the user through the process of discovering
		// a long barcode in sections. Currently only works for Code 39.
		
		// "Valid" is TRUE once there are valid barcode results.
		// "InRange" is TRUE if there's currently a barcode detected the viewfinder. The barcode
		//		may not have been decoded yet.
		public override void StatusUpdated (BarcodePickerController picker, NSDictionary status)
		{
			NSNumber isValid = (NSNumber) status.ObjectForKey (new NSString ("Valid"));
			NSNumber inRange = (NSNumber) status.ObjectForKey (new NSString ("InRange"));
			
			SetArrows (inRange.BoolValue, true);
			
			if (isValid.BoolValue)
			{
				BeepOrVibrate ();
				ParentPicker.DoneScanning ();
			}
			
			NSNumber guidanceLevel = (NSNumber) status.ObjectForKey (new NSString ("Guidance"));
			if (guidanceLevel != null)
			{
				if (guidanceLevel.IntValue == 1)
				{
					textCue.Text = "Try moving the camera close to each part of the barcode";
				}
				else if (guidanceLevel.IntValue == 2)
				{
					textCue.Text = (NSString) status.ObjectForKey (new NSString ("PartialBarcode"));
				}
				else 
				{
					textCue.Text = "";
				}
			}
		}
	}
}
