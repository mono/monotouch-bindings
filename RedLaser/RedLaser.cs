using System;
using MonoTouch.Foundation;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

/*
 * Updated 24/8/2010, Chris Branson, updated to RedLaser SDK 2.8.2
 *
*/

namespace RedLaser
{
	//#define kBarcodeTypeSTICKY 0x8
	//#define kBarcodeTypeEAN13 0x1
	//#define kBarcodeTypeUPCE 0x2
	//#define kBarcodeTypeEAN8 0x4
	
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
		
		[Export ("overlayDelegate", ArgumentSemantic.Retain)][NullAllowed]
		NSObject WeakOverlayDelegate { get; set; }
		
		[Wrap ("WeakOverlayDelegate")]
		RealtimeOverlayDelegate OverlayDelegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Wrap ("WeakDelegate")]
		BarcodePickerControllerDelegate Delegate { get; set; }
		
		[Export ("scanUPCE", ArgumentSemantic.Assign)]
		bool ScanUPCE { get; set; }
		
		[Export ("scanEAN8", ArgumentSemantic.Assign)]
		bool ScanEAN8 { get; set; }
		
		[Export ("scanEAN13", ArgumentSemantic.Assign)]
		bool ScanEAN13 { get; set; }
		
		[Export ("scanSTICKY", ArgumentSemantic.Assign)]
		bool ScanSTICKY { get; set; }
		
		[Export ("activeRegion", ArgumentSemantic.Assign)]
		System.Drawing.RectangleF ActiveRegion { get; set; }
		
		[Export ("orientation", ArgumentSemantic.Assign)]
		MonoTouch.UIKit.UIImageOrientation Orientation { get; set; }
		
		[Export ("cameraView", ArgumentSemantic.Assign)]
		MonoTouch.UIKit.UIView CameraView { get; set; }
		
	}
} 