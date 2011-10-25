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

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.ObjCRuntime;
using System;

using RedLaser;

namespace RedLaserSample
{
	public partial class RLSampleViewController : UIViewController
	{
		public RLSampleViewController (IntPtr handle) : base (handle) { }
		
		partial void scanPressed (MonoTouch.UIKit.UIBarButtonItem sender)
		{
			if (overlayController.ParentPicker == null)
			{
				BarcodePickerController picker = new BarcodePickerController ();
				
				// setup picker
				picker.Overlay = overlayController;
				picker.Delegate = new BarcodePickerDelegate (this);
				
				// Initialize with portrait mode as default
				picker.Orientation = UIImageOrientation.Up;
				
				// The active scanning region size is set in OverlayController.m
			}
			
			// Update barcode on/off settings
			overlayController.ParentPicker.ScanUPCE = enableUPCESwitch.On;
			overlayController.ParentPicker.ScanEAN8 = enableEAN8Switch.On;
			overlayController.ParentPicker.ScanEAN13 = enableEAN13Switch.On;
			overlayController.ParentPicker.ScanSTICKY = enableSTICKYSwitch.On;
			overlayController.ParentPicker.ScanQRCODE = enableQRCodeSwitch.On;
			overlayController.ParentPicker.ScanCODE128 = enableCode128Switch.On;
			overlayController.ParentPicker.ScanCODE39 = enableCode39Switch.On;
			//overlayController.parentPicker.ScanDataMatrix = enableDataMatrixSwitch.On;
			overlayController.ParentPicker.ScanITF = enableITFSwitch.On;
			
			// Data matrix decoding does not work very well so it is disabled for now
			overlayController.ParentPicker.ScanDATAMATRIX = false;
	
			// hide the status bar
			UIApplication.SharedApplication.StatusBarHidden = true;
			
			// Show the scanner overlay
			this.PresentModalViewController (overlayController.ParentPicker, true);
		}
		
		internal void BarcodeScannedResult (BarcodeResult result)
		{
			barcodeTextLabel.Text = result.BarcodeString;
			
			RLBarcodeType btype = (RLBarcodeType) result.BarcodeType;
			
			// update view with scanned barcode type
			if (btype == RLBarcodeType.EAN13)
			{
				// Use first digit to differentiate between EAN13 and UPCA
				if (result.BarcodeString[0] == '0')
				{
					barcodeTextLabel.Text = result.BarcodeString.Substring (1);
					typeLabel.Text = "UPC-A";
				}
				else
					typeLabel.Text = "EAN-13";
			}
			else if (btype == RLBarcodeType.EAN8) typeLabel.Text = "EAN-8";
			else if (btype == RLBarcodeType.UPCE) typeLabel.Text = "UPC-E";
			else if (btype == RLBarcodeType.QRCODE) typeLabel.Text = "QR Code";
			else if (btype == RLBarcodeType.Code128) typeLabel.Text = "Code 128";
			else if (btype == RLBarcodeType.Code39) typeLabel.Text = "Code 39";
			else if (btype == RLBarcodeType.DataMatrix) typeLabel.Text = "Data Matrix";
			else if (btype == RLBarcodeType.ITF) typeLabel.Text = "ITF";
			else if (btype == RLBarcodeType.STICKY) typeLabel.Text = "STICKYBITS";
		}
		
		private class BarcodePickerDelegate : RedLaser.BarcodePickerControllerDelegate
		{
			RLSampleViewController controller;
			
			public BarcodePickerDelegate (RLSampleViewController controller)
			{
				this.controller = controller;
			}
			
			// New method (as 3.0.0), returns multiple barcode scan results
			public override void ReturnResults (BarcodePickerController picker, NSSet results)
			{
				UIApplication.SharedApplication.StatusBarHidden = false;
				
				// Restore main screen (and restore title bar for 3.0)
				controller.DismissModalViewControllerAnimated (true);
				
				// Note that it is possible to get multiple results discovered at the same time.
				// Even if you return as soon as you see result barcodes, there could be more than one.
				var foundCode = (results.AnyObject as BarcodeResult);
				if (foundCode != null)
				{
					controller.BarcodeScannedResult (foundCode);
				}				
			}
		}
	}
}
