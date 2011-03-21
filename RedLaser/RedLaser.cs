using System;
using MonoTouch.Foundation;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

/*
 * Updated 24/8/2010, Chris Branson, updated to RedLaser SDK 2.8.2
 * 
 * Updated 16/2/2010, Chris Branson, updated to RedLaser SDK 2.9.2
 *
*/

namespace RedLaser
{
	[BaseType (typeof (NSObject))]
	[Model]
	interface BarcodePickerControllerDelegate {
		[Export ("barcodePickerController:didScanBarcode:withInfo:")]
		void BarcodeScanned (BarcodePickerController picker, string ean, NSDictionary info);
		
		[Export ("barcodePickerControllerDidCancel:")]
		void Cancelled (BarcodePickerController picker);
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface RealtimeOverlayDelegate{
		[Export ("barcodePickerController:statusUpdated:")]
		void StatusUpdated (BarcodePickerController picker, NSDictionary status);
		
		[Export ("barcodePickerControllerDidAppear:")]
		void PickerAppeared (BarcodePickerController controller);
		
		[Export ("barcodePickerControllerWillAppear:")]
		void PickerAppearing (BarcodePickerController controller);
	}
	
	[BaseType (typeof (UIViewController))]
	interface BarcodePickerController {
		[Export ("resumeScanning")]
		void ResumeScanning ();
		
		[Export ("stopScanning")]
		void StopScanning ();
		
		[Export ("returnBarcode:withInfo:")]
		void ReturnBarcode (string ean, NSDictionary info);
		
		[Export ("cancel")]
		void Cancel ();
		
		[Export ("turnFlash:")]
		void TurnFlash (bool enabled);
		
		[Export ("overlayDelegate", ArgumentSemantic.Retain)][NullAllowed]
		NSObject WeakOverlayDelegate { get; set; }
		
		[Wrap ("WeakOverlayDelegate")]
		RealtimeOverlayDelegate OverlayDelegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Wrap ("WeakDelegate")]
		BarcodePickerControllerDelegate Delegate { get; set; }
		
		[Export ("hasFlash", ArgumentSemantic.Assign)]
		bool HasFlash { get; set; }
		
		[Export ("scanUPCE", ArgumentSemantic.Assign)]
		bool ScanUPCE { get; set; }
		
		[Export ("scanEAN8", ArgumentSemantic.Assign)]
		bool ScanEAN8 { get; set; }
		
		[Export ("scanEAN13", ArgumentSemantic.Assign)]
		bool ScanEAN13 { get; set; }
		
		[Export ("scanSTICKY", ArgumentSemantic.Assign)]
		bool ScanSTICKY { get; set; }
		
		[Export ("scanQRCODE", ArgumentSemantic.Assign)]
		bool ScanQRCODE { get; set; }
		
		[Export ("scanCODE128", ArgumentSemantic.Assign)]
		bool ScanCODE128 { get; set; }
		
		[Export ("scanCODE39", ArgumentSemantic.Assign)]
		bool ScanCODE39 { get; set; }
		
		[Export ("scanDATAMATRIX", ArgumentSemantic.Assign)]
		bool ScanDATAMATRIX { get; set; }
		
		[Export ("scanITF", ArgumentSemantic.Assign)]
		bool ScanITF { get; set; }
		
		[Export ("activeRegion", ArgumentSemantic.Assign)]
		System.Drawing.RectangleF ActiveRegion { get; set; }
		
		[Export ("lastRect", ArgumentSemantic.Assign)]
		System.Drawing.RectangleF LastRect { get; set; }
		
		[Export ("orientation", ArgumentSemantic.Assign)]
		MonoTouch.UIKit.UIImageOrientation Orientation { get; set; }
		
		[Export ("cameraView", ArgumentSemantic.Assign)]
		MonoTouch.UIKit.UIView CameraView { get; set; }
		
	}
}