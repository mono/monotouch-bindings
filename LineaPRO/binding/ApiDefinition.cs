using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreBluetooth;

namespace LineaProSdk
{
	[Static]
	interface RFCardInfoKeys 
	{
		[Field ("RFCardInfoType", "__Internal")]
		NSString Type { get; }

		[Field ("RFCardInfoTypeStr", "__Internal")]
		NSString TypeStr { get; }

		[Field ("RFCardInfoUID", "__Internal")]
		NSString Uid { get; }

		[Field ("RFCardInfoATQA", "__Internal")]
		NSString Atqa { get; }

		[Field ("RFCardInfoSAK", "__Internal")]
		NSString Sak { get; }

		[Field ("RFCardInfoAFI", "__Internal")]
		NSString Afi { get; }

		[Field ("RFCardInfoDSFID", "__Internal")]
		NSString Dsfid { get; }

		[Field ("RFCardInfoBlockSize", "__Internal")]
		NSString BlockSize { get; }

		[Field ("RFCardInfoNBlocks", "__Internal")]
		NSString NBlocks { get; }
	}

	[Static]
	interface InfoKeys 
	{
		[Field ("InfoDeviceName", "__Internal")]
		NSString DeviceName { get; }

		[Field ("InfoDeviceModel", "__Internal")]
		NSString DeviceModel { get; }

		[Field ("InfoFirmwareRevision", "__Internal")]
		NSString FirmwareRevision { get; }

		[Field ("InfoFirmwareRevisionNumber", "__Internal")]
		NSString FirmwareRevisionNumber { get; }
	}

	[BaseType (typeof(NSObject), Name="DTPinpadInfo")]
	interface PinpadInfo 
	{

		[Export ("cpuSerial", ArgumentSemantic.Copy)]
		NSData CpuSerial { get; set; }

		[Export ("cpuVersion")]
		uint CpuVersion { get; set; }

		[Export ("cpuLoaderVersion")]
		uint CpuLoaderVersion { get; set; }

		[Export ("cpuHALVersion")]
		uint CpuHalVersion { get; set; }

		[Export ("pinpadSerial", ArgumentSemantic.Copy)]
		NSData PinpadSerial { get; set; }

		[Export ("loaderName")]
		string LoaderName { get; set; }

		[Export ("loaderVersion")]
		uint LoaderVersion { get; set; }

		[Export ("fwName")]
		string FwName { get; set; }

		[Export ("fwVersion")]
		uint FwVersion { get; set; }
	}

	[BaseType (typeof(NSObject), Name="DTRFCardInfo")]
	interface RFCardInfo 
	{

		[Export ("type")]
		RfCardTypes Type { get; set; }

		[Export ("typeStr")]
		string TypeStr { get; set; }

		[Export ("UID", ArgumentSemantic.Copy)]
		NSData Uid { get; set; }

		[Export ("ATQA")]
		int Atqa { get; set; }

		[Export ("SAK")]
		int Sak { get; set; }

		[Export ("AFI")]
		int Afi { get; set; }

		[Export ("DSFID")]
		int Dsfid { get; set; }

		[Export ("blockSize")]
		int BlockSize { get; set; }

		[Export ("nBlocks")]
		int NBlocks { get; set; }

		[Export ("felicaPMm", ArgumentSemantic.Copy)]
		NSData FelicaPMm { get; set; }

		[Export ("felicaRequestData", ArgumentSemantic.Copy)]
		NSData FelicaRequestData { get; set; }

		[Export ("cardIndex")]
		int CardIndex { get; set; }
	}

	[BaseType (typeof(NSObject), Name="DTEMV2Info")]
	interface EMV2Info 
	{

		[Export ("configurationVersion")]
		int ConfigurationVersion { get; set; }

		[Export ("emvKernelVersion")]
		int EmvKernelVersion { get; set; }
	}

	[BaseType (typeof(NSObject), Name="DTBatteryInfo")]
	interface BatteryInfo 
	{

		[Export ("voltage")]
		float Voltage { get; set; }

		[Export ("capacity")]
		int Capacity { get; set; }

		[Export ("health")]
		int Health { get; set; }

		[Export ("maximumCapacity")]
		int MaximumCapacity { get; set; }

		[Export ("charging")]
		bool Charging { get; set; }

		[Export ("batteryChipType", ArgumentSemantic.Assign)]
		BatteryChips BatteryChipType { get; set; }

		[Export ("extendedInfo", ArgumentSemantic.Copy)]
		NSDictionary ExtendedInfo { get; set; }
	}

	[BaseType (typeof(NSObject), Name="DTVoltageInfo")]
	interface VoltageInfo 
	{

		[Export ("keyGenerated")]
		bool KeyGenerated { get; set; }

		[Export ("keyGenerationInProgress")]
		bool KeyGenerationInProgress { get; set; }

		[Export ("keyGenerationDate", ArgumentSemantic.Copy)]
		NSDate KeyGenerationDate { get; set; }

		[Export ("settingsVersion")]
		int SettingsVersion { get; set; }
	}

	[BaseType (typeof(NSObject), Name="EMSRDeviceInfo")]
	interface EMSRDeviceInfo 
	{

		[Export ("ident")]
		string Ident { get; set; }

		[Export ("serialNumber", ArgumentSemantic.Copy)]
		NSData SerialNumber { get; set; }

		[Export ("serialNumberString")]
		string SerialNumberString { get; set; }

		[Export ("firmwareVersion")]
		int FirmwareVersion { get; set; }

		[Export ("firmwareVersionString")]
		string FirmwareVersionString { get; set; }

		[Export ("securityVersion")]
		int SecurityVersion { get; set; }

		[Export ("securityVersionString")]
		string SecurityVersionString { get; set; }
	}

	[BaseType (typeof(NSObject), Name="EMSRKey")]
	interface EMSRKey 
	{

		[Export ("keyID")]
		int KeyId { get; set; }

		[Export ("keyVersion")]
		int KeyVersion { get; set; }

		[Export ("keyName")]
		string KeyName { get; set; }
	}

	[BaseType (typeof(NSObject), Name="EMSRKeysInfo")]
	interface EMSRKeysInfo 
	{

		[Static]
		[Export ("keyNameByID:")]
		string GetKeyName (int keyID);

		[Export ("keys", ArgumentSemantic.Copy)]
		EMSRKey[] Keys { get; set; }

		[Export ("tampered")]
		bool Tampered { get; set; }

		[Export ("getKeyVersion:")]
		int GetKeyVersion (int keyId);
	}

	[BaseType (typeof(NSObject), Name="DTDeviceInfo")]
	interface DeviceInfo 
	{

		[Export ("deviceType", ArgumentSemantic.Assign)]
		SupportedDeviceTypes DeviceType { get; set; }

		[Export ("connectionType", ArgumentSemantic.Assign)]
		DeviceConnectionType ConnectionType { get; set; }

		[Export ("name")]
		string Name { get; set; }

		[Export ("model")]
		string Model { get; set; }

		[Export ("firmwareRevision")]
		string FirmwareRevision { get; set; }

		[Export ("hardwareRevision")]
		string HardwareRevision { get; set; }

		[Export ("serialNumber")]
		string SerialNumber { get; set; }
	}

	[BaseType (typeof(NSObject), Name="DTEMVApplication")]
	interface EMVApplication 
	{

		[Export ("aid", ArgumentSemantic.Copy)]
		NSData Aid { get; set; }

		[Export ("label")]
		string Label { get; set; }

		[Export ("matchCriteria")]
		AppMatchCriterias MatchCriteria { get; set; }
	}

	[BaseType (typeof(NSObject), Name="DTCAKeyInfo")]
	interface CAKeyInfo 
	{

		[Export ("keyIndex")]
		int KeyIndex { get; set; }

		[Export ("RIDI", ArgumentSemantic.Copy)]
		NSData Ridi { get; set; }

		[Export ("moduleLength")]
		int ModuleLength { get; set; }
	}

	[BaseType (typeof(NSObject), Name="DTKeyInfo")]
	interface KeyInfo 
	{

		[Export ("checkValue", ArgumentSemantic.Copy)]
		NSData CheckValue { get; set; }

		[Export ("type")]
		int Type { get; set; }

		[Export ("usage")]
		string Usage { get; set; }

		[Export ("mode")]
		sbyte Mode { get; set; }

		[Export ("version")]
		int Version { get; set; }
	}

	interface ILineaDelegate { }

	[Protocol, Model]
	[BaseType (typeof(NSObject), Name="DTDeviceDelegate")]
	interface LineaDelegate 
	{

		[Export ("connectionState:")]
		void ConnectionState (ConnStates state);

		[Export ("deviceButtonPressed:")]
		void DeviceButtonPressed (int whichButton);

		[Export ("deviceButtonReleased:")]
		void DeviceButtonReleased (int whichButton);

		[Export ("barcodeData:type:")]
		void BarcodeData (string barcode, int barcodeType); // barcodeType can be DTBarcodes or DTBarcodesEx depending on BarcodeSetTypeMode

		[Export ("barcodeData:isotype:")]
		void BarcodeData (string barcode, string isotype);

		[Export ("barcodeNSData:type:")]
		void BarcodeData (NSData barcode, int barcodeType); // barcodeType can be DTBarcodes or DTBarcodesEx depending on BarcodeSetTypeMode

		[Export ("barcodeNSData:isotype:")]
		void BarcodeData (NSData barcode, string isotype);

		[Export ("magneticCardData:track2:track3:")]
		void MagneticCardData ([NullAllowed]string track1, [NullAllowed]string track2, [NullAllowed]string track3);

		[Export ("magneticCardEncryptedData:tracks:data:")]
		void MagneticCardEncryptedData (MagCardEncryption encryption, int tracks, NSData data);

		[Export ("magneticCardEncryptedData:tracks:data:track1masked:track2masked:track3:")]
		void MagneticCardEncryptedData (MagCardEncryption encryption, int tracks, NSData data, string track1masked, string track2masked, string track3);

		[Export ("magneticCardEncryptedData:tracks:data:track1masked:track2masked:track3:source:")]
		void MagneticCardEncryptedData (MagCardEncryption encryption, int tracks, NSData data, string track1masked, string track2masked, string track3, int source);

		[Export ("magneticCardRawData:")]
		void MagneticCardRawData (NSData tracks);

		[Export ("magneticCardEncryptedRawData:data:")]
		void MagneticCardEncryptedRawData (MagCardEncryption encryption, NSData data);

		[Export ("firmwareUpdateProgress:percent:")]
		void FirmwareUpdateProgress (UpdatePhases phase, int percent);

		[Export ("bluetoothDiscoverComplete:")]
		void BluetoothDiscoverComplete (bool success);

		[Export ("bluetoothDeviceDiscovered:name:")]
		void BluetoothDeviceDiscovered (string address, string name);

		[Export ("bluetoothDeviceConnected:")]
		void BluetoothDeviceConnected (string address);

		[Export ("bluetoothDeviceDisconnected:")]
		void BluetoothDeviceDisconnected (string address);

		[Export ("bluetoothDeviceRequestedConnection:name:")]
		bool BluetoothDeviceRequestedConnection (string address, string name);

		[Export ("bluetoothDevicePINCodeRequired:name:")]
		string BluetoothDevicePinCodeRequired (string address, string name);

		[Export ("magneticJISCardData:")]
		void MagneticJisCardData (string data);

		[Export ("rfCardDetected:info:")]
		void RfCardDetected (int cardIndex, RFCardInfo info);

		[Export ("rfCardRemoved:")]
		void RfCardRemoved (int cardIndex);

		[Export ("deviceFeatureSupported:value:")]
		void DeviceFeatureSupported (Features feature, FeatureValue supportedValue);

		[Export ("smartCardInserted:")]
		void SmartCardInserted (ScSlots slot);

		[Export ("smartCardRemoved:")]
		void SmartCardRemoved (ScSlots slot);

		[Export ("PINEntryCompleteWithError:")]
		void PinEntryComplete (NSError error);

		[Export ("paperStatus:")]
		void PaperStatus (bool present);

		[Export ("sdkDebug:source:")]
		void SdkDebug (string logText, SdkDebugSource source);

		[Export ("emv2OnTransactionStarted")]
		void Emv2OnTransactionStarted ();

		[Export ("emv2OnUserInterfaceCode:status:holdTime:")]
		void Emv2OnUserInterfaceCode (EmvUiCodes code, int status, double holdTime);

		[Export ("emv2OnApplicationSelection:")]
		void Emv2OnApplicationSelection (string[] applications);

		[Export ("emv2OnOnlineProcessing:")]
		void Emv2OnOnlineProcessing (NSData data);

		[Export ("emv2OnTransactionFinished:")]
		void Emv2OnTransactionFinished (NSData data);

		[Export ("bluetoothLEDeviceConnected:")]
		void BluetoothLEDeviceConnected (CBPeripheral device);

		[Export ("bluetoothLEDeviceDisconnected:")]
		void BluetoothLEDeviceDisconnected (CBPeripheral device);

		[Export ("bluetoothLEDeviceDiscovered:")]
		bool BluetoothLEDeviceDiscovered (CBPeripheral device);

		[Export ("bluetoothLEDiscoverCompletedWithError:")]
		void bluetoothLEDiscoverCompleted (NSError error);
	}

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name="DTDevices")]
	interface Linea 
	{

		[Static]
		[Export ("sharedDevice")]
		Linea SharedDevice { get; }

		[Export ("addDelegate:")]
		void AddDelegate (ILineaDelegate newDelegate);

		[Export ("removeDelegate:")]
		void RemoveDelegate (ILineaDelegate newDelegate);

		[Export ("connect")]
		void Connect ();

		[Export ("disconnect")]
		void Disconnect ();

		[Export ("isPresent:")]
		bool IsPresent (SupportedDeviceTypes deviceType);

		[Export ("setActiveDeviceType:error:")]
		bool SetActiveDeviceType (SupportedDeviceTypes deviceType, out NSError error);

		[Export ("setAutoOffWhenIdle:whenDisconnected:error:")]
		bool SetAutoOffWhenIdle (double timeIdle, double timeDisconnected, out NSError error);

		[Export ("getBatteryCapacity:voltage:error:")]
		bool GetBatteryCapacity (out int capacity, out float voltage, out NSError error);

		[Export ("getBatteryInfo:")]
		BatteryInfo GetBatteryInfo (out NSError error);

		[Export ("setBatteryMaxCapacity:error:")]
		bool SetBatteryMaxCapacity (int capacity, out NSError error);

		[Export ("getConnectedDevicesInfo:")]
		DeviceInfo[] GetConnectedDevicesInfo (out NSError error);

		[Export ("getConnectedDeviceInfo:error:")]
		DeviceInfo GetConnectedDeviceInfo (SupportedDeviceTypes deviceType, out NSError error);

		[Export ("playSound:beepData:length:error:")][Internal]
		bool _PlaySound (int volume, IntPtr data, int length, out NSError error);

		[Export ("setKioskMode:error:")]
		bool SetKioskMode (bool enabled, out NSError error);

		[Export ("getKioskMode:error:")]
		bool GetKioskMode (out bool enabled, out NSError error);

		[Export ("getCharging:error:")]
		bool GetCharging (out bool charging, out NSError error);

		[Export ("setCharging:error:")]
		bool SetCharging (bool enabled, out NSError error);

		[Export ("getPassThroughSync:error:")]
		bool GetPassThroughSync (out bool enabled, out NSError error);

		[Export ("setPassThroughSync:error:")]
		bool SetPassThroughSync (bool enabled, out NSError error);

		[Export ("getUSBChargeCurrent:error:")]
		bool GetUSBChargeCurrent (out int current, out NSError error);

		[Export ("setUSBChargeCurrent:error:")]
		bool SetUSBChargeCurrent (int current, out NSError error);

		[Export ("getFirmwareFileInformation:error:")]
		NSDictionary GetFirmwareFileInformation (NSData data, out NSError error);

		[Export ("updateFirmwareData:error:")]
		bool UpdateFirmwareData (NSData data, out NSError error);

		[Export ("getSupportedFeature:error:")]
		FeatureValue GetSupportedFeature (Features feature, out NSError error);

		[Export ("getTimeRemainingToPowerOff:error:")]
		bool GetTimeRemainingToPowerOff (out double timeRemaining, out NSError error);

		[Export ("sysSaveSettingsToFlash:")]
		bool SysSaveSettingsToFlash (out NSError error);

		[Export ("msEnable:")]
		bool MsEnable (out NSError error);

		[Export ("msDisable:")]
		bool MsDisable (out NSError error);

		[Export ("msProcessFinancialCard:track2:")]
		NSDictionary MsProcessFinancialCard ([NullAllowed]string track1, [NullAllowed]string track2);

		[Export ("msSetCardDataMode:error:")]
		bool MsSetCardDataMode (MsModes mode, out NSError error);

		[Export ("barcodeType2Text:")]
		string BarcodeType2Text (int barcodeType);

		[Export ("barcodeStartScan:")]
		bool BarcodeStartScan (out NSError error);

		[Export ("barcodeStopScan:")]
		bool BarcodeStopScan (out NSError error);

		[Export ("barcodeGetScanButtonMode:error:")]
		bool BarcodeGetScanButtonMode (out ButtonStates buttonMode, out NSError error);

		[Export ("barcodeSetScanButtonMode:error:")]
		bool BarcodeSetScanButtonMode (ButtonStates buttonMode, out NSError error);

		[Export ("barcodeSetScanBeep:volume:beepData:length:error:")][Internal]
		bool _BarcodeSetScanBeep (bool enabled, int volume, IntPtr data, int length, out NSError error);

		[Export ("barcodeGetScanMode:error:")]
		bool BarcodeGetScanMode (out ScanModes scanMode, out NSError error);

		[Export ("barcodeSetScanMode:error:")]
		bool BarcodeSetScanMode (ScanModes mode, out NSError error);

		[Export ("barcodeGetTypeMode:error:")]
		bool BarcodeGetTypeMode (out BtModes mode, out NSError error);

		[Export ("barcodeSetTypeMode:error:")]
		bool BarcodeSetTypeMode (BtModes mode, out NSError error);

		[Export ("barcodeEngineResetToDefaults:")]
		bool BarcodeEngineResetToDefaults (out NSError error);

		[Export ("barcodeEngineCheckReady:error:")]
		bool BarcodeEngineCheckReady (out bool ready, out NSError error);

		[Export ("barcodeOpticonSetInitString:error:")]
		bool BarcodeOpticonSetInitString (string data, out NSError error);

		[Export ("barcodeOpticonSetParams:saveToFlash:error:")]
		bool BarcodeOpticonSetParams (string data, bool saveToFlash, out NSError error);

		[Export ("barcodeOpticonGetIdent:")]
		string BarcodeOpticonGetIdent (out NSError error);

		[Export ("barcodeOpticonUpdateFirmware:bootLoader:error:")]
		bool BarcodeOpticonUpdateFirmware (NSData firmwareData, bool bootLoader, out NSError error);

		[Export ("barcodeCodeSetParam:value:error:")]
		bool BarcodeCodeSetParam (int setting, ulong value, out NSError error);

		[Export ("barcodeCodeGetParam:value:error:")]
		bool BarcodeCodeGetParam (int setting, out ulong value, out NSError error);

		[Export ("barcodeCodeUpdateFirmware:data:error:")]
		bool BarcodeCodeUpdateFirmware (string name, NSData data, out NSError error);

		[Export ("barcodeCodeGetInformation:")]
		NSDictionary BarcodeCodeGetInformation (out NSError error);

		[Export ("barcodeIntermecSetInitData:error:")]
		bool BarcodeIntermecSetInitData (NSData data, out NSError error);

		[Export ("barcodeMotorolaSetInitData:error:")]
		bool BarcodeMotorolaSetInitData (NSData data, out NSError error);

		[Export ("barcodeNewlandQuery:error:")]
		NSData BarcodeNewlandQuery (NSData command, out NSError error);

		[Export ("barcodeNewlandSetInitString:error:")]
		bool BarcodeNewlandSetInitString (string data, out NSError error);

		[Export ("btDiscoverSupportedDevicesInBackground:maxTime:filter:error:")]
		bool BtDiscoverSupportedDevicesInBackground (int maxDevices, double maxTime, BluetoothFilter filter, out NSError error);

		[Export ("btDiscoverDevicesInBackground:maxTime:codTypes:error:")]
		bool BtDiscoverDevicesInBackground (int maxDevices, double maxTime, int codTypes, out NSError error);

		[Export ("btDiscoverPrintersInBackground:maxTime:error:")]
		bool BtDiscoverPrintersInBackground (int maxDevices, double maxTime, out NSError error);

		[Export ("btDiscoverPrintersInBackground:")]
		bool BtDiscoverPrintersInBackground (out NSError error);

		[Export ("btDiscoverPinpadsInBackground:maxTime:error:")]
		bool BtDiscoverPinpadsInBackground (int maxDevices, double maxTime, out NSError error);

		[Export ("btDiscoverPinpadsInBackground:")]
		bool BtDiscoverPinpadsInBackground (out NSError error);

		[Export ("btConnect:pin:error:")]
		bool BtConnect (string address, [NullAllowed] string pin, out NSError error);

		[Export ("btDisconnect:error:")]
		bool BtDisconnect (string address, out NSError error);

		[Export ("btConnectSupportedDevice:pin:error:")]
		bool BtConnectSupportedDevice (string address, [NullAllowed] string pin, out NSError error);

		[Export ("btWrite:length:error:")][Internal]
		bool _BtWrite (IntPtr data, int length, out NSError error);

		[Export ("btWrite:error:")]
		bool BtWrite (string data, out NSError error);

		[Export ("btRead:length:timeout:error:")][Internal]
		int _BtRead (ref IntPtr data, int length, double timeout, out NSError error);

		[Export ("btReadLine:error:")]
		string BtReadLine (double timeout, out NSError error);

		[Export ("btEnableWriteCaching:error:")]
		bool BtEnableWriteCaching (bool enabled, out NSError error);

		[Export ("btDiscoverDevices:maxTime:codTypes:error:")]
		string[] BtDiscoverDevices (int maxDevices, double maxTime, int codTypes, out NSError error);

		[Export ("btGetDeviceName:error:")]
		string BtGetDeviceName (string address, out NSError error);

		[Export ("btSetDataNotificationMaxTime:maxLength:sequenceData:error:")]
		bool BtSetDataNotificationMaxTime (double maxTime, int maxLength, [NullAllowed]NSData sequenceData, out NSError error);

		[Export ("btListenForDevices:discoverable:localName:cod:error:")]
		bool BtListenForDevices (bool enabled, bool discoverable, string localName, uint cod, out NSError error);

		[Export ("btGetLocalAddress:")]
		string BtGetLocalAddress (out NSError error);

		[Export ("btSetMicGain:error:")]
		bool BtSetMicGain (int gain, out NSError error);

		[Export ("btleDiscoverSupportedDevices:stopOnFound:error:")]
		CBPeripheral[] BtleDiscoverSupportedDevices (int filter, bool stopOnFound, out NSError error);

		[Export ("btleDiscoverStop")]
		bool BtleDiscoverStop ();

		[Export ("btleConnectToDevice:error:")]
		bool BtleConnectToDevice (CBPeripheral aPeripheral, out NSError error);

		[Export ("btleDisconnect:error:")]
		bool BtleDisconnect (CBPeripheral aPeripheral, out NSError error);

		[Export ("btInputStream", ArgumentSemantic.Assign)]
		NSInputStream BtInputStream { get; }

		[Export ("btOutputStream", ArgumentSemantic.Assign)]
		NSOutputStream BtOutputStream { get; }

		[Export ("btConnectedDevices")]
		string[] BtConnectedDevices { get; }

		[Export ("btleConnectedDevices")]
		string[] BtleConnectedDevices { get; }

		[Export ("extOpenSerialPort:baudRate:parity:dataBits:stopBits:flowControl:error:")]
		bool ExtOpenSerialPort (int port, int baudRate, Parity parity, DataBits dataBits, StopBits stopBits, FlowControl flowControl, out NSError error);

		[Export ("extCloseSerialPort:error:")]
		bool ExtCloseSerialPort (int port, out NSError error);

		[Export ("extWriteSerialPort:data:error:")]
		bool ExtWriteSerialPort (int port, NSData data, out NSError error);

		[Export ("extReadSerialPort:length:timeout:error:")]
		NSData ExtReadSerialPort (int port, int length, double timeout, out NSError error);

		[Export ("tcpConnectSupportedDevice:error:")]
		bool TcpConnectSupportedDevice (string address, out NSError error);

		[Export ("tcpDisconnect:error:")]
		bool TcpDisconnect (string address, out NSError error);

		[Export ("tcpConnectedDevices")]
		string[] TcpConnectedDevices { get; }

		[Export ("cryptoRawGenerateRandomData:")]
		NSData CryptoRawGenerateRandomData (out NSError error);

		[Export ("cryptoRawSetKey:encryptedData:keyVersion:keyFlags:error:")]
		bool CryptoRawSetKey (int keyID, NSData encryptedData, uint keyVersion, uint keyFlags, out NSError error);

		[Export ("cryptoSetKey:key:oldKey:keyVersion:keyFlags:error:")]
		bool CryptoSetKey (int keyID, NSData key, NSData oldKey, uint keyVersion, uint keyFlags, out NSError error);

		[Export ("cryptoGetKeyVersion:keyVersion:error:")]
		bool CryptoGetKeyVersion (int keyID, out uint keyVersion, out NSError error);

		[Export ("cryptoRawAuthenticateDevice:error:")]
		NSData CryptoRawAuthenticateDevice (NSData randomData, out NSError error);

		[Export ("cryptoAuthenticateDevice:error:")]
		bool CryptoAuthenticateDevice (NSData key, out NSError error);

		[Export ("cryptoRawAuthenticateHost:error:")]
		bool CryptoRawAuthenticateHost (NSData encryptedRandomData, out NSError error);

		[Export ("cryptoAuthenticateHost:error:")]
		bool CryptoAuthenticateHost (NSData key, out NSError error);

		[Export ("emsrSetActiveHead:error:")]
		bool EmsrSetActiveHead (int active, out NSError error);

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
		NSNumber[] EmsrGetSupportedEncryptions (out NSError error);

		[Export ("emsrSetEncryption:params:error:")]
		bool EmsrSetEncryption (MagCardEncryption encryption, [NullAllowed] NSDictionary paramDict, out NSError error);

		[Export ("emsrSetEncryption:keyID:params:error:")]
		bool EmsrSetEncryption (MagCardEncryption encryption, int keyID, [NullAllowed] NSDictionary paramDict, out NSError error);

		[Export ("emsrConfigMaskedDataShowExpiration:showServiceCode:unmaskedDigitsAtStart:unmaskedDigitsAtEnd:unmaskedDigitsAfter:error:")]
		bool EmsrConfigMaskedData (bool showExpiration, bool showServiceCode, int unmaskedDigitsAtStart, int unmaskedDigitsAtEnd, int unmaskedDigitsAfter, out NSError error);

		[Export ("emsrConfigMaskedDataShowExpiration:unmaskedDigitsAtStart:unmaskedDigitsAtEnd:error:")]
		bool EmsrConfigMaskedData (bool showExpiration, int unmaskedDigitsAtStart, int unmaskedDigitsAtEnd, out NSError error);

		[Export ("emsrConfigMaskedDataShowExpiration:unmaskedDigitsAtStart:unmaskedDigitsAtEnd:unmaskedDigitsAfter:error:")]
		bool EmsrConfigMaskedData (bool showExpiration, int unmaskedDigitsAtStart, int unmaskedDigitsAtEnd, int unmaskedDigitsAfter, out NSError error);

		[Export ("emsrLoadRSAKeyPEM:version:error:")]
		bool EmsrLoadRsaKey (string pem, int version, out NSError error);

		[Export ("emsrGetDeviceInfo:")]
		EMSRDeviceInfo EmsrGetDeviceInfo (out NSError error);

		[Export ("emsrGetKeysInfo:")]
		EMSRKeysInfo EmsrGetKeysInfo (out NSError error);

		[Export ("emsrSetCardDataMode:tracks:trackIdentifiers:error:")]
		bool EmsrSetCardDataMode (MsModes mode, MsTrack tracks, bool trackIdentifiers, out NSError error);

		[Export ("samPowerOn:")]
		NSData SamPowerOn (out NSError error);

		[Export ("samPowerOff:")]
		bool SamPowerOff (out NSError error);

		[Export ("samAPDU:ins:p1:p2:inData:apduStatus:error:")]
		bool SamApdu (byte cla, byte ins, byte p1, byte p2, [NullAllowed]NSData inData, out ushort apduStatus, out NSError error);

		[Export ("samCAPDU:ins:p1:p2:inData:outLength:apduStatus:error:")]
		NSData SamCapdu (byte cla, byte ins, byte p1, byte p2, [NullAllowed]NSData inData, int outLength, out ushort apduStatus, out NSError error);

		[Export ("voltageGetInfo:")]
		VoltageInfo VoltageGetInfo (out NSError error);

		[Export ("voltageLoadConfiguration:error:")]
		bool VoltageLoadConfiguration (NSData configuration, out NSError error);

		[Export ("voltageGenerateNewKey:")]
		bool VoltageGenerateNewKey (out NSError error);

		[Export ("voltageSetMerchantID:error:")]
		bool VoltageSetMerchantId (string merchantId, out NSError error);

		[Export ("voltageSetPublicParameters:error:")]
		bool VoltageSetPublicParameters ([NullAllowed] NSData publicParameters, out NSError error);

		[Export ("voltageSetIdentityString:error:")]
		bool VoltageSetIdentityString ([NullAllowed] string identityString, out NSError error);

		[Export ("voltageSetEncryptionType:error:")]
		bool VoltageSetEncryptionType (VoltageEncryption type, out NSError error);

		[Export ("voltageSetSettingsVersion:error:")]
		bool VoltageSetSettingsVersion (int version, out NSError error);

		[Export ("voltageSetKeyRolloverDays:numberOfTransactions:error:")]
		bool VoltageSetKeyRolloverDays (int days, int numberOfTransactions, out NSError error);

		[Export ("rfInit:error:")]
		bool RfInit (RFCardSupport supportedCards, out NSError error);

		[Export ("rfClose:")]
		bool RfClose (out NSError error);

		[Export ("rfRemoveCard:error:")]
		bool RfRemoveCard (int cardIndex, out NSError error);

		[Export ("rfDetectCardOnChannel:additionalData:error:")]
		RFCardInfo RfDetectCardOnChannel (RfChannel channel, NSData additionalData, out NSError error);

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

		[Export ("iso14Transceive:data:error:")]
		NSData Iso14Transceive (int cardIndex, NSData data, out NSError error);

		[Export ("iso14Transceive:data:status:error:")]
		NSData Iso14Transceive (int cardIndex, NSData data, out byte status, out NSError error);

		[Export ("felicaSetPollingParamsRequestCode:systemCode:error:")]
		bool FelicaSetPollingParamsRequestCode (int requestCode, int systemCode, out NSError error);

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
		bool FelicaSmartTagDrawImage (int cardIndex, UIImage image, int topLeftX, int topLeftY, FelicaSmartTagDrawModes drawMode, int layout, out NSError error);

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

		[Export ("dfAESAuthByFixedKey:key:keyIndex:error:")]
		NSData DfAESAuthByFixedKey (int cardIndex, NSData key, int keyIndex, out NSError error);

		[Export ("dfCreateFile:fileID:type:permissions:size:isoID:error:")]
		bool DfCreateFile (int cardIndex, int fileId, byte type, ushort permissions, uint size, short isoId, out NSError error);

		[Export ("dfWriteFile:fileID:data:error:")]
		bool DfWriteFile (int cardIndex, int fileId, NSData data, out NSError error);

		[Export ("dfReadFile:fileID:length:error:")]
		NSData DfReadFile (int cardIndex, int fileId, int length, out NSError error);

		[Export ("dfSelectApplication:app:error:")]
		bool DfSelectApplication (int cardIndex, uint app, out NSError error);

		[Export ("hidGetVersionInfo:")]
		NSData HidGetVersionInfo (out NSError error);

		[Export ("hidGetSerialNumber:")]
		NSData HidGetSerialNumber (out NSError error);

		[Export ("hidGetContentElement:pin:rootSoOID:error:")]
		NSData HidGetContentElement (int contentTag, NSData pin, NSData rootSoOID, out NSError error);

		[Export ("scInit:error:")]
		bool ScInit (ScSlots slot, out NSError error);

		[Export ("scCardPowerOn:error:")]
		NSData ScCardPowerOn (ScSlots slot, out NSError error);

		[Export ("scCardPowerOff:error:")]
		bool ScCardPowerOff (ScSlots slot, out NSError error);

		[Export ("scIsCardPresent:error:")]
		bool ScIsCardPresent (ScSlots slot, out NSError error);

		[Export ("scCAPDU:apdu:error:")]
		NSData ScCAPDU (ScSlots slot, NSData apdu, out NSError error);

		[Export ("scClose:error:")]
		bool ScClose (ScSlots slot, out NSError error);

		[Export ("ppadPINEntry:startY:timeout:echoChar:message:error:")]
		bool PpadPinEntry (int startX, int startY, int timeout, sbyte echoChar, string message, out NSError error);

		[Export ("ppadStartPINEntry:startY:timeout:echoChar:message:error:")]
		bool PpadStartPinEntry (int startX, int startY, int timeout, sbyte echoChar, string message, out NSError error);

		[Export ("ppadCancelPINEntry:")]
		bool PpadCancelPinEntry (out NSError error);

		[Export ("ppadMagneticCardEntry:timeout:error:")]
		bool PpadMagneticCardEntry (Languages language, int timeout, out NSError error);

		[Export ("ppadGetPINBlockUsingFixedKey:keyVariant:pinFormat:error:")]
		NSData PpadGetPinBlockUsingFixedKey (int fixedKeyId, [NullAllowed] NSData keyVariant, PinEncryptionFormats pinFormat, out NSError error);

		[Export ("ppadGetPINBlockUsingDUKPT:keyVariant:pinFormat:error:")]
		NSData PpadGetPinBlockUsingDukpt (int dukptKeyId, [NullAllowed] NSData keyVariant, PinEncryptionFormats pinFormat, out NSError error);

		[Export ("ppadGetPINBlockUsingMasterSession:fixedKeyID:pinFormat:error:")]
		NSData PpadGetPinBlockUsingMasterSession (NSData sessionKey, int fixedKeyID, PinEncryptionFormats pinFormat, out NSError error);

		[Export ("ppadGetKeyInfo:error:")]
		KeyInfo PpadGetKeyInfo (int keyId, out NSError error);

		[Export ("ppadGetDUKPTKeyKSN:error:")]
		NSData PpadGetDukptKeyKsn (int keyId, out NSError error);

		[Export ("ppadCryptoExchangeKeyID:kekID:usage:version:data:cbc:error:")]
		NSData PpadCryptoExchange (int keyId, int kekId, int usage, int version, NSData data, bool cbc, out NSError error);

		[Export ("ppadCryptoTR31ExchangeKeyID:kekID:tr31:error:")]
		NSData PpadCryptoTR31Exchange (int keyId, int kekId, string tr31, out NSError error);

		[Export ("ppadCrypto3DESECBEncryptKeyID:inData:error:")]
		NSData PpadCrypto3DESECBEncrypt (int keyId, NSData inData, out NSError error);

		[Export ("ppadCrypto3DESECBDecryptKeyID:inData:error:")]
		NSData PpadCrypto3DESECBDecrypt (int keyId, NSData inData, out NSError error);

		[Export ("ppadCrypto3DESCBCEncryptKeyID:initVector:inData:error:")]
		NSData PpadCrypto3DESCBCEncrypt (int keyId, [NullAllowed]NSData initVector, NSData inData, out NSError error);

		[Export ("ppadCrypto3DESCBCDecryptKeyID:initVector:inData:error:")]
		NSData PpadCrypto3DESCBCDecrypt (int keyId, [NullAllowed]NSData initVector, NSData inData, out NSError error);

		[Export ("ppadCryptoDelete3DESKeyID:error:")]
		bool PpadCryptoDelete3DES (int keyId, out NSError error);

		[Export ("ppadSetButtonCaption:caption:error:")]
		bool PpadSetButtonCaption (int buttonIndex, string caption, out NSError error);

		[Export ("ppadGetSystemInfo:")]
		PinpadInfo PpadGetSystemInfo (out NSError error);

		[Export ("ppadKeyboardControl:error:")]
		bool PpadKeyboardControl (bool capture, out NSError error);

		[Export ("ppadReadKey:error:")]
		bool PpadReadKey (out sbyte key, out NSError error);

		[Export ("caImportKeyNumber:RIDI:module:exponent:error:")]
		bool CaImportKeyNumber (int keyNumber, NSData RIDI, NSData module, NSData exponent, out NSError error);

		[Export ("caWriteKeysToFlash:")]
		bool CaWriteKeysToFlash (out NSError error);

		[Export ("caGetKeysData:")]
		NSObject[] CaGetKeysData (out NSError error);

		[Export ("caImportIssuerKeyNumber:exponent:remainder:certificate:error:")]
		NSData CaImportIssuerKeyNumber (int keyNumber, NSData exponent, NSData remainder, NSData certificate, out NSError error);

		[Export ("caImportICCKeyType:exponent:remainder:certificate:error:")]
		NSData CaImportIccKeyType (IccTypes keyType, NSData exponent, NSData remainder, NSData certificate, out NSError error);

		[Export ("caRSAVerify:inData:error:")]
		NSData CaRSAVerify (RsaVerifyKey keyType, NSData inData, out NSError error);

		[Export ("emv2Initialise:")]
		bool Emv2Initialise (out NSError error);

		[Export ("emv2Deinitialise:")]
		bool Emv2Deinitialise (out NSError error);

		[Export ("emv2SetCardEmulationMode:encryption:keyID:error:")]
		bool Emv2SetCardEmulationMode (bool enabled, MagCardEncryption encryption, int keyId, out NSError error);

		[Export ("emv2LoadConfigurationData:error:")]
		bool Emv2LoadConfigurationData (NSData data, out NSError error);

		[Export ("emv2GetInfo:")]
		EMV2Info Emv2GetInfo (out NSError error);

		[Export ("emv2SetTransactionType:amount:currencyCode:error:")]
		bool Emv2SetTransactionType (int type, int amount, int currencyCode, out NSError error);

		[Export ("emv2StartTransactionWithFlags:initData:error:")]
		bool Emv2StartTransaction (int flags, NSData initData, out NSError error);

		[Export ("emv2SelectApplication:error:")]
		bool Emv2SelectApplication (int application, out NSError error);

		[Export ("emv2SetOnlineResult:error:")]
		bool Emv2SetOnlineResult (NSData result, out NSError error);

		[Export ("emv2CancelTransaction:")]
		bool Emv2CancelTransaction (out NSError error);

		[Export ("emv2GetCardTracksEncryptedWithFormat:keyID:error:")]
		NSData Emv2GetCardTracksEncrypted (MagCardEncryption format, int keyId, out NSError error);

		[Export ("emv2GetTagsEncrypted:format:keyType:keyIndex:packetID:error:")]
		NSData Emv2GetTagsEncrypted (NSData tagList, TagsFormat format, KeyType keyType, int keyIndex, uint packetID, out NSError error);

		[Export ("emv2GetTagsPlain:error:")]
		NSData Emv2GetTagsPlain (NSData tagList, out NSError error);

		[Export ("emvInitialise:")]
		bool EmvInitialise (out NSError error);

		[Export ("emvDeinitialise:")]
		bool EmvDeinitialise (out NSError error);

		[Export ("emvATRValidation:warmReset:error:")]
		bool EmvAtrValidation (NSData ATR, bool warmReset, out NSError error);

		[Export ("emvLoadAppList:selectionMethod:includeBlockedAIDs:error:")]
		bool EmvLoadAppList (EMVApplication[] appList, AppSelectionMethods selectionMethod, bool includeBlockedAids, out NSError error);

		[Export ("emvGetCommonAppList:error:")]
		EMVApplication[] EmvGetCommonAppList (out bool confirmationRequired, out NSError error);

		[Export ("emvInitialAppProcessing:error:")]
		bool EmvInitialAppProcessing (NSData aid, out NSError error);

		[Export ("emvReadAppData:error:")]
		bool EmvReadAppData (NSObject[] tags, out NSError error);

		[Export ("emvAuthentication:error:")]
		bool EmvAuthentication (bool checkAmount, out NSError error);

		[Export ("emvProcessRestrictions:")]
		bool EmvProcessRestrictions (out NSError error);

		[Export ("emvTerminalRisk:error:")]
		bool EmvTerminalRisk (bool forceProcessing, out NSError error);

		[Export ("emvGetAuthenticationMethod:")]
		bool EmvGetAuthenticationMethod (out NSError error);

		[Export ("emvSetAuthenticationResult:error:")]
		bool EmvSetAuthenticationResult (AuthResults result, out NSError error);

		[Export ("emvVerifyPinOffline:")]
		bool EmvVerifyPinOffline (out NSError error);

		[Export ("emvGenerateCertificate:risk:error:")]
		bool EmvGenerateCertificate (CertificateAcTypes type, CardRiskTypes risk, out NSError error);

		[Export ("emvMakeTransactionDecision:")]
		bool EmvMakeTransactionDecision (out NSError error);

		[Export ("emvMakeDefaultDecision:")]
		bool EmvMakeDefaultDecision (out NSError error);

		[Export ("emvAuthenticateIssuer:")]
		bool EmvAuthenticateIssuer (out NSError error);

		[Export ("emvScriptProcessing:error:")]
		bool EmvScriptProcessing (int type, out NSError error);

		[Export ("emvUpdateTVRByte:bit:value:error:")]
		bool EmvUpdateTvrByte (int byteToUpdate, int bit, int value, out NSError error);

		[Export ("emvUpdateTSIByte:bit:value:error:")]
		bool EmvUpdateTsiByte (int byteToUpdate, int bit, int value, out NSError error);

		[Export ("emvCheckTVRByte:bit:error:")]
		bool EmvCheckTvrByte (int byteNumber, int bit, out NSError error);

		[Export ("emvCheckTSIByte:bit:error:")]
		bool EmvCheckTsiByte (int byteNumber, int bit, out NSError error);

		[Export ("emvRemovePublicKey:RID:error:")]
		bool EmvRemovePublicKey (int caIndex, NSData rid, out NSError error);

		[Export ("emvSetDataAsBinary:data:error:")]
		bool EmvSetData (uint tagId, NSData data, out NSError error);

		[Export ("emvSetDataAsString:data:error:")]
		bool EmvSetData (uint tagId, string data, out NSError error);

		[Export ("emvGetDataAsBinary:error:")]
		NSData EmvGetDataAsBinary (uint tagId, out NSError error);

		[Export ("emvGetDataAsString:error:")]
		string EmvGetDataAsString (uint tagId, out NSError error);

		[Export ("emvGetDataDetails:tagType:maxLen:currentLen:error:")]
		bool EmvGetDataDetails (uint tagId, out TagTypes tagType, out int maxLen, out int currentLen, out NSError error);

		[Export ("emvSetBypassMode:error:")]
		bool EmvSetBypassMode (BypassModes mode, out NSError error);

		[Export ("emvSetTags:error:")]
		bool EmvSetTags (NSData tlv, out NSError error);

		[Export ("emvGetTags:error:")]
		NSData EmvGetTags (NSData tagList, out NSError error);

		[Export ("emvGetTagsEncrypted3DES:keyID:uniqueID:error:")]
		NSData EmvGetTagsEncrypted3DES (NSData tagList, int keyId, uint uniqueId, out NSError error);

		[Export ("emvGetTagsEncryptedDUKPT:keyID:uniqueID:error:")]
		NSData EmvGetTagsEncryptedDUKPT (NSData tagList, int keyId, uint uniqueId, out NSError error);

		[Export ("uiGetScreenInfoWidth:height:colorMode:error:")]
		bool UiGetScreenInfo (out int width, out int height, out ScreenColorModes colorMode, out NSError error);

		[Export ("uiDrawText:topLeftX:topLeftY:font:error:")]
		bool UiDrawText (string text, int topLeftX, int topLeftY, Fonts font, out NSError error);

		[Export ("uiFillRectangle:topLeftY:width:height:color:error:")]
		bool UiFillRectangle (int topLeftX, int topLeftY, int width, int height, UIColor color, out NSError error);

		[Export ("uiSetContrast:error:")]
		bool UiSetContrast (int contrast, out NSError error);

		[Export ("uiPutPixel:y:color:error:")]
		bool UiPutPixel (int x, int y, UIColor color, out NSError error);

		[Export ("uiDisplayImage:topLeftY:image:error:")]
		bool UiDisplayImage (int topLeftX, int topLeftY, UIImage image, out NSError error);

		[Export ("uiStartAnimation:topLeftX:topLeftY:animated:error:")]
		bool UiStartAnimation (Animations animationIndex, int topLeftX, int topLeftY, bool animated, out NSError error);

		[Export ("uiStopAnimation:error:")]
		bool UiStopAnimation (Animations animationIndex, out NSError error);

		[Export ("uiControlLEDsWithBitMask:error:")]
		bool UiControlLeds (uint mask, out NSError error);

		[Export ("uiEnableVibrationForTime:error:")]
		bool UiEnableVibration (float time, out NSError error);

		[Export ("uiEnableSpeaker:error:")]
		bool UiEnableSpeaker (bool enabled, out NSError error);

		[Export ("uiIsSpeakerEnabled:error:")]
		bool UiIsSpeakerEnabled (out bool enabled, out NSError error);

		[Export ("uiEnableSpeakerButton:error:")]
		bool UiEnableSpeakerButton (bool enabled, out NSError error);

		[Export ("uiIsSpeakerButtonEnabled:error:")]
		bool UiIsSpeakerButtonEnabled (out bool enabled, out NSError error);

		// -(BOOL)uiEnableSpeakerAutoControl:(BOOL)enabled error:(NSError **)error;
		[Export ("uiEnableSpeakerAutoControl:error:")]
		bool UiEnableSpeakerAutoControl (bool enabled, out NSError error);

		[Export ("uiIsSpeakerAutoControlEnabled:error:")]
		bool UiIsSpeakerAutoControlEnabled (out bool enabled, out NSError error);

		[Export ("uiDisplayWidth")]
		int UiDisplayWidth { get; }

		[Export ("uiDisplayHeight")]
		int UiDisplayHeight { get; }

		[Export ("uiDisplayAtBottom")]
		bool UiDisplayAtBottom { get; }

		[Export ("prnFlushCache:")]
		bool PrnFlushCache (out NSError error);

		[Export ("prnWriteDataToChannel:data:error:")]
		bool PrnWriteData (Channel channel, NSData data, out NSError error);

		[Export ("prnReadDataFromChannel:length:timeout:error:")]
		NSData PrnReadDataFromChannel (Channel channel, int length, double timeout, out NSError error);

		[Export ("prnWaitPrintJob:error:")]
		bool PrnWaitPrintJob (double timeout, out NSError error);

		[Export ("prnGetPrinterStatus:error:")]
		bool PrnGetPrinterStatus (out int status, out NSError error);

		[Export ("prnSelfTest:error:")]
		bool PrnSelfTest (bool longtest, out NSError error);

		[Export ("prnTurnOff:")]
		bool PrnTurnOff (out NSError error);

		[Export ("prnFeedPaper:error:")]
		bool PrnFeedPaper (int lines, out NSError error);

		[Export ("prnPrintBarcode:barcode:error:")]
		bool PrnPrintBarcode (PrintBarcodeType bartype, [NullAllowed] NSData barcode, out NSError error);

		[Export ("prnPrintBarcodePDF417:truncated:autoEncoding:eccl:size:error:")]
		bool PrnPrintBarcodePdf417 (NSData barcode, bool truncated, bool autoEncoding, Pdf417Eccl eccl, Pdf417Size size, out NSError error);

		[Export ("prnPrintBarcodeQRCode:eccl:size:error:")]
		bool PrnPrintBarcodeQRCode (NSData barcode, QrcodeEccl eccl, QrcodeSize size, out NSError error);

		[Export ("prnPrintLogo:error:")]
		bool PrnPrintLogo (LogoMode mode, out NSError error);

		[Export ("prnSetBarcodeSettings:height:hriPosition:align:error:")]
		bool PrnSetBarcodeSettings (int scale, int height, BarTextPosition hriPosition, BarTextAlign align, out NSError error);

		[Export ("prnSetDensity:error:")]
		bool PrnSetDensity (int percent, out NSError error);

		[Export ("prnSetLineSpace:error:")]
		bool PrnSetLineSpace (int lineSpace, out NSError error);

		[Export ("prnSetLeftMargin:error:")]
		bool PrnSetLeftMargin (int leftMargin, out NSError error);

		[Export ("prnPrintText:usingEncoding:error:")]
		bool PrnPrintText (string textString, NSStringEncoding encoding, out NSError error);

		[Export ("prnPrintText:error:")]
		bool PrnPrintText (string textString, out NSError error);

		[Export ("prnSetCodepage:error:")]
		bool PrnSetCodepage (int codepage, out NSError error);

		[Export ("prnPrintDelimiter:error:")]
		bool PrnPrintDelimiter (sbyte delimchar, out NSError error);

		[Export ("prnGetBlackMarkTreshold:error:")]
		bool PrnGetBlackMarkTreshold (out int treshold, out NSError error);

		[Export ("prnSetBlackMarkTreshold:error:")]
		bool PrnSetBlackMarkTreshold (int treshold, out NSError error);

		[Export ("prnCalibrateBlackMark:error:")]
		bool PrnCalibrateBlackMark (out int treshold, out NSError error);

		[Export ("prnLoadLogo:align:error:")]
		bool PrnLoadLogo (UIImage logo, BarTextAlign align, out NSError error);

		[Export ("prnPrintImage:align:error:")]
		bool PrnPrintImage (UIImage image, BarTextAlign align, out NSError error);

		[Export ("pageIsSupported")]
		bool PageIsSupported { get; }

		[Export ("pageStart:")]
		bool PageStart (out NSError error);

		[Export ("pagePrint:")]
		bool PagePrint (out NSError error);

		[Export ("pageEnd:")]
		bool PageEnd (out NSError error);

		[Export ("pageSetWorkingArea:top:width:height:error:")]
		bool PageSetWorkingArea (int left, int top, int width, int height, out NSError error);

		[Export ("pageSetWorkingArea:top:width:heigth:orientation:error:")]
		bool PageSetWorkingArea (int left, int top, int width, int height, PageOrientation orientation, out NSError error);

		[Export ("pageFillRectangle:error:")]
		bool PageFillRectangle (UIColor color, out NSError error);

		[Export ("pageFillRectangle:top:width:height:color:error:")]
		bool PageFillRectangle (int left, int top, int width, int height, UIColor color, out NSError error);

		[Export ("pageRectangleFrame:top:width:height:framewidth:color:error:")]
		bool PageRectangleFrame (int left, int top, int width, int height, int framewidth, UIColor color, out NSError error);

		[Export ("pageSetRelativePositionLeft:top:error:")]
		bool PageSetRelativePositionLeft (int left, int top, out NSError error);

		[Export ("tableIsSupported")]
		bool TableIsSupported { get; }

		[Export ("tableCreate:error:")]
		bool TableCreate (Tableborders flags, out NSError error);

		[Export ("tableCreate:")]
		bool TableCreate (out NSError error);

		[Export ("tableAddColumn:")]
		bool TableAddColumn (out NSError error);

		[Export ("tableAddColumn:error:")]
		bool TableAddColumn (Fonts font, out NSError error);

		[Export ("tableAddColumn:style:alignment:error:")]
		bool TableAddColumn (Fonts font, int style, BarTextAlign alignment, out NSError error);

		[Export ("tableAddColumn:style:alignment:flags:error:")]
		bool TableAddColumn (Fonts font, int style, BarTextAlign alignment, Tableborders tableborders, out NSError error);

		[Export ("tableAddCell:error:")]
		bool TableAddCell (string data, out NSError error);

		[Export ("tableAddCell:font:error:")]
		bool TableAddCell (string data, Fonts font, out NSError error);

		[Export ("tableAddCell:font:style:error:")]
		bool TableAddCell (string data, Fonts font, int style, out NSError error);

		[Export ("tableAddCell:font:style:alignment:error:")]
		bool TableAddCell (string data, Fonts font, int style, BarTextAlign alignment, out NSError error);

		[Export ("tableAddDelimiter:")]
		bool TableAddDelimiter (out NSError error);

		[Export ("tableSetRowHeight:error:")]
		bool TableSetRowHeight (int height, out NSError error);

		[Export ("tablePrint:")]
		bool TablePrint (out NSError error);

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		ILineaDelegate Delegate { get; set; }

		[Export ("delegates", ArgumentSemantic.Assign)][NullAllowed]
		ILineaDelegate[] Delegates { get; }

		[Export ("connectionType")]
		DeviceConnectionType ConnectionType { get; }

		[Export ("connstate")]
		ConnStates Connstate { get; }

		[Export ("deviceName")]
		string DeviceName { get; }

		[Export ("deviceModel")]
		string DeviceModel { get; }

		[Export ("firmwareRevision")]
		string FirmwareRevision { get; }

		[Export ("firmwareRevisionNumber")]
		int FirmwareRevisionNumber { get; }

		[Export ("hardwareRevision")]
		string HardwareRevision { get; }

		[Export ("serialNumber")]
		string SerialNumber { get; }

		[Export ("sdkVersion")]
		int SdkVersion { get; }

		[Export ("sdkBuildDate")]
		NSDate SdkBuildDate { get; }

		[Export ("emvLastStatus")]
		short EmvLastStatus { get; }
	}
}

