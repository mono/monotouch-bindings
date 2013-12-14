using System;

namespace LineaProSdk
{
	public enum Barcodes {
		All = 0,
		Upc,
		Codabar,
		Code25NI2OF5,
		Code25I2OF5,
		Code39,
		Code93,
		Code128,
		Code11,
		Cpcbinary,
		Dun14,
		Ean2,
		Ean5,
		Ean8,
		Ean13,
		Ean128,
		Gs1databar,
		Itf14,
		LatentImage,
		Pharmacode,
		Planet,
		Postnet,
		IntelligentMail,
		Msi,
		Postbar,
		Rm4scc,
		Telepen,
		Plessey,
		Pdf417,
		Micropdf417,
		Datamatrix,
		Aztek,
		Qrcode,
		Maxicode,
		Last
	}

	public enum BarcodesEx {
		All = 0,
		Upca,
		Codabar,
		Code25NI2Of5,
		Code25I2Of5,
		Code39,
		Code93,
		Code128,
		Code11,
		Cpcbinary,
		Dun14,
		Ean2,
		Ean5,
		Ean8,
		Ean13,
		Ean128,
		Gs1databar,
		Itf14,
		LatentImage,
		Pharmacode,
		Planet,
		Postnet,
		IntelligentMail,
		MsiPlessey,
		Postbar,
		Rm4scc,
		Telepen,
		UkPlessey,
		Pdf417,
		Micropdf417,
		Datamatrix,
		Aztek,
		Qrcode,
		Maxicode,
		Reserved1,
		Reserved2,
		Reserved3,
		Reserved4,
		Reserved5,
		Upca2,
		Upca5,
		Upce,
		Upce2,
		Upce5,
		Ean132,
		Ean135,
		Ean82,
		Ean85,
		Code39Full,
		ItaPharma,
		CodabarAbc,
		CodabarCx,
		Scode,
		Matrix2OF5,
		Iata,
		KoreanPostal,
		Cca,
		Ccb,
		Ccc,
		Last
	}

	public enum ConnStates {
		Disconnected = 0,
		Connecting,
		Connected
	}

	public enum BluetoothFilter {
		All = -1,
		Printers = 1,
		Pinpads = 2,
		BarcodeScanners = 4
	}

	public enum ScanModes {
		SingleScan = 0,
		MultiScan,
		MotionDetect,
		SingleScanRelease,
		MultiScanNoDuplicates
	}

	public enum ButtonStates {
		Disabled = 0,
		Enabled
	}

	public enum MsModes {
		ProcessedCardData = 0,
		RawCardData = 1,
		Track2Data = 3
	}

	public enum BtModes {
		ArcodeTypeDefault = 0,
		ArcodeTypeExtended,
		ArcodeTypeIso15424
	}

	public enum UpdatePhases {
		Init = 0,
		Erase,
		Write,
		Finish,
		Completing
	}

	public enum RfCardTypes {
		Unknown = 0,
		MifareMini,
		MifareClassic_1k,
		MifareClassic_4k,
		MifareUltralight,
		MifareUltralight_c,
		Iso14443a,
		MifarePlus,
		Iso15693,
		MifareDesfire,
		Iso14443b,
		Felica,
		StSri,
		Payment,
		Picopass15693,
		Picopass14443B
	}

	public enum FelicaSmarttagBateryStatuses {
		TeryNormal1 = 0,
		TeryNormal2,
		TeryLow1,
		TeryLow2
	}
}

