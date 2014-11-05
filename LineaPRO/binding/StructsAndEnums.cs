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

	public enum SupportedDeviceTypes {
		Linea = 0,
		Printer,
		Pinpad,
		ISerial
	}

	public enum DeviceConnectionType {
		Accessory,
		TcpIp,
		Bluetooth,
		BluetoothLE
	}

	public enum FeatEmv2Kernels {
		NEComPlus = 1,
		Datecs = 2
	}

	public enum PinEncryptionFormats {
		Iso0 = 0x04,
		Iso1 = 0x05,
		Iso3 = 0x0D
	}

	public enum IccTypes {
		Icc = 0,
		Pin
	}

	public enum RsaVerifyKey {
		Issuer = 0,
		Icc
	}

	public enum ScSlots {
		Main = 0,
		Sam
	}

	public enum FelicaSmarttagDrawModes {
		WhiteBackground = 0,
		BlackBackground,
		KeepBackground,
		UseLayout
	}

	public enum Features {
		/// <summary>
		/// Magnetic stripe reader
		/// </summary>
		Msr,

		/// <summary>
		/// Barcode reader
		/// </summary>
		Barcode,

		/// <summary>
		/// Bluetooth module
		/// </summary>
		Bluetooth,

		/// <summary>
		/// Using device's internal battery to charge the host battery, an external battery of sorts
		/// </summary>
		BatteryCharging,

		/// <summary>
		/// External serial port, used to connect to external devices
		/// </summary>
		ExternalSerialPort,

		/// <summary>
		/// RF cards reader (Mifare, ISO15, NFC, etc)
		/// </summary>
		RfReader,

		/// <summary>
		/// Printing support
		/// </summary>
		Printing,

		/// <summary>
		/// Smarcard module
		/// </summary>
		SmartCard,

		/// <summary>
		/// PIN entry capability
		/// </summary>
		PinEntry,

		/// <summary>
		/// EMV Level 2 Kernel
		/// </summary>
		EmvL2Kernel,

		/// <summary>
		/// Vibration supported
		/// </summary>
		Vibration,

		/// <summary>
		/// Program controllable LEDs
		/// </summary>
		Leds,

		/// <summary>
		/// External Speaker
		/// </summary>
		Speaker,

		/// <summary>
		/// iClass HID support
		/// </summary>
		Hid,
		Max
	}

	public enum FeatureSupported {
		Unsupported = 0,
		Supported
	}

	public enum FeatPrintProtocols {
		/// <summary>
		/// Exc/pos protocol, prn* commands
		/// </summary>
		EscPos = 1,

		/// <summary>
		/// Zebra ZPL protocol, zpl* commands
		/// </summary>
		Zpl
	}

	/// <summary>
	///		Magnetic Stripe reader types
	/// </summary>
	[Flags]
	public enum FeatMsrs {
		/// <summary>
		/// Unencrypted magnetic card reader with no possible data encryption
		/// </summary>
		Plain = 1,

		/// <summary>
		/// Unencrypted magnetic card reader, but featuring in-device data encryption
		/// </summary>
		PlainWithEncryption = 2,

		/// <summary>
		/// Encrypted magnetic head, no undencrypted data leaves the head
		/// </summary>
		Encrypted = 4,

		/// <summary>
		/// Voltage support
		/// </summary>
		Voltage = 8,

		/// <summary>
		/// Emulated encrypted magnetic head, no undencrypted data leaves the head
		/// </summary>
		EncryptedEmulation = 16
	}

	public enum FeatBarcodes {
		Opticon = 1,
		Code = 2,
		Newland = 3,
		Intermec = 4
	}

	public enum FeatBluetooths {
		Client = 1,
		Host = 2
	}

	public enum BatteryChips {
		None = 0,
		BQ27421
	}

	public enum BarcodePrintingTypes {
		Upca = 0,
		Upce,
		Ean13,
		Ean8,
		Code39,
		Itf,
		Codabar,
		Code93,
		Code128,
		Pdf417,
		Code128Auto,
		Ean128Auto
	}

	public enum Pdf417Size {
		W2_H4 = 0,
		W2_H9,
		W2_H15,
		W2_H20,
		W7_H4,
		W7_H9,
		W7_H15,
		W7_H20,
		W12_H4,
		W12_H9,
		W12_H15,
		W12_H20,
		W20_H4,
		W20_H9,
		W20_H15,
		W20_H20
	}

	public enum Pdf417Eccl {
		Eccl0 = 0,
		Eccl1,
		Eccl2,
		Eccl3,
		Eccl4,
		Eccl5,
		Eccl6,
		Eccl7,
		Eccl8,
		EcclAuto
	}

	public enum QRCodeEccl {
		Eccl7 = 0,
		Eccl15,
		Eccl25,
		Eccl30
	}

	public enum QRCodeSize {
		Size1 = 1,
		Size4 = 4,
		Size6 = 6,
		Size8 = 8,
		Size10 = 10,
		Size12 = 12,
		Size14 = 14
	}

	public enum BarcodeTextPosition {
		None = 0,
		Above,
		Below,
		Both
	}

	public enum Alignment {
		Left = 0,
		Center,
		Right,
		Justify
	}

	[Flags]
	public enum TableFlags {
		BordersHorizontal = 1,
		BordersVertical = 2,
		ColumnCompact = 4
	}

	public enum PageOrientation {
		HorizontalTopLeft = 0,
		VerticalBottomLeft,
		HorizontalBottomRight,
		VerticalTopRight
	}

	public enum PrintLogoSize {
		Normal = 0,
		DoubleWidth,
		DoubleHeight,
		DoubleWidthDoubleHeight
	}

	public enum Animations {
		All = -1,
		InsertCard = 0,
		RemoveCard,
		Busy,
		Drop,
		InsertSmartcard,
		InsertMagneticCard
	}

	public enum Languages {
		English = 0,
		Bulgarian,
		Espaniol,
		Russian,
		Romanian,
		French,
		Finish,
		Swedish
	}

	public enum Codepages {
		Latin1 = 0,
		Latin2,
		Latin3,
		Latin4,
		Cyrillic,
		Arabic,
		Greek,
		Hebrew,
		Latin5,
		Latin6
	}

	public enum PrinterCodepages {
		OemIbmPc = 437,
		OemGreek = 737,
		OemEstonianLithuanianLatvian = 775,
		OemLatin1 = 850,
		OemLatin2 = 852,
		OemCyrillic = 856,
		OemTurkish = 857,
		OemPortuguese = 860,
		OemHebrew = 862,
		OemPage866 = 866,
		AnsiCentralEasternEuropeanLatin = 1250,
		AsniCyrllic = 1251,
		AnsiWesternEuropeanLatin = 1252,
		AnsiGreek = 1253,
		AnsiTurkish = 1254,
		AnsiHebrew = 1255,
		AnsiBaltic = 1257
	}

	public enum Fonts {
		Font6X8 = 0,
		Font8X16,
		Font4X6
	}

	public enum ScreenColorModes {
		BlackAndWhite = 0
	}

	public enum AppSelectionMethods {
		Pse = 0,
		AidList
	}

	public enum AppMatchCriteria {
		Full = 1,
		PartialVisa,
		PartialEuroPay
	}

	public enum AuthorizationResults {
		Success = 1,
		Failure,
		PinRetryNotDone,
		UserCancellation
	}

	public enum BypassModes {
		CurrentMethodMode = 0,
		AllMethodsMode
	}

	public enum CertificateAcTypes {
		Aac = 0,
		TC,
		Arqc
	}

	public enum CardRiskTypes {
		Cdol1 = 1,
		Cdol2
	}

	public enum TagTypes {
		Binary = 0,
		Bcd,
		String
	}

	public enum PpEmvTags : uint {
		Pan = 0x5A,
		Cdol1 = 0x8C,
		Cdol2 = 0x8D,
		CvmList = 0x8E,
		Tdol = 0x97,
		IssuerPkCertificate = 0x90,
		SignedStaAppDat = 0x93,
		IssuerPkRemainder = 0x92,
		CaPkIndex = 0x8F,
		CardholderName = 0x5F20,
		ServiceCode = 0x5F30,
		CardholderNameExten = 0x9F0B,
		ExpiryDate = 0x5F24,
		EffectiveDate = 0x5F25,
		IssuerCountryCode = 0x5F28,
		IssuerCountryCodeA2 = 0x5F55,
		IssuerCountryCodeA3 = 0x5F56,
		PanSequenceNumber = 0x5F34,
		AppDiscretionDat = 0x9F05,
		AppUsageControl = 0x9F07,
		IccAppVersionNumber = 0x9F08,
		IssuerActionDefault = 0x9F0D,
		IssuerActionDenial = 0x9F0E,
		IssuerActionOnline = 0x9F0F,
		ApplRefCurrency = 0x9F3B,
		ApplCurrencyCode = 0x9F42,
		ApplRefCurrencyExp = 0x9F43,
		ApplCurrencyExp = 0x9f44,
		IccPkCertificate = 0x9f46,
		IccPinPkCertificate = 0x9f2d,
		IccPkExp = 0x9f47,
		IccPinPkExp = 0x9f2e,
		IccPkRemainder = 0x9f48,
		IccPinPkRemainder = 0x9f2f,
		StaDatAuthTagList = 0x9f4a,
		Ddol = 0x9f49,
		IssuerPkExp = 0x9f32,
		LowConsecOfflineLimit = 0x9f14,
		UppConsecOfflineLimit = 0x9f23,
		Track2DiscretionDat = 0x9f20,
		Track1DiscretionDat = 0x9f1f,
		Track2EquivalentData = 0x57,
		UnpredictableNumber = 0x9f37,
		AcquirerIdentifier = 0x9f01,
		AddTermCapabilities = 0x9f40,
		AmountAuthorisedBinary = 0x81,
		AmountAuthorisedNum = 0x9f02,
		AmountOtherBinary = 0x9f04,
		AmountOtherNum = 0x9f03,
		AmountRefCurr = 0x9f3a,
		AppCryptogram = 0x9f26,
		Afl = 0x94,
		IccAid = 0x4f,
		TermAid = 0x9f06,
		Aip = 0x82,
		AppLabel = 0x50,
		AppPreferredName = 0x9f12,
		AppPriorityIndicator = 0x87,
		Atc = 0x9f36,
		AppVersionNumber = 0x9f09,
		AuthCode = 0x89,
		AuthRespCode = 0x8a,
		ChVerifMethodResult = 0x9f34,
		CaPublicKeyIndex = 0x9f22,
		CryptInfoData = 0x9f27,
		DatAuthCode = 0x9f45,
		IccDynNumber = 0x9f4c,
		SerialNumber = 0x9f1e,
		IssuerAppDat = 0x9f10,
		IssuerAuthDat = 0x91,
		IssuerCodeIndex = 0x9f11,
		LanguagePreference = 0x5f2d,
		Latc = 0x9f13,
		MerchantCategoryCode = 0x9f15,
		MerchantIdentifier = 0x9f16,
		PinTryCounter = 0x9f17,
		PosEntryMode = 0x9f39,
		Pdol = 0x9f38,
		TerminalCapabilities = 0x9f33,
		TerminalCountryCode = 0x9f1a,
		TerminalFloorLimit = 0x9f1b,
		TerminalId = 0x9f1c,
		TerminalRiskDat = 0x9f1d,
		TerminalType = 0x9f35,
		Tvr = 0x95,
		TransactionCurrCode = 0x5f2a,
		TransactionCurrExp = 0x5f36,
		TransactionDate = 0x9a,
		TransactionRefCurrCode = 0x9f3c,
		TransactionRefCurrExp = 0x9f3d,
		TransactionSeqCounter = 0x9f41,
		Tsi = 0x9b,
		TransactionTime = 0x9f21,
		TransactionType = 0x9c,
		SignedDynAppDat = 0x9f4b,
		TcHashValue = 0x98,
		AccountType = 0x5f37,
		BankIdentifierCode = 0x5f54,
		Iban = 0x5f53,
		IssuerIdentificationNumber = 0x42,
		IssuerUrl = 0x5f50,
		LogEntry = 0x9f4d,
		TransactionCategoryCode = 0x9f53,
		RiskAmount = 0xdf02,
		TermActionDefault = 0xdf03,
		TermActionDenial = 0xdf04,
		TermActionOnline = 0xdf05,
		ThresholdValue = 0xdf07,
		TargetPercentage = 0xdf08,
		MaxTargetPercentage = 0xdf09,
		DefaultDdol = 0xdf15,
		DefaultTdol = 0xdf18,
		FloorLimitCurrency = 0xdf19,
		OffAuthDat = 0xdf23,
		IssuerScripts = 0xdf24,
		IssuerScriptsResult = 0xdf25
	}

	public enum PPEmvStatuses {
		Success = 0,
		ListAvailable = 1,
		ApplicationAvailable = 2,
		NoCommonApplication = 3,
		EasyEntryApp = 4,
		AmountNeeded = 5,
		ResultNeeded = 6,
		AuthCompleted = 7,
		AuthNotDone = 8,
		OfflinePinPlain = 9,
		OnlinePin = 10,
		OfflinePinCiphered = 11,
		BlockedApplication = 12,
		TransactionOnline = 13,
		TransactionApproved = 14,
		TransactionDenied = 15,
		CdaFailed = 16,
		InvalidPin = 17,
		InvalidPinLastAttempt = 18,
		Failure = 50,
		NoDataFound = 51,
		SystemError = 52,
		DataFormatError = 53,
		InvalidAtr = 54,
		AbortTransaction = 55,
		ApplicationNotFound = 56,
		InvalidApplication = 57,
		ErrorInApplication = 58,
		CardBlocked = 59,
		NoScriptLoaded = 61,
		InvalidTag = 62,
		InvalidLength = 63,
		InvalidHash = 64,
		InvalidKey = 65,
		NoMoreKeys = 66,
		ErrorAcProcess = 67,
		ErrorAcDenied = 68,
		NoCurrentMethod = 69,
		ResultAlreadyLoadedOrLastEmvkernelErrCode = 70,
		InvalidRemainder = 80,
		InvalidHeader = 81,
		InvalidFooter = 82,
		InvalidFormat = 83,
		InvalidCertificate = 84,
		InvalidSignature = 85,

	}

	public enum EncryptionAlgorithms {
		Aes256 = 0,
		EhEcc = 1,
		EhAes256 = 2,
		EhIdtech = 3,
		EhIdtechAes128 = 0x0b,
		EhMagtek = 4,
		EhMegtekAes126 = 0x0c,
		EhMagtekAes128 = 5,
		EhRsaOaep = 6,
		Ppad3desCbc = 7,
		EhVoltage = 8,
		EhAes128 = 9,
		PpadDukpt = 10
	}

	public enum EncryptionKeys {
		Authentication = 0x00,
		EhAes256Loading = 0x02,
		EhAes256Encryption1 = 0x01,
		EhAes256Encryption2 = 0x03,
		EhAes256Encryption3 = 0x04,
		EhAes128Encryption1 = 0x09,
		EhAes128Encryption2 = 0x0B,
		EhAes128Encryption3 = 0x0C,
		EhTmkAes = 0x10,
		EhDukptMaster1 = 0x20,
		EhDukptMaster2 = 0x21,
		EhDukptMaster3 = 0x22,
	}

	public enum ScriptTypes {
		Type71 = 0x71,
		Type72 = 0x72
	}

	public enum Channels {
		Prn = 1,
		Smartcard = 2,
		Gprs = 5,
		Encmsr = 14,
		Mifare = 16,
		Zpl = 50
	}
}

