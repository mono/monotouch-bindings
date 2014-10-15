using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace LineaProSdk
{
	[BaseType (typeof (NSObject))]
	interface DTRFCardInfo {

		[Export ("type")]
		int Type { get; set; }

		[Export ("typeStr", ArgumentSemantic.Copy)]
		string TypeStr { get; set; }

		[Export ("UID", ArgumentSemantic.Copy)]
		NSData UID { get; set; }

		[Export ("ATQA")]
		int ATQA { get; set; }

		[Export ("SAK")]
		int SAK { get; set; }

		[Export ("AFI")]
		int AFI { get; set; }

		[Export ("DSFID")]
		int DSFID { get; set; }

		[Export ("blockSize")]
		int BlockSize { get; set; }

		[Export ("nBlocks")]
		int NBlocks { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface DTEMVConfigurationInfo {

		[Export ("version", ArgumentSemantic.Assign)]
		int Version { get; set; }

		[Export ("size", ArgumentSemantic.Assign)]
		int Size { get; set; }

	}

	[BaseType (typeof (NSObject))]
	[Protocol]
	[Model]
	interface LineaDelegate {

		[Export ("connectionState:")]
		void ConnectionState (ConnStates state);

		[Export ("lineaButtonPressed:")]
		void ButtonPressed (int which);

		[Export ("lineaButtonReleased:")]
		void ButtonReleased (int which);

		[Export ("barcodeData:type:")]
		void BarcodeData (string barcode, int type);

		[Export ("barcodeData:isotype:")]
		void BarcodeData (string barcode, string isotype);

		[Export ("barcodeNSData:type:")]
		void BarcodeData (NSData barcode, int type);

		[Export ("barcodeNSData:isotype:")]
		void BarcodeData (NSData barcode, string isotype);

		[Export ("magneticCardData:track2:track3:")]
		void MagneticCardData (string track1, string track2, string track3);

		[Export ("magneticCardRawData:")]
		void MagneticCardRawData (NSData tracks);

		[Export ("magneticCardEncryptedData:data:")]
		void MagneticCardEncryptedData (int encryption, NSData data);

		[Export ("magneticCardEncryptedData:tracks:data:")]
		void MagneticCardEncryptedData (int encryption, int tracks, NSData data);

		[Export ("magneticCardEncryptedData:tracks:data:track1masked:track2masked:track3:")]
		void MagneticCardEncryptedData (int encryption, int tracks, NSData data, string track1masked, string track2masked, string track3);

		[Export ("magneticCardEncryptedRawData:data:")]
		void MagneticCardEncryptedRawData (int encryption, NSData data);

		[Export ("firmwareUpdateProgress:percent:")]
		void FirmwareUpdateProgress (int phase, int percent);

		[Export ("bluetoothDiscoverComplete:")]
		void BluetoothDiscoverComplete (bool success);

		[Export ("bluetoothDeviceDiscovered:name:")]
		void BluetoothDeviceDiscovered (string btAddress, string btName);

		[Export ("bluetoothDeviceConnected:")]
		void BluetoothDeviceConnected (string btAddress);

		[Export ("bluetoothDeviceDisconnected:")]
		void BluetoothDeviceDisconnected (string btAddress);

		[Export ("bluetoothDeviceRequestedConnection:name:")]
		bool BluetoothDeviceRequestedConnection (string btAddress, string name);

		[Export ("bluetoothDevicePINCodeRequired:name:")]
		string BluetoothDevicePINCodeRequired (string btAddress, string name);

		[Export ("magneticJISCardData:")]
		void MagneticJISCardData (string data);

		[Export ("rfCardDetected:info:")]
		void RfCardDetected (int cardIndex, DTRFCardInfo info);

		[Export ("rfCardRemoved:")]
		void RfCardRemoved (int cardIndex);

		[Export ("emv2OnTransactionStarted")]
		void Emv2OnTransactionStarted ();

		[Export ("emv2OnApplicationSelection:")]
		void Emv2OnApplicationSelection (string [] applications);

		[Export ("emv2OnOnlineProcessing:")]
		void Emv2OnOnlineProcessing (NSData data);

		[Export ("emv2OnTransactionFinished:")]
		void Emv2OnTransactionFinished (NSData data);
	}

	[BaseType (typeof (NSObject))]
	interface Linea {

		[Static]
		[Export ("sharedDevice")]
		Linea SharedDevice { get; }

		[Export ("addDelegate:")]
		void AddDelegate (NSObject newDelegate);

		[Export ("removeDelegate:")]
		void RemoveDelegate (NSObject newDelegate);

		[Export ("connect")]
		void Connect ();

		[Export ("disconnect")]
		void Disconnect ();

		[Export ("isPresent")]
		bool IsPresent { get; }

		[Export ("getBatteryCapacity:voltage:error:")]
		bool GetBatteryCapacity (out int capacity, out float voltage, out NSError error);

		[Export ("setAutoOffWhenIdle:whenDisconnected:error:")]
		bool SetAutoOffWhenIdle (double timeIdle, double timeDisconnected, out NSError error);

		[Export("playSound:beepData:length:error:")] [Internal]
		bool PlaySound_ (int volume, IntPtr data, int length, out NSError error);

		[Export ("getCharging:error:")]
		bool GetCharging (out bool charging, out NSError error);

		[Export ("setCharging:error:")]
		bool SetCharging (bool enabled, out NSError error);

		[Export ("getFirmwareFileInformation:error:")]
		NSDictionary GetFirmwareFileInformation (NSData data, out NSError error);

		[Export ("updateFirmwareData:error:")]
		bool UpdateFirmwareData (NSData data, out NSError error);

		[Export ("getSyncButtonMode:error:")]
		bool GetSyncButtonMode (out int mode, out NSError error);

		[Export ("setSyncButtonMode:error:")]
		bool SetSyncButtonMode (int mode, out NSError error);

		[Export ("getPassThroughSync:error:")]
		bool GetPassThroughSync (out bool enabled, out NSError error);

		[Export ("setPassThroughSync:error:")]
		bool SetPassThroughSync (bool enabled, out NSError error);

		[Export ("setUSBChargeCurrent:error:")]
		bool SetUSBChargeCurrent (int current, out NSError error);

		[Export ("msEnable:")]
		bool MsEnable (out NSError error);

		[Export ("msDisable:")]
		bool MsDisable (out NSError error);

		[Export ("msProcessFinancialCard:track2:")]
		NSDictionary MsProcessFinancialCard (string track1, string track2);

		[Export ("msGetCardDataMode:error:")]
		bool MsGetCardDataMode (out int mode, out NSError error);

		[Export ("msSetCardDataMode:error:")]
		bool MsSetCardDataMode (int mode, out NSError error);

		[Export ("barcodeType2Text:")]
		string BarcodeType2Text (int barcodeType);

		[Export ("barcodeStartScan:")]
		bool BarcodeStartScan (out NSError error);

		[Export ("barcodeStopScan:")]
		bool BarcodeStopScan (out NSError error);

		[Export ("barcodeGetScanTimeout:error:")]
		bool BarcodeGetScanTimeout (out int timeout, out NSError error);

		[Export ("barcodeSetScanTimeout:error:")]
		bool BarcodeSetScanTimeout (int timeout, out NSError error);

		[Export ("barcodeGetScanButtonMode:error:")]
		bool BarcodeGetScanButtonMode (out int mode, out NSError error);

		[Export ("barcodeSetScanButtonMode:error:")]
		bool BarcodeSetScanButtonMode (int mode, out NSError error);

		[Export ("barcodeSetScanBeep:volume:beepData:length:error:")] [Internal]
		bool BarcodeSetScanBeep_ (bool enabled, int volume, IntPtr data, int length, out NSError error);

		[Export ("barcodeGetScanMode:error:")]
		bool BarcodeGetScanMode (out int mode, out NSError error);

		[Export ("barcodeSetScanMode:error:")]
		bool BarcodeSetScanMode (int mode, out NSError error);

		[Export ("barcodeEnableBarcode:enabled:error:")]
		bool BarcodeEnableBarcode (int barcodeType, bool enabled, out NSError error);

		[Export ("barcodeIsBarcodeEnabled:")]
		bool BarcodeIsBarcodeEnabled (int type);

		[Export ("barcodeIsBarcodeSupported:")]
		bool BarcodeIsBarcodeSupported (int type);

		[Export ("barcodeGetTypeMode:error:")]
		bool BarcodeGetTypeMode (out int mode, out NSError error);

		[Export ("barcodeSetTypeMode:error:")]
		bool BarcodeSetTypeMode (int mode, out NSError error);

		[Export ("barcodeEnginePowerControl:error:")]
		bool BarcodeEnginePowerControl (bool engineOn, out NSError error);

		[Export ("barcodeEnginePowerControl:maxTimeMinutes:error:")]
		bool BarcodeEnginePowerControl (bool engineOn, int maxTimeMinutes, out NSError error);

		[Export ("barcodeEngineResetToDefaults:")]
		bool BarcodeEngineResetToDefaults (out NSError error);

		[Export ("barcodeOpticonSetInitString:error:")]
		bool BarcodeOpticonSetInitString (string data, out NSError error);

		[Export ("barcodeOpticonSetParams:saveToFlash:error:")]
		bool BarcodeOpticonSetParams (string data, bool saveToFlash, out NSError error);

		[Export ("barcodeOpticonGetIdent:")]
		string BarcodeOpticonGetIdent (out NSError error);

		[Export ("barcodeOpticonUpdateFirmware:bootLoader:error:")]
		bool BarcodeOpticonUpdateFirmware (NSData firmwareData, bool bootLoader, out NSError error);

		[Export ("barcodeCodeSetParam:value:error:")]
		bool BarcodeCodeSetParam (int setting, UInt64 value, out NSError error);

		[Export ("barcodeCodeGetParam:value:error:")]
		bool BarcodeCodeGetParam (int setting, out UInt64 value, out NSError error);

		[Export ("barcodeCodeUpdateFirmware:data:error:")]
		bool BarcodeCodeUpdateFirmware (string name, NSData data, out NSError error);

		[Export ("barcodeCodeGetInformation:")]
		NSDictionary BarcodeCodeGetInformation (out NSError error);

		[Export ("barcodeIntermecSetInitData:error:")]
		bool BarcodeIntermecSetInitData (NSData data, out NSError error);

		[Export ("barcodeNewlandQuery:error:")]
		NSData BarcodeNewlandQuery (NSData command, out NSError error);

		[Export ("barcodeNewlandSetInitString:error:")]
		bool BarcodeNewlandSetInitString (string data, out NSError error);

		[Export ("cryptoRawGenerateRandomData:")]
		NSData CryptoRawGenerateRandomData (out NSError error);

		[Export ("cryptoRawSetKey:encryptedData:keyVersion:keyFlags:error:")]
		bool CryptoRawSetKey (int keyID, NSData encryptedData, uint keyVersion, uint keyFlags, out NSError error);

		[Export ("cryptoSetKey:key:oldKey:keyVersion:keyFlags:error:")]
		bool CryptoSetKey (int keyID, NSData key, NSData oldKey, uint keyVersion, uint keyFlags, out NSError error);

		[Export ("cryptoGetKeyVersion:keyVersion:error:")]
		bool CryptoGetKeyVersion (int keyID, uint keyVersion, out NSError error);

		[Export ("cryptoRawAuthenticateDevice:error:")]
		NSData CryptoRawAuthenticateDevice (NSData randomData, out NSError error);

		[Export ("cryptoAuthenticateDevice:error:")]
		bool CryptoAuthenticateDevice (NSData key, out NSError error);

		[Export ("cryptoRawAuthenticateHost:error:")]
		bool CryptoRawAuthenticateHost (NSData encryptedRandomData, out NSError error);

		[Export ("cryptoAuthenticateHost:error:")]
		bool CryptoAuthenticateHost (NSData key, out NSError error);

		[Export ("btGetEnabled:error:")]
		bool BtGetEnabled (out bool enabled, out NSError error);

		[Export ("btSetEnabled:error:")]
		bool BtSetEnabled (bool enabled, out NSError error);

		[Export ("btWrite:length:error:")] [Internal]
		bool BtWrite_ (IntPtr data, int length, out NSError error);

		[Export ("btWrite:error:")]
		bool BtWrite (string data, out NSError error);

		[Export ("btRead:length:timeout:error:")] [Internal]
		int BtRead_ (ref IntPtr data, int length, double timeout, out NSError error);

		[Export ("btReadLine:error:")]
		string BtReadLine (double timeout, out NSError error);

		[Export ("btDiscoverDevices:maxTime:codTypes:error:")]
		string [] BtDiscoverDevices (int maxDevices, double maxTime, int codTypes, out NSError error);

		[Export ("btGetDeviceName:error:")]
		string BtGetDeviceName (string address, out NSError error);

		[Export ("btDiscoverDevicesInBackground:maxTime:codTypes:error:")]
		bool BtDiscoverDevicesInBackground (int maxDevices, double maxTime, int codTypes, out NSError error);

		[Export ("btDiscoverSupportedDevicesInBackground:maxTime:filter:error:")]
		bool BtDiscoverSupportedDevicesInBackground (int maxDevices, double maxTime, int filter, out NSError error);

		[Export ("btDiscoverPrinters:maxTime:error:")]
		string [] BtDiscoverPrinters (int maxDevices, double maxTime, out NSError error);

		[Export ("btDiscoverPrintersInBackground:maxTime:error:")]
		bool BtDiscoverPrintersInBackground (int maxDevices, double maxTime, out NSError error);

		[Export ("btDiscoverPrintersInBackground:")]
		bool BtDiscoverPrintersInBackground (out NSError error);

		[Export ("btDiscoverPinpads:maxTime:error:")]
		string [] BtDiscoverPinpads (int maxDevices, double maxTime, out NSError error);

		[Export ("btDiscoverPinpadsInBackground:maxTime:error:")]
		bool BtDiscoverPinpadsInBackground (int maxDevices, double maxTime, out NSError error);

		[Export ("btDiscoverPinpadsInBackground:")]
		bool BtDiscoverPinpadsInBackground (out NSError error);

		[Export ("btConnect:pin:error:")]
		bool BtConnect (string address, string pin, out NSError error);

		[Export ("btDisconnect:error:")]
		bool BtDisconnect (string address, out NSError error);

		[Export ("btEnableWriteCaching:error:")]
		bool BtEnableWriteCaching (bool enabled, out NSError error);

		[Export ("btSetDataNotificationMaxTime:maxLength:sequenceData:error:")]
		bool BtSetDataNotificationMaxTime (double maxTime, int maxLength, NSData sequenceData, out NSError error);

		[Export ("btListenForDevices:discoverable:localName:cod:error:")]
		bool BtListenForDevices (bool enabled, bool discoverable, string localName, uint cod, out NSError error);

		[Export ("btInputStream", ArgumentSemantic.Assign)]
		NSInputStream BtInputStream { get; }

		[Export ("btOutputStream", ArgumentSemantic.Assign)]
		NSOutputStream BtOutputStream { get; }

		[Export ("extOpenSerialPort:baudRate:parity:dataBits:stopBits:flowControl:error:")]
		bool ExtOpenSerialPort (int port, int baudRate, int parity, int dataBits, int stopBits, int flowControl, out NSError error);

		[Export ("extCloseSerialPort:error:")]
		bool ExtCloseSerialPort (int port, out NSError error);

		[Export ("extWriteSerialPort:data:error:")]
		bool ExtWriteSerialPort (int port, NSData data, out NSError error);

		[Export ("extReadSerialPort:length:timeout:error:")]
		NSData ExtReadSerialPort (int port, int length, double timeout, out NSError error);

		[Export ("emsrGetFirmwareInformation:error:")]
		NSDictionary EmsrGetFirmwareInformation (NSData data, out NSError error);

		[Export ("emsrIsTampered:error:")]
		bool EmsrIsTampered (out bool tampered, out NSError error);

		[Export ("emsrGetKeyVersion:keyVersion:error:")]
		bool EmsrGetKeyVersion (int keyID, out int keyVersion, out NSError error);

		[Export ("emsrLoadInitialKey:error:")]
		bool EmsrLoadInitialKey (NSData keyData, out NSError error);

		[Export ("emsrLoadKey:error:")]
		bool EmsrLoadKey (NSData keyData, out NSError error);

		[Export ("emsrGetDUKPTSerial:")]
		NSData EmsrGetDUKPTSerial (out NSError error);

		[Export ("emsrGetDeviceModel:")]
		string EmsrGetDeviceModel (out NSError error);

		[Export ("emsrGetFirmwareVersion:error:")]
		bool EmsrGetFirmwareVersion (out int version, out NSError error);

		[Export ("emsrGetSecurityVersion:error:")]
		bool EmsrGetSecurityVersion (out int version, out NSError error);

		[Export ("emsrGetSerialNumber:")]
		NSData EmsrGetSerialNumber (out NSError error);

		[Export ("emsrUpdateFirmware:error:")]
		bool EmsrUpdateFirmware (NSData data, out NSError error);

		[Export ("emsrGetSupportedEncryptions:")]
		NSObject [] EmsrGetSupportedEncryptions (out NSError error);

		[Export ("emsrSetEncryption:params:error:")]
		bool EmsrSetEncryption (int encryption, NSDictionary parameters, out NSError error);

		[Export ("emsrConfigMaskedDataShowExpiration:unmaskedDigitsAtStart:unmaskedDigitsAtEnd:error:")]
		bool EmsrConfigMaskedDataShowExpiration (bool showExpiration, int unmaskedDigitsAtStart, int unmaskedDigitsAtEnd, out NSError error);

		[Export ("rfInit:error:")]
		bool RfInit (int supportedCards, out NSError error);

		[Export ("rfClose:")]
		bool RfClose (out NSError error);

		[Export ("rfRemoveCard:error:")]
		bool RfRemoveCard (int cardIndex, out NSError error);

		[Export ("mfAuthByKey:type:address:key:error:")]
		bool MfAuthByKey (int cardIndex, sbyte type, int address, NSData key, out NSError error);

		[Export ("mfStoreKeyIndex:type:key:error:")]
		bool MfStoreKeyIndex (int keyIndex, sbyte type, NSData key, out NSError error);

		[Export ("mfAuthByStoredKey:type:address:keyIndex:error:")]
		bool MfAuthByStoredKey (int cardIndex, sbyte type, int address, int keyIndex, out NSError error);

		[Export ("mfRead:address:length:error:")]
		NSData MfRead (int cardIndex, int address, int length, out NSError error);

		[Export ("mfWrite:address:data:error:")]
		int MfWrite (int cardIndex, int address, NSData data, out NSError error);

		[Export ("mfUlcSetKey:key:error:")]
		bool MfUlcSetKey (int cardIndex, NSData key, out NSError error);

		[Export ("mfUlcAuthByKey:key:error:")]
		bool MfUlcAuthByKey (int cardIndex, NSData key, out NSError error);

		[Export ("iso15693Read:startBlock:length:error:")]
		NSData Iso15693Read (int cardIndex, int startBlock, int length, out NSError error);

		[Export ("iso15693Write:startBlock:data:error:")]
		int Iso15693Write (int cardIndex, int startBlock, NSData data, out NSError error);

		[Export ("iso15693GetBlocksSecurityStatus:startBlock:nBlocks:error:")]
		NSData Iso15693GetBlocksSecurityStatus (int cardIndex, int startBlock, int nBlocks, out NSError error);

		[Export ("iso15693LockBlock:block:error:")]
		bool Iso15693LockBlock (int cardIndex, int block, out NSError error);

		[Export ("iso15693WriteAFI:afi:error:")]
		bool Iso15693WriteAFI (int cardIndex, byte afi, out NSError error);

		[Export ("iso15693LockAFI:error:")]
		bool Iso15693LockAFI (int cardIndex, out NSError error);

		[Export ("iso15693WriteDSFID:dsfid:error:")]
		bool Iso15693WriteDSFID (int cardIndex, byte dsfid, out NSError error);

		[Export ("iso15693LockDSFID:error:")]
		bool Iso15693LockDSFID (int cardIndex, out NSError error);

		[Export ("iso14GetATS:error:")]
		NSData Iso14GetATS (int cardIndex, out NSError error);

		[Export ("iso14APDU:cla:ins:p1:p2:data:apduResult:error:")]
		NSData Iso14APDU (int cardIndex, byte cla, byte ins, byte p1, byte p2, NSData data, out ushort apduResult, out NSError error);

		[Export ("felicaSetPollingParamsRequestCode:systemCode:error:")]
		bool FelicaSetPollingParamsRequestCode (int requestCode, int systemCode, out NSError error);

		[Export ("felicaSetPollingParamsRequestCode:error:")]
		bool FelicaSetPollingParamsRequestCode (int cardIndex, out NSError error);

		[Export ("felicaSendCommand:command:data:error:")]
		NSData FelicaSendCommand (int cardIndex, int command, NSData data, out NSError error);

		[Export ("felicaRead:serviceCode:startBlock:length:error:")]
		NSData FelicaRead (int cardIndex, int serviceCode, int startBlock, int length, out NSError error);

		[Export ("felicaWrite:serviceCode:startBlock:data:error:")]
		int FelicaWrite (int cardIndex, int serviceCode, int startBlock, NSData data, out NSError error);

		[Export ("felicaSmartTagGetBatteryStatus:status:error:")]
		bool FelicaSmartTagGetBatteryStatus (int cardIndex, out int status, out NSError error);

		[Export ("felicaSmartTagClearScreen:error:")]
		bool FelicaSmartTagClearScreen (int cardIndex, out NSError error);

		[Export ("felicaSmartTagDrawImage:image:topLeftX:topLeftY:drawMode:layout:error:")]
		bool FelicaSmartTagDrawImage (int cardIndex, UIImage image, int topLeftX, int topLeftY, int drawMode, int layout, out NSError error);

		[Export ("felicaSmartTagSaveLayout:layout:error:")]
		bool FelicaSmartTagSaveLayout (int cardIndex, int layout, out NSError error);

		[Export ("felicaSmartTagDisplayLayout:layout:error:")]
		bool FelicaSmartTagDisplayLayout (int cardIndex, int layout, out NSError error);

		[Export ("felicaSmartTagWrite:address:data:error:")]
		int FelicaSmartTagWrite (int cardIndex, int address, NSData data, out NSError error);

		[Export ("felicaSmartTagRead:address:length:error:")]
		NSData FelicaSmartTagRead (int cardIndex, int address, int length, out NSError error);

		[Export ("felicaSmartTagWaitCompletion:error:")]
		bool FelicaSmartTagWaitCompletion (int cardIndex, out NSError error);

		[Export ("stSRIRead:address:length:error:")]
		NSData StSRIRead (int cardIndex, int address, int length, out NSError error);

		[Export ("stSRIWrite:address:data:error:")]
		int StSRIWrite (int cardIndex, int address, NSData data, out NSError error);

		[Export ("emv2LoadConfigurationData:version:error:")]
		bool Emv2LoadConfigurationData (NSData data, int version, out NSError error);

		[Export ("emv2GetConfigurationInfo:")]
		DTEMVConfigurationInfo Emv2GetConfigurationInfo (out NSError error);

		[Export ("emv2SetTransactionType:amount:currencyCode:error:")]
		bool Emv2SetTransactionType (int type, int amount, int currencyCode, out NSError error);

		[Export ("emv2StartTransactionWithFlags:initData:error:")]
		bool Emv2StartTransactionWithFlags (int flags, NSData initData, out NSError error);

		[Export ("emv2SelectApplication:error:")]
		bool Emv2SelectApplication (int application, out NSError error);

		[Export ("emv2SetOnlineResult:error:")]
		bool Emv2SetOnlineResult (NSData result, out NSError error);

		[Export ("emv2CancelTransaction:")]
		bool Emv2CancelTransaction (out NSError error);

		[Wrap ("WeakDelegate")][NullAllowed]
		LineaDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("delegates")]
		NSObject [] Delegates { get; }

		[Export ("connstate")]
		int Connstate { get; }

		[Export ("deviceName", ArgumentSemantic.Copy)]
		string DeviceName { get; set; }

		[Export ("deviceModel", ArgumentSemantic.Copy)]
		string DeviceModel { get; set; }

		[Export ("firmwareRevision", ArgumentSemantic.Copy)]
		string FirmwareRevision { get; set; }

		[Export ("hardwareRevision", ArgumentSemantic.Copy)]
		string HardwareRevision { get; set; }

		[Export ("serialNumber", ArgumentSemantic.Copy)]
		string SerialNumber { get; set; }

		[Export ("sdkVersion")]
		int SdkVersion { get; }
	}
}

