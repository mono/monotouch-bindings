/*
 * Updated 24/8/2010, Chris Branson, updated to RedLaser SDK 2.8.2
 * 
 * Updated 16/2/2011, Chris Branson, updated to RedLaser SDK 2.9.2
 *
 * Updated 19/4/2011, Chris Branson, updated to RedLaser SDK 3.0.0
 * 
 * This is the public API for the RedLaser SDK.
 *
*/

public enum RLBarcodeType {
	EAN13 = 0x1,
	UPCE = 0x2,
	EAN8 = 0x4,
	STICKY = 0x8,
	QRCODE = 0x10,
	Code128 = 0x20,
	Code39 = 0x40,
	DataMatrix = 0x80,
	ITF = 0x100,
	EAN5 = 0x200,
	EAN2 = 0x400
}