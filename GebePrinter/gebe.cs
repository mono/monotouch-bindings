//
// gebe.cs: bindings to the GeBe Printing Framework
//
// http://www.oem-printer.com/catalog/C15C9292167072600BIoMu5449C8/page2693.html
//
// Author:
//   Miguel de Icaza (miguel@xamarin.com)
//
// Copyright 2011 Xamarin Inc
//
using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ExternalAccessory;

namespace MonoTouch.GebePrinter {
	[BaseType (typeof (NSObject))]
	interface GBPrinterManager {
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("debugEnabled")]
		bool DebugEnabled { get; set; }

		[Export ("sharedManager")]
		GBPrinterManager SharedManager { get; }

		[Export ("selectPrinterWithSerialNumber:")]
		bool SelectPrinter (string serialNumber);

		[Export ("selectPrinter:")]
		bool SelectPrinter (GBPrinterDevice printerDevice);

		[Export ("currentPrinter")]
		GBPrinterDevice CurrentPrinter { get; }

		[Export ("arePrintersAvailable")]
		bool ArePrintersAvailable { get; }

		[Export ("connectedPrinters")]
		GBPrinterDevice [] ConnectedPrinters { get; }

		[Export ("isActivePrinter:")]
		bool IsActivePrinter (GBPrinterDevice printer);

		[Export ("disconnectCurrentPrinter")]
		bool DisconnectCurrentPrinter ();

		[Export ("autoReconnectPreviousPrinter")]
		void AutoReconnectPreviousPrinter ();

		[Export ("reconnectPreviousPrinter")]
		bool ReconnectPreviousPrinter ();

		[Export ("errorStringForMessage:")]
		string ErrorStringForMessage (string msg);
	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject))]
	interface GBPrinterManagerDelegate {
		[Abstract]
		[Export ("errorFromManager:")]
		void Error (NSError error);

		[Export ("printerMessageReceived:")]
		void PrinterMessageReceived (string message);
	}

	[BaseType (typeof (NSObject))]
	interface GBPrinterDevice {
		[Export ("delegate")]
		NSObject WeakDelegate { get; set;  }

		[Export ("printer")]
		EAAccessory Printer { get; set; }

		[Export ("connectionID")]
		uint ConnectionID { get; }

		[Export ("name")]
		string Name { get; }

		[Export ("manufacturer")]
		string Manufacturer { get; }

		[Export ("modelNumber")]
		string ModelNumber { get; }

		[Export ("serialNumber")]
		string SerialNumber{ get; }

		[Export ("firmwareRevision")]
		string FirmwareRevision { get; }

		[Export ("hardwareRevision")]
		string HardwareRevision { get; }

		[Export ("printerWidth")]
		string PrinterWidth { get; }

		[Export ("printHEXData:error:")]
		void PrintHexDataerror (NSData inData, out NSError error);

		[Export ("printHEXData:appendToFile:error:")]
		void PrintHexDataappendToFileerror (NSData inData, NSUrl fileURL, out NSError error);

		[Export ("printASCIIString:copies:encoding:error:")]
		void PrintAsciiString (string aString, int inCopies, GBStringEncoding encoding, out NSError error);

		[Export ("printASCIIString:appendToFile:encoding:error:")]
		void PrintAsciiString (string aString, NSUrl appendTofileURL, GBStringEncoding encoding, out NSError error);

		[Export ("printASCIIString:copies:withFont:ofFontWidth:ofFontHeight:encoding:error:")]
		void PrintAsciiString (string aString, int inCopies, int withFont, uint fontWidth, uint fontHeight, GBStringEncoding encoding, out NSError error);

		[Export ("printASCIIString:appendToFile:withFont:ofFontWidth:ofFontHeight:encoding:error:")]
		void PrintAsciiString (string aString, NSUrl appendToFile, int withFont, int fontWidth, uint fontHeight, GBStringEncoding encoding, out NSError error);

		[Export ("printUIView:copies:size:encoding:dithered:error:")]
		void PrintUIView (UIView aView, int copies, SizeF aSize, GBGraphicEncoding encoding, bool dithered, out NSError error);

		[Export ("printUIView:appendToFile:size:encoding:dithered:error:")]
		void PrintUIView (UIView aView, NSUrl appendToFileURL, SizeF aSize, GBGraphicEncoding encoding, bool dithered, out NSError error);

		[Export ("printImage:copies:encoding:dithered:error:")]
		void PrintImage (UIImage source, int copies, GBGraphicEncoding encoding, bool dithered, out NSError error);

		[Export ("printImage:appendToFile:encoding:dithered:error:")]
		void PrintImage (UIImage source, NSUrl appendTofileURL, GBGraphicEncoding encoding, bool dithered, out NSError error);

		[Export ("printPRNFile:error:")]
		void PrintPrnFile (NSUrl fileURL, out NSError error);

		[Export ("paperFeedLines:error:")]
		void PaperFeedLines (int lines, out NSError error);

		[Export ("paperFeedBackLines:error:")]
		void PaperFeedBackLines (int lines, out NSError error);

		[Export ("requestErrorStateWithError:")]
		void RequestErrorState (out NSError error);

		[Export ("setPaperDensity:")]
		void SetPaperDensity (GBPaperDensity inDensity);

		[Export ("setTopPageSpacing:")]
		void SetTopPageSpacing (GBPageSpacing inSpacing);

		[Export ("setBottomPageSpacing:")]
		void SetBottomPageSpacing (GBPageSpacing inSpacing);

		[Export ("setPrinterCategory:")]
		void SetPrinterCategory (GBPrinterCategory inCategory);

		[Export ("setPowerInput:")]
		void SetPowerInput (GBPowerInput inInput);

		[Export ("setUsePowerManagement:")]
		void SetUsePowerManagement (bool inValue);

		[Export ("setUsePaperDensity:")]
		void SetUsePaperDensity (bool inValue);

		[Export ("setUseTopPageSpacing:")]
		void SetUseTopPageSpacing (bool inValue);

		[Export ("setUseBottomPageSpacing:")]
		void SetUseBottomPageSpacing (bool inValue);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface GBPrinterDeviceDelegate {
		[Abstract]
		[Export ("printerFinishedPrinting")]
		void PrinterFinishedPrinting ();
	}
}