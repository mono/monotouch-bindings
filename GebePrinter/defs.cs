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
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonoTouch.GebePrinter {

	public enum GBGraphicEncoding  {
	    Unencoded,
	    TiffEncoding,
	    DeltaRowEncoding,
	    OptimalEncoding
	} 
	
	public enum GBPrinterCategory 	{
		Low, High
	}
	
	public enum GBPowerInput {
	    Minimal,
	    Low,
	    Standard,
	    Medium,
	    High
	}
	
	public enum GBPageSpacing {
	    GB2,
	    GB5,
	    GB10,
	    GB15,
	    GB20,
	    GB25,
	    GB30
	}

	public enum GBPaperDensity {
	    DEnity20,
	    DEnity25,
	    DEnity30,
	    DEnity35,
	    DEnity40,
	    DEnity45,
	    DEnity50
	} 
	
	public enum GBStringEncoding {
		Default, UTF8
	} 

}