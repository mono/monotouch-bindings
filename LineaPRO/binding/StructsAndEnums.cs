using System;

namespace LineaProSdk
{
	public enum Parity
	{
		None = 0,
		Even = 1,
		Odd = 2
	}

	public enum DataBits
	{
		Seven = 1,
		Eight = 0
	}

	public enum StopBits
	{
		One = 0,
		Two = 1
	}

	public enum FlowControl
	{
		None = 0,
		RtsCts = 1,
		DtrDsr = 2,
		XonXoff = 3
	}

	public enum VoltageEncryption
	{
		Full = 0,
		Spe = 1
	}

	public enum MagCardEncryption
	{
		AlgAES256 = 0,
		AlgEhECC = 1,
		AlgEhAES256 = 2,
		AlgEhIdTech = 3,
		AlgEhIdTechAES128 = 0x0b,
		AlgEhMagtek = 4,
		AlgEhMagtekAES128 = 0x0c,
		AlgEh3DES = 5,
		AlgEhRSAOaep = 6,
		AlgPpad3DESCbc = 7,
		AlgEhVoltage = 8,
		AlgEhAES128 = 9,
		AlgPpadDukpt = 10
	}

	public enum SdkDebugSource
	{
		ConnectedDevice = 0,
		Sdk = 1
	}

	[Flags]
	public enum RFCardSupport
	{
		TypeA = 0x0001,
		TypeB = 0x0002,
		Felica = 0x0004,
		Nfc = 0x0008,
		Jewel = 0x0010,
		Iso15 = 0x0020,
		Stsri = 0x0040,
		PicoPassIso14 = 0x0080,
		PicoPassIso15 = 0x0100,
	}

	[Flags]
	public enum MsTrack
	{
		Tack1 = 0x01,
		Tack2 = 0x02,
		Tack3 = 0x04,
		TackJis = 0x20,
		All = Tack1 | Tack2 | Tack3 | TackJis
	}

	public enum RfChannel
	{
		Iso1443A = 0x01,
		Iso1443B = 0x02,
		Iso15693 = 0x03,
		Felica = 0x04,
		Stsri = 0x05,
		PicopassIso15 = 0x06
	}

	public enum EmvUiCodes 
	{
		StatusNotReady = 0x00,
		StatusIdle = 0x01,
		StatusReadyToRead = 0x02,
		StatusProcessing = 0x03,
		StatusCardReadSuccess = 0x04,
		StatusErrorProcessing = 0x05,
		NotWorking = 0x0000,
		Approved = 0x0003,
		Declined = 0x0007,
		PleaseEnterPin = 0x0009,
		ErrorProcessing = 0x000F,
		RemoveCard = 0x0010,
		Idle = 0x0014,
		PresentCard = 0x0015,
		Processing = 0x0016,
		CardReadOkRemove = 0x0017,
		TryOtherInterface = 0x0018,
		CardCollision = 0x0019,
		SignApproved = 0x001A,
		OnlineAuthorisation = 0x001B,
		TryOtherCard = 0x001C,
		InsertCard = 0x001D,
		ClearDisplay = 0x001E,
		SeePhone = 0x0020,
		PresentcCardAgain = 0x0021,
		Na = 0x00FF,
	}

	public enum TagsFormat
	{
		Datecs = 1
	}

	public enum KeyType
	{
		AES128_ECB = 0x04 >> 2,
		AES128_CBC = 0x08 >> 2,
		AES256_ECB = 0x0C >> 2,
		AES256_CBC = 0x10 >> 2,
		_3DES_ECB = 0x14 >> 2,
		_3DES_CBC = 0x18 >> 2,
		DUKPT_3DES_ECB = 0x1C >> 2,
		DUKPT_3DES_CBC = 0x20 >> 2,
		DUKPT_AES128_ECB = 0x24 >> 2,
		DUKPT_AES128_CBC = 0x28 >> 2
	}

	public enum Channel
	{
		Prn = 1,
		SmartCard = 2,
		Gprs = 5,
		Encmsr = 14,
		Mifare = 16,
		Zpl = 50
	}

	public enum SupportedDeviceTypes
	{
		Linea = 0,
		Printer,
		Pinpad,
		Iserial
	}

	public enum LogoMode
	{
		Normal = 0,
		DoubleWidth = 1,
		DoubleHeight = 2,
		DoubleWidthAndHeight = 3
	}

	public enum BarTextPosition
	{
		None = 0,
		Above = 1,
		Below = 2,
		Both = 3
	}

	public enum BarTextAlign
	{
		Left = 0,
		Center = 1,
		Right = 2,
		Justify = 3
	}

	public enum PageOrientation
	{
		HorizontalTopLeft = 0,
		VerticalBottomLeft = 1,
		HorizontalBottomRight = 2,
		VerticalTopRight = 3
	}

	[Flags]
	public enum Tableborders
	{
		Horizontal = 1,
		Vertical = 2,
		ColumnCompact = 4
	}

	public enum Barcodes
	{
		All = 0,
		Upc,
		Codabar,
		Code25Ni2of5,
		Code25I2of5,
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

	public enum BarcodesEx
	{
		All = 0,
		Upca,
		Codabar,
		Code25Ni2of5,
		Code25I2of5,
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
		Matrix2of5,
		Iata,
		KoreanPostal,
		Cca,
		Ccb,
		Ccc,
		Last
	}

	public enum PrintBarcodeType
	{
		Upca = 0,
		Upce = 1,
		Ean13 = 2,
		Ean8 = 3,
		Code39 = 4,
		Itf = 5,
		Codabar = 6,
		Code93 = 7,
		Code128 = 8,
		Pdf417 = 9,
		Code128Auto = 10,
		Ean128Auto = 11
	}

	public enum ConnStates
	{
		Disconnected = 0,
		Connecting,
		Connected
	}

	public enum DeviceConnectionType 
	{
		Accessory,
		Tcpip,
		Bluetooth,
		Bluetoothle
	}

	[Flags]
	public enum BluetoothFilter
	{
		All = -1,
		Printers = 1,
		Pinpads = 2,
		BarcodeScanners = 4
	}

	public enum ScanModes 
	{
		SingleScan = 0,
		MultiScan,
		MotionDetect,
		SingleScanRelease,
		MultiScanNoDuplicates
	}

	public enum ButtonStates 
	{
		Disabled = 0,
		Enabled
	}

	public enum MsModes 
	{
		ProcessedCardData = 0,
		RawCardData = 1,
		ProcessedTrack2Data = 3
	}

	public enum FeatEmv2Kernels 
	{
		Necomplus = 1,
		Datecs = 2
	}

	public enum BtModes 
	{
		Default = 0,
		Extended,
		Iso15424
	}

	public enum UpdatePhases
	{
		Init = 0,
		Erase,
		Write,
		Finish,
		Completing
	}

	public enum PinEncryptionFormats 
	{
		PinFormatIso0 = 4,
		PinFormatIso1 = 5,
		PinFormatIso3 = 13
	}

	public enum IccTypes 
	{
		Icc = 0,
		Pin
	}

	public enum RsaVerifyKey 
	{
		Ssuer = 0,
		Cc
	}

	public enum ScSlots 
	{
		Main = 0,
		Sam
	}

	public enum RfCardTypes
	{
		Unknown = 0,
		MifareMini,
		MifareClassic1k,
		MifareClassic4k,
		MifareUltralight,
		MifareUltralightC,
		Iso14443a,
		MifarePlus,
		Iso15693,
		MifareDesfire,
		Iso14443b,
		Felica,
		StSri,
		Payment,
		Picopass15693,
		Picopass14443b
	}

	public enum FelicaSmarttagBateryStatuses 
	{
		Normal1 = 0,
		Normal2,
		Low1,
		Low2
	}

	public enum FelicaSmartTagDrawModes 
	{
		WhiteBackground = 0,
		BlackBackground,
		KeepBackground,
		UseLayout
	}

	public enum Features 
	{
		Msr,
		Barcode,
		Bluetooth,
		BatteryCharging,
		ExternalSerialPort,
		RfReader,
		Printing,
		Smartcard,
		PinEntry,
		Emvl2Kernel,
		Vibration,
		Leds,
		Speaker,
		Hid,
		Sam,
		Max
	}

	public enum FeatureValue
	{
		Unsupported = 0,
		Supported = 1
	}

	public enum FeatPrintProtocols 
	{
		Escpos = 1,
		Zpl = 2
	}

	public enum FeatMsrs 
	{
		Plain = 1,
		PlainWithEncryption = 2,
		Encrypted = 4,
		Voltage = 8,
		EncryptedEmul = 16
	}

	public enum FeatBarcodes 
	{
		Opticon = 1,
		Code = 2,
		Newland = 3,
		Intermec = 4,
		Motorola = 5
	}

	public enum FeatBluetooths 
	{
		Client = 1,
		Host = 2
	}

	public enum BatteryChips 
	{
		None = 0,
		Bq27421
	}

	public enum Pdf417Size
	{
		W2H4 = 0,
		W2H9,
		W2H15,
		W2H20,
		W7H4,
		W7H9,
		W7H15,
		W7H20,
		W12H4,
		W12H9,
		W12H15,
		W12H20,
		W20H4,
		W20H9,
		W20H15,
		W20H20
	}

	public enum Pdf417Eccl 
	{
		Pdf417Eccl0 = 0,
		Pdf417Eccl1,
		Pdf417Eccl2,
		Pdf417Eccl3,
		Pdf417Eccl4,
		Pdf417Eccl5,
		Pdf417Eccl6,
		Pdf417Eccl7,
		Pdf417Eccl8,
		Auto
	}

	public enum QrcodeEccl 
	{
		QrcodeEccl7 = 0,
		QrcodeEccl15,
		QrcodeEccl25,
		QrcodeEccl30
	}

	public enum QrcodeSize 
	{
		QrcodeSize1 = 1,
		QrcodeSize4 = 4,
		QrcodeSize6 = 6,
		QrcodeSize8 = 8,
		QrcodeSize10 = 10,
		QrcodeSize12 = 12,
		QrcodeSize14 = 14
	}

	public enum Animations
	{
		All = -1,
		InsertCard = 0,
		RemoveCard,
		Busy,
		Drop,
		InsertSmartcard,
		InsertMagneticCard
	}

	public enum Languages 
	{
		English = 0,
		Bulgarian,
		Spanish,
		Russian,
		Romanian,
		French,
		Finish,
		Swedish
	}

	public enum Codepages 
	{
		CpIso88591Latin1 = 0,
		CpIso88592Latin2,
		CpIso88593Latin3,
		CpIso88594Latin4,
		CpIso88595Cyrillic,
		CpIso88596Arabic,
		CpIso88597Greek,
		CpIso88598Hebrew,
		CpIso88599Latin5,
		CpIso885910Latin6
	}

	public enum Fonts 
	{
		Font6x8 = 0,
		Font8x16,
		Font4x6
	}

	public enum ScreenColorModes 
	{
		ColorModeBw = 0
	}

	public enum AppSelectionMethods 
	{
		Pse = 0,
		Aidlist
	}

	public enum AppMatchCriterias
	{
		Full = 1,
		PartialVisa,
		PartialEuropay
	}

	public enum AuthResults 
	{
		ResultSuccess = 1,
		ResultFailure,
		FailPinEntryNotDone,
		FailUserCancellation
	}

	public enum BypassModes 
	{
		CurrentMethodMode = 0,
		AllMethodsMode
	}

	public enum CertificateAcTypes 
	{
		Aac = 0,
		Tc,
		Arqc
	}

	public enum CardRiskTypes 
	{
		Cdol1 = 1,
		Cdol2
	}

	public enum TagTypes 
	{
		Binary = 0,
		Bcd,
		String
	}
}

