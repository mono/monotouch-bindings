using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreBluetooth;

namespace LineaProSdk
{
	[BaseType(typeof(NSObject))]
	interface DTPinpadInfo{
		[Export("cpuSerial", ArgumentSemantic.Copy)]
		NSData CpuSerial { get; set; }

		[Export("cpuVersion", ArgumentSemantic.Assign)]
		UInt32 CpuVersion { get; set; }

		[Export("cpuLoaderVersion", ArgumentSemantic.Assign)]
		UInt32 CpuLoaderVersion { get; set; }

		[Export("cpuHALVersion", ArgumentSemantic.Assign)]
		UInt32 CpuHalVersion { get; set; }

		[Export("pinpadSerial", ArgumentSemantic.Copy)]
		NSData PinpadSerial { get; set; }

		[Export("loaderName", ArgumentSemantic.Copy)]
		string LoaderName { get; set; }

		[Export("loaderVersion", ArgumentSemantic.Assign)]
		UInt32 LoaderVersion { get; set; }

		[Export("fwName", ArgumentSemantic.Copy)]
		string FirmwareName { get; set; }

		[Export("fwVersion", ArgumentSemantic.Assign)]
		UInt32 FirmwareVersion { get; set; }

	}

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
	interface DTEMV2Info {

		[Export ("configurationVersion", ArgumentSemantic.Assign)]
		int ConfigurationVersion { get; set; }

		[Export ("emvKernelVersion", ArgumentSemantic.Assign)]
		int EmvKernelVersion { get; set; }

	}

	[BaseType(typeof(NSObject))]
	interface DTBatteryInfo{
		[Export("voltage", ArgumentSemantic.Assign)]
		float Voltage { get; set; }

		[Export("capacity", ArgumentSemantic.Assign)]
		int Capacity { get; set; }

		[Export("health", ArgumentSemantic.Assign)]
		int Health { get; set; }

		[Export("maximumCapacity", ArgumentSemantic.Assign)]
		int MaximumCapacity { get; set; }

		[Export("charging", ArgumentSemantic.Assign)]
		bool IsCharging { get; set; }

		[Export("batteryChipType", ArgumentSemantic.Assign)]
		BatteryChips BatteryChipType { get; set; }

		[Export("extendedInfo", ArgumentSemantic.Copy)]
		NSDictionary ExtendedInfo { get; set; }
	}

	[BaseType(typeof(NSObject))]
	interface DTVoltageInfo
	{
		[Export("keyGenerated", ArgumentSemantic.Assign)]
		bool IsKeyGenerated { get; set; }

		[Export("keyGenerationInProgress", ArgumentSemantic.Assign)]
		bool IsKeyGenerationInProgress { get; set; }

		[Export("keyGenerationDate", ArgumentSemantic.Copy)]
		NSDate KeyGenerationDate { get; set; }

		[Export("settingsVersion", ArgumentSemantic.Assign)]
		int SettingsVersion { get; set; }
	}


	[BaseType(typeof(NSObject))]
	interface EMSRDeviceInfo
	{
		[Export("ident", ArgumentSemantic.Copy)]
		string Identification { get; set; }

		[Export("serialNumber", ArgumentSemantic.Copy)]
		NSData SerialNumber { get; set; }

		[Export("serialNumberString", ArgumentSemantic.Copy)]
		string SerialNumberString { get; set; }

		[Export("firmwareVersion", ArgumentSemantic.Assign)]
		int FirmwareVersion { get; set; }

		[Export("firmwareVersionString", ArgumentSemantic.Copy)]
		string FirmwareVersionString { get; set; }

		[Export("securityVersion", ArgumentSemantic.Assign)]
		int SecurityVersion { get; set; }

		[Export("securityVersionString", ArgumentSemantic.Copy)]
		string SecurityVersionString { get; set; }
	}

	[BaseType(typeof(NSObject))]
	interface EMSRKey
	{
		[Export("keyID", ArgumentSemantic.Assign)]
		int KeyId { get; set; }

		[Export("keyVersion", ArgumentSemantic.Assign)]
		int KeyVersion { get; set; }

		[Export("keyName", ArgumentSemantic.Copy)]
		string KeyName { get; set; }
	}


	[BaseType(typeof(NSObject))]
	interface EMSRKeysInfo
	{
		[Static, Export("keyNameByID:")]
		string KeyNameById(int keyId);

		[Export("keys", ArgumentSemantic.Copy)]
		EMSRKey[] Keys { get; set; }

		[Export("tampered", ArgumentSemantic.Assign)]
		bool IsHeadTampered { get; set; }

		[Export("getKeyVersion:")]
		int GetKeyVersion(int keyId);

	}

	[BaseType(typeof(NSObject))]
	interface DTDeviceInfo
	{
		[Export("deviceType", ArgumentSemantic.Assign)]
		SupportedDeviceTypes DeviceType { get; set; }

		[Export("connectionType", ArgumentSemantic.Assign)]
		DeviceConnectionType ConnectionType { get; set; }

		[Export("name", ArgumentSemantic.Copy)]
		string Name { get; set; }

		[Export("model", ArgumentSemantic.Copy)]
		string Model { get; set; }

		[Export("firmwareRevision", ArgumentSemantic.Copy)]
		string FirmwareRevision { get; set; }

		[Export("hardwareRevision", ArgumentSemantic.Copy)]
		string HardwareRevision { get; set; }

		[Export("serialNumber", ArgumentSemantic.Copy)]
		string SerialNumber { get; set; }
	}

	[BaseType(typeof(NSObject))]
	interface DTEMVApplication
	{
		[Export("aid", ArgumentSemantic.Copy)]
		NSData ApplicationAid { get; set; }

		[Export("label", ArgumentSemantic.Copy)]
		string Label { get; set; }

		[Export("matchCriteria", ArgumentSemantic.Assign)]
		AppMatchCriteria MatchCriteria { get; set; }

	}

	[BaseType(typeof(NSObject))]
	interface DTCAKeyInfo
	{
		[Export("keyIndex", ArgumentSemantic.Assign)]
		int KeyIndex { get; set; }

		[Export("RIDI", ArgumentSemantic.Copy)]
		NSData Ridi { get; set; }

		[Export("moduleLength", ArgumentSemantic.Assign)]
		int ModuleLength { get; set; }
	}

	[BaseType(typeof(NSObject))]
	interface DTKeyInfo
	{
		[Export("checkValue", ArgumentSemantic.Copy)]
		NSData CheckValue { get; set; }

		[Export("type", ArgumentSemantic.Assign)]
		int Type { get; set; }

		[Export("usage", ArgumentSemantic.Copy)]
		string Usage { get; set; }

		[Export("mode", ArgumentSemantic.Assign)]
		char Mode { get; set; }

		[Export("version", ArgumentSemantic.Assign)]
		int Version { get; set; }
	}

	[BaseType (typeof (NSObject))]
	[Protocol]
	[Model]
	interface DTDeviceDelegate {

		[Export ("connectionState:")]
		void ConnectionState (ConnStates state);

		[Export ("deviceButtonPressed:")]
		void ButtonPressed (int which);

		[Export ("deviceButtonReleased:")]
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

		[Export ("magneticCardEncryptedData:tracks:data:")]
		void MagneticCardEncryptedData(EncryptionAlgorithms encryption, int tracks, NSData data);

		[Export ("magneticCardEncryptedData:tracks:data:track1masked:track2masked:track3:")]
		void MagneticCardEncryptedData(EncryptionAlgorithms encryption, int tracks, NSData data, string track1masked, string track2masked, string track3);

		[Export ("magneticCardEncryptedData:tracks:data:track1masked:track2masked:track3:source:")]
		void MagneticCardEncryptedData(EncryptionAlgorithms encryption, int tracks, NSData data, string track1masked, string track2masked, string track3, int source);

		[Export("magneticCardRawData:")]
		void MagneticCardEncryptedRawData(NSData tracks);

		[Export ("magneticCardEncryptedRawData:data:")]
		void MagneticCardEncryptedRawData(EncryptionAlgorithms encryption, NSData data);

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

		[Export("deviceFeatureSupported:value:")]
		void DeviceFeatureSupported(Features feature, FeatureSupported value);

		[Export("smartCardInserted:")]
		void SmartCardInserted(ScSlots slot);

		[Export("smartCardRemoved:")]
		void SmartCardRemoved(ScSlots slot);

		[Export("PINEntryCompletedWithError:")]
		void PinEntryCompletedWithError(NSError error);

		[Export("paperStatus:")]
		void PaperStatus(bool isPresent);

		[Export("sdkDebug:source:")]
		void SdkDebugMessageLogged(string logText, int source);

		[Export ("emv2OnTransactionStarted")]
		void Emv2OnTransactionStarted ();

		[Export("emv2OnUserInterfaceCode:status:holdTime:")]
		void Emv2OnUserInterfaceUpdate(int code, int status, double holdTime);

		[Export ("emv2OnApplicationSelection:")]
		void Emv2OnApplicationSelection (string [] applications);

		[Export ("emv2OnOnlineProcessing:")]
		void Emv2OnOnlineProcessing (NSData data);

		[Export ("emv2OnTransactionFinished:")]
		void Emv2OnTransactionFinished (NSData data);

		[Export("bluetoothLEDeviceDiscovered:")]
		bool BluetoothLEDeviceDiscovered(CBPeripheral device);

		[Export("bluetoothLEDiscoverCompletedWithError:")]
		void BluetoothLEDiscoverCompletedWithError(NSError error);
	}

	[BaseType (typeof (NSObject))]
	interface DTDevices {

		[Static]
		[Export ("sharedDevice")]
		DTDevices SharedDevice { get; }

		[Export ("addDelegate:")]
		void AddDelegate (NSObject newDelegate);

		[Export ("removeDelegate:")]
		void RemoveDelegate (NSObject newDelegate);

		[Export ("connect")]
		void Connect ();

		[Export ("disconnect")]
		void Disconnect ();

		[Export("isPresent:")]
		bool GetDeviceIsPresent(SupportedDeviceTypes type);

		[Export("setActiveDeviceType:error:")]
		bool SetActiveDeviceType(SupportedDeviceTypes type, [NullAllowed] out NSError error);

		[Export ("getBatteryCapacity:voltage:error:")]
		bool GetBatteryCapacity (out int capacity, out float voltage, out NSError error);

		[Export ("setAutoOffWhenIdle:whenDisconnected:error:")]
		bool SetAutoOffWhenIdle (double timeIdle, double timeDisconnected, out NSError error);

		[Export("getBatteryInfo:")]
		DTBatteryInfo GetBatteryInfo([NullAllowed] out NSError error);

		[Export("setBatteryMaxCapacity:error:")]
		bool SetBatteryMaxCapacity(int capacity, [NullAllowed] out NSError error);

		[Export("getConnectedDevicesInfo:")]
		DTDeviceInfo[] GetConnectedDevicesInfo([NullAllowed] out NSError error);

		[Export("getConnectedDeviceInfo:error:")]
		DTDeviceInfo GetConnectedDeviceInfo(SupportedDeviceTypes device, [NullAllowed] out NSError error);


		[Internal]
		[Export("playSound:beepData:length:error:")]
		bool PlaySound_ (int volume, IntPtr data, int length, out NSError error);

		[Export("setKioskMode:error:")]
		bool SetKioskMode(bool enabled, [NullAllowed]out NSError error);

		[Export("getKioskMode:error:")]
		bool GetKioskMode(out bool enabled, [NullAllowed]out NSError error);

		[Export ("getCharging:error:")]
		bool GetCharging (out bool charging, out NSError error);

		[Export ("setCharging:error:")]
		bool SetCharging (bool enabled, out NSError error);

		[Export ("getPassThroughSync:error:")]
		bool GetPassThroughSync (out bool enabled, out NSError error);

		[Export ("setPassThroughSync:error:")]
		bool SetPassThroughSync (bool enabled, out NSError error);

		[Export("getUSBChargeCurrent:error:")]
		bool GetUSBChargeCurrent(out int current, out NSError error);

		[Export("setUSBChargeCurrent:error:")]
		bool SetUSBChargeCurrent(int current, out NSError error);

		[Export("getFirmwareFileInformation:error:")]
		NSDictionary GetFirmwareFileInformation(NSData data, out NSError error);

		[Export("updateFirmwareData:error:")]
		bool UpdateFirmwareData(NSData data, out NSError error);

		[Export("getSupportedFeature:error:")]
		FeatureSupported GetSupportedFeature(Features feature, out NSError error);

		[Export("getTimeRemainingToPowerOff:error:")]
		bool GetTimeRemainingToPowerOff(double timeRemaining, out NSError error);

		[Export("sysSaveSettingsToFlash:")]
		bool SysSaveSettingsToFlash([NullAllowed] out NSError error);

		[Export ("msEnable:")]
		bool MsEnable (out NSError error);

		[Export ("msDisable:")]
		bool MsDisable (out NSError error);

		[Export ("msProcessFinancialCard:track2:")]
		NSDictionary MsProcessFinancialCard (string track1, string track2);

		[Export ("msSetCardDataMode:error:")]
		bool MsSetCardDataMode (int mode, out NSError error);



		[Export ("barcodeType2Text:")]
		string BarcodeType2Text (int barcodeType);

		[Export ("barcodeStartScan:")]
		bool BarcodeStartScan (out NSError error);

		[Export ("barcodeStopScan:")]
		bool BarcodeStopScan (out NSError error);

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

		[Export ("barcodeGetTypeMode:error:")]
		bool BarcodeGetTypeMode (out int mode, out NSError error);

		[Export ("barcodeSetTypeMode:error:")]
		bool BarcodeSetTypeMode (int mode, out NSError error);

		[Export ("barcodeEngineResetToDefaults:")]
		bool BarcodeEngineResetToDefaults (out NSError error);

		[Export("barcodeEngineCheckReady:error:")]
		bool BarcodeEngineCheckReady(out bool ready, [NullAllowed] out NSError error);

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



		[Export("btDiscoverSupportedDevicesInBackground:maxTime:filter:error:")]
		bool BtDiscoverSupportedDevicesInBackground(int maxDevices, double maxTime, int filter, out NSError error);

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
		bool BtConnect (string address, string pin, out NSError error);

		[Export ("btDisconnect:error:")]
		bool BtDisconnect (string address, out NSError error);

		[Export ("btConnectSupportedDevice:pin:error:")]
		bool BtConnectSupportedDevice (string address, string pin, out NSError error);

		[Export ("btWrite:length:error:")] [Internal]
		bool BtWrite_ (IntPtr data, int length, out NSError error);

		[Export ("btWrite:error:")]
		bool BtWrite (string data, out NSError error);

		[Export ("btRead:length:timeout:error:")] [Internal]
		int BtRead_ (ref IntPtr data, int length, double timeout, out NSError error);

		[Export ("btReadLine:error:")]
		string BtReadLine (double timeout, out NSError error);

		[Export ("btEnableWriteCaching:error:")]
		bool BtEnableWriteCaching (bool enabled, out NSError error);

		[Export ("btDiscoverDevices:maxTime:codTypes:error:")]
		string [] BtDiscoverDevices (int maxDevices, double maxTime, int codTypes, out NSError error);

		[Export ("btGetDeviceName:error:")]
		string BtGetDeviceName (string address, out NSError error);

		[Export ("btSetDataNotificationMaxTime:maxLength:sequenceData:error:")]
		bool BtSetDataNotificationMaxTime (double maxTime, int maxLength, NSData sequenceData, out NSError error);

		[Export ("btListenForDevices:discoverable:localName:cod:error:")]
		bool BtListenForDevices (bool enabled, bool discoverable, string localName, uint cod, out NSError error);

		[Export ("btGetLocalAddress:")]
		string BtGetLocalAddress (out NSError error);

		[Export ("btSetMicGain:error:")]
		bool BtSetMicGain (int gain, out NSError error);
//
//		#ifdef BTLE
//-(NSArray *)btleDiscoverSupportedDevices:(int)filter stopOnFound:(BOOL)stopOnFound error:(NSError **)error;
//-(BOOL)btleDiscoverStop;
//-(BOOL)btleConnectToDevice:(CBPeripheral *)aPeripheral error:(NSError **)error;
//#endif
		[Export ("btConnectedDevices")]
		string[] BtConnectedDeviceAddresses { get; }


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



		[Export ("tcpConnectSupportedDevice:error:")]
		bool TcpConnectSupportedDevice (string address, out NSError error);

		[Export ("tcpDisconnect:error:")]
		bool TcpDisconnect (string address, out NSError error);

		[Export ("tcpConnectedDevices")]
		string[] TcpConnectedDeviceAddresses { get; }



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



		[Export ("emsrSetActiveHead:error:")]
		bool EmsrSetActivated (int active, out NSError error);

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
		bool EmsrSetEncryption(EncryptionAlgorithms encryption, NSDictionary parameters, out NSError error);

		[Export ("emsrSetEncryption:keyID:params:error:")]
		bool EmsrSetEncryption(EncryptionAlgorithms encryption, int keyId, NSDictionary parameters, out NSError error);

		[Export ("emsrConfigMaskedDataShowExpiration:unmaskedDigitsAtStart:unmaskedDigitsAtEnd:error:")]
		bool EmsrConfigMaskedDataShowExpiration (bool showExpiration, int unmaskedDigitsAtStart, int unmaskedDigitsAtEnd, out NSError error);

		[Export ("emsrConfigMaskedDataShowExpiration:unmaskedDigitsAtStart:unmaskedDigitsAtEnd:unmaskedDigitsAfter:error:")]
		bool EmsrConfigMaskedDataShowExpiration (bool showExpiration, int unmaskedDigitsAtStart, int unmaskedDigitsAtEnd, int unmaskedDigitsAfter, out NSError error);

		[Export ("emsrLoadRSAKeyPEM:version:error:")]
		bool EmsrLoadRsaKeyPem (string pem, int version, out NSError error);

		[Export ("emsrGetDeviceInfo:")]
		EMSRDeviceInfo EmsrGetDeviceInfo (out NSError error);

		[Export ("emsrGetKeysInfo:")]
		EMSRKeysInfo EmsrGetKeysInfo (out NSError error);



		[Export ("voltageGetInfo:")]
		DTVoltageInfo VoltageGetInfo (out NSError error);

		[Export ("voltageLoadConfiguration:error:")]
		bool VoltageLoadConfiguration (NSData configuration, out NSError error);

		[Export ("voltageGenerateNewKey:")]
		bool VoltageGenerateNewKey (out NSError error);

		[Export ("voltageSetMerchantID:error:")]
		bool VoltageSetMerchantId (string merchantId, out NSError error);

		[Export ("voltageSetPublicParameters:error:"), Obsolete]
		bool VoltageSetPublicParameters (NSData publicParameters, out NSError error);

		[Export ("voltageSetIdentityString:error:"), Obsolete]
		bool VoltageSetIdentityString (string identity, out NSError error);

		[Export ("voltageSetEncryptionType:error:"), Obsolete]
		bool VoltageSetEncryptionType (int type, out NSError error);

		[Export ("voltageSetSettingsVersion:error:"), Obsolete]
		bool VoltageSetSettingsVersion (int version, out NSError error);

		[Export ("voltageSetKeyRolloverDays:numberOfTransactions:error:"), Obsolete]
		bool VoltageSetKeyRollover (int days, int numberOfTransactions, out NSError error);



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

		[Export ("iso14BTranscieve:data:error:")]
		NSData Iso14BTTranscieve (int cardIndex, NSData data, out NSError error);

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


		// START of items that may not need to be exposed.  They had no comments in the original
		// .h file, which makes me wonder if they are meant to be internal.

		[Export("hidGetVersionInfo:")]
		NSData HidGetVersionInfo (out NSError error);

		[Export("hidGetSerialNumber:")]
		NSData HidGetSerialNumber (out NSError error);

		[Export("hidGetContentElement:pin:rootSoOID:error:")]
		NSData HidGetGetContentElement (int contentTag, NSData pin, NSData rootSoOid, out NSError error);

		// END of items that may not need to be exposed.  They had no comments in the original



		[Export("scInit:error:")]
		bool ScInit (ScSlots slot, [NullAllowed]out NSError error);

		[Export("scCardPowerOn:error:")]
		NSData ScCardPowerOn (ScSlots slot, [NullAllowed]out NSError error);

		[Export("scCardPowerOff:error:")]
		bool ScCardPowerOff (ScSlots slot, [NullAllowed]out NSError error);

		[Export("scIsCardPresent:error:")]
		bool ScIsCardPresent (ScSlots slot, [NullAllowed]out NSError error);

		[Export("scCAPDU:apdu:error:")]
		NSData ScCApdu (ScSlots slot, NSData apdu, [NullAllowed]out NSError error);

		[Export("scClose:error:")]
		bool ScClose (ScSlots slot, [NullAllowed]out NSError error);
	


		[Export("ppadPINEntry:startY:timeout:echoChar:message:error:")]
		bool PPadPINEntry (int startX, int startY, int timeout, char echoChar, string message, [NullAllowed]out NSError error);

		[Export("ppadStartPINEntry:startY:timeout:echoChar:message:error:")]
		bool PPadStartPINEntry (int startX, int startY, int timeout, char echoChar, string message, [NullAllowed]out NSError error);

		[Export("ppadCancelPINEntry:")]
		bool PPadCancelPINEntry ([NullAllowed]out NSError error);

		[Export("ppadMagneticCardEntry:timeout:error:")]
		bool PPadMagneticCardEntry (Languages language, int timeout, [NullAllowed]out NSError error);

		[Export("ppadGetPINBlockUsingFixedKey:keyVariant:pinFormat:error:")]
		NSData PPadGetPINBlockUsingFixedKey (int fixedKeyId, NSData keyVariant, PinEncryptionFormats pinFormat, [NullAllowed]out NSError error);

		[Export("ppadGetPINBlockUsingDUKPT:keyVariant:pinFormat:error:")]
		NSData PPadGetPINBlockUsingDUKPT (int dukptKeyId, NSData keyVariant, PinEncryptionFormats pinFormat, [NullAllowed]out NSError error);

		[Export("ppadGetPINBlockUsingMasterSession:fixedKeyId:pinFormat:error:")]
		NSData PPadGetPINBlockUsingMasterSession (NSData sessionKey, int fixedKeyId, PinEncryptionFormats pinFormat, [NullAllowed]out NSError error);

		[Export("ppadGetKeyInfo:error:")]
		DTKeyInfo PPadGetKeyInfo (int keyId, [NullAllowed]out NSError error);

		[Export("ppadGetDUKPTKeyKSN:error:")]
		NSData PPadGetDUKPTKeyKSN (int keyId, out NSError error);

		[Export("ppadCryptoExchangeKeyID:kekId:usage:version:data:cbc:error:")]
		NSData PPadCryptoExchangeKeyId (int keyId, int kekId, int usage, int version, NSData data, bool cbc, [NullAllowed]out NSError error);

		[Export("ppadCryptoTR31ExchangeKeyID:kekId:tr31:error:")]
		NSData PPadCryptoTR31ExchangeKeyId (int keyId, int kekId, string tr31, [NullAllowed]out NSError error);

		[Export("ppadCrypto3DESECBEncryptKeyID:inData:error:")]
		NSData PPadCrypto3DESECBEncryptKeyId (int keyId, NSData inData, [NullAllowed]out NSError error);

		[Export("ppadCrypto3DESECBDecryptKeyID:inData:error:")]
		NSData PPadCrypto3DESECBDecryptKeyId (int keyId, NSData inData, [NullAllowed]out NSError error);

		[Export("ppadCrypto3DESCBCEncryptKeyID:initVector:inData:error:")]
		NSData PPadCrypto3DESCBCEncryptKeyId (int keyId, NSData initVector, NSData inData, [NullAllowed]out NSError error);

		[Export("ppadCrypto3DESCBCDecryptKeyID:initVector:inData:error:")]
		NSData PPadCrypto3DESCBCDecryptKeyId (int keyId, NSData initVector, NSData inData, [NullAllowed]out NSError error);

		[Export("ppadCryptoDelete3DESKeyID:error:")]
		bool PPadCryptoDelete3DESKeyId (int keyId, [NullAllowed]out NSError error);

		[Export("ppadSetButtonCaption:caption:error:")]
		bool PPadSetButtonCaption (int buttonIndex, string caption, [NullAllowed]out NSError error);

		[Export("ppadGetSystemInfo:")]
		DTPinpadInfo PPadGetSystemInfo ( [NullAllowed]out NSError error);

		[Export("ppadKeyboardControl:error:")]
		bool PPadKeyboardControl (bool capture, [NullAllowed]out NSError error);

		[Export("ppadReadKey:error:")]
		bool PPadReadKey (char key, [NullAllowed]out NSError error);



		[Export("caImportKeyNumber:RIDI:module:exponent:error:")]
		bool CaImportKeyNumber (int keyNumber, NSData ridi, NSData module, NSData exponent, [NullAllowed]out NSError error);

		[Export("caWriteKeysToFlash:")]
		bool CaWriteKeysToFlash ([NullAllowed]out NSError error);

		[Export("caGetKeysData:")]
		NSArray CaGetKeysData ([NullAllowed]out NSError error);

		[Export("caImportIssuerKeyNumber:exponent:remainder:certificate:error:")]
		NSData CaImportIssuerKeyNumber (int keyNumber, NSData exponent, NSData remainder, NSData certificate, [NullAllowed]out NSError error);

		[Export("caImportICCKeyType:exponent:remainder:certificate:error:")]
		NSData CaImportICCKeyType (IccTypes keyType, NSData exponent, NSData remainder, NSData certificate, [NullAllowed]out NSError error);

		[Export("caRSAVerify:inData:error:")]
		NSData CaRSAVerify (RsaVerifyKey keyType, NSData inData, [NullAllowed]out NSError error);



		[Export ("emv2Initialise:")]
		bool Emv2Initialise ([NullAllowed]out NSError error);

		[Export ("emv2Deinitialise:")]
		bool Emv2Deinitialise ([NullAllowed]out NSError error);

		[Export ("emv2SetCardEmulationMode:encryption:keyID:error:")]
		bool Emv2SetCardEmulationMode (bool enabled, EncryptionAlgorithms encryption, EncryptionKeys keyId, [NullAllowed]out NSError error);

		[Export ("emv2LoadConfigurationData:error:")]
		bool Emv2LoadConfigurationData (NSData data, out NSError error);

		[Export ("emv2GetInfo:")]
		DTEMV2Info Emv2GetInfo (out NSError error);

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

		[Export ("emv2GetCardTracksEncryptedWithFormat:keyID:error:")]
		NSData Emv2GetCardTracksEncryptedWithFormat (EncryptionAlgorithms format, EncryptionKeys keyId, [NullAllowed]out NSError error);

		[Export ("emv2GetTagsEncrypted:format:keyID:error:")]
		NSData Emv2GetTagsEncrypted (NSData tagList, int format, EncryptionKeys keyId, [NullAllowed]out NSError error);

		[Export ("emv2GetTagsPlain:error:")]
		NSData Emv2GetTagsPlain (NSData tagList, [NullAllowed]out NSError error);



		[Export ("emvInitialise:")]
	 	bool EmvInitialise ([NullAllowed]out NSError error);

		[Export ("emvDeinitialise:")]
		bool EmvDeinitialise ([NullAllowed]out NSError error);

		[Export ("emvATRValidation:warmReset:error:")]
		bool EmvATRValidation (NSData atr, bool warmReset, [NullAllowed]out NSError error);

		[Export ("emvLoadAppList:selectionMethod:includeBlockedAIDs:error:")]
		bool EmvLoadAppList (DTEMVApplication[] appList, AppSelectionMethods selectionMethod, bool includeBlockedAIDs, [NullAllowed]out NSError error);

		[Export ("emvGetCommonAppList:error:")]
		DTEMVApplication[] EmvGetCommonAppList (bool confirmationRequired, [NullAllowed]out NSError error);

		[Export ("emvInitialAppProcessing:error:")]
		bool EmvInitialAppProcessing (NSData aid, [NullAllowed]out NSError error);

		[Export ("emvReadAppData:error:")]
		bool EmvReadAppData (NSArray tags, [NullAllowed]out NSError error);

		[Export ("emvAuthentication:error:")]
		bool EmvAuthentication (bool checkAmount, [NullAllowed]out NSError error);

		[Export ("emvProcessRestrictions:")]
		bool EmvProcessRestrictions ([NullAllowed]out NSError error);

		[Export ("emvTerminalRisk:error:")]
		bool EmvTerminalRisk (bool forceProcessing, [NullAllowed]out NSError error);

		[Export ("emvGetAuthenticationMethod:")]
		bool EmvGetAuthenticationMethod ([NullAllowed]out NSError error);

		[Export ("emvSetAuthenticationResult:error:")]
		bool EmvSetAuthenticationResult (AuthorizationResults result, [NullAllowed]out NSError error);

		[Export ("emvVerifyPinOffline:")]
		bool EmvVerifyPinOffline ([NullAllowed]out NSError error);

		[Export ("emvGenerateCertificate:risk:error:")]
		bool EmvGenerateCertificate (CertificateAcTypes type, CardRiskTypes risk, [NullAllowed]out NSError error);

		[Export ("emvMakeTransactionDecision:")]
		bool EmvMakeTransactionDecision ([NullAllowed]out NSError error);

		[Export ("emvMakeDefaultDecision:")]
		bool EmvMakeDefaultDecision ([NullAllowed]out NSError error);



		[Export ("emvAuthenticateIssuer:")]
		bool EmvAuthenticateIssuer ([NullAllowed]out NSError error);

		[Export ("emvScriptProcessing:error:")]
		bool EmvScriptProcessing (ScriptTypes type, [NullAllowed]out NSError error);

		[Export ("emvUpdateTVRByte:bit:value:error:")]
		bool EmvUpdateTVRByte (int byteNumber, int bitNumber, int value, [NullAllowed]out NSError error);

		[Export ("emvUpdateTSIByte:bit:value:error:")]
		bool EmvUpdateTSIByte (int byteNumber, int bitNumber, int value, [NullAllowed]out NSError error);

		[Export ("emvCheckTVRByte:bit:error:")]
		bool EmvCheckTVRByte (int byteNumber, int bitNumber, [NullAllowed]out NSError error);

		[Export ("emvCheckTSIByte:bit:error:")]
		bool EmvCheckTSIByte (int byteNumber, int bitNumber, [NullAllowed]out NSError error);

		[Export ("emvRemovePublicKey:RID:error:")]
		bool EmvRemovePublicKey (int caIndex, NSData rid, [NullAllowed]out NSError error);


		[Export ("emvSetDataAsBinary:data:error:")]
		bool EmvSetDataAsBinary (PpEmvTags tagId, NSData data, [NullAllowed]out NSError error);

		[Export ("emvSetDataAsString:data:error:")]
		bool EmvSetDataAsString (PpEmvTags tagId, String data, [NullAllowed]out NSError error);

		[Export ("emvGetDataAsBinary:error:")]
		NSData EmvGetDataAsBinary (PpEmvTags tagId, [NullAllowed]out NSError error);

		[Export ("emvGetDataAsString:error:")]
		String EmvGetDataAsString (PpEmvTags tagId, [NullAllowed]out NSError error);

		[Export ("emvGetDataDetails:tagType:maxLen:currentLen:error:")]
		bool EmvGetDataDetails (PpEmvTags tagId, out TagTypes tagType, out int maxLength, out int currentLength, [NullAllowed]out NSError error);

		[Export ("emvSetBypassMode:error:")]
		bool EmvSetBypassMode (BypassModes mode, [NullAllowed]out NSError error);

		[Export ("emvSetTags:error:")]
		bool EmvSetTags (NSData tlv, [NullAllowed]out NSError error);

		[Export ("emvGetTags:error:")]
		NSData EmvGetTags (NSData tagList, [NullAllowed]out NSError error);

		[Export ("emvGetTagsEncrypted3DES:keyID:uniqueID:error:")]
		NSData EmvGetTagsEncrypted3DES (NSData tagList, int keyId, uint uniqueId, [NullAllowed]out NSError error);

		[Export ("emvGetTagsEncryptedDUKPT:keyID:uniqueID:error:")]
		NSData EmvGetTagsEncryptedDUKPT (NSData tagList, int keyId, uint uniqueId, [NullAllowed]out NSError error);


		[Export ("uiGetScreenInfoWidth:height:colorMode:error:")]
		bool UiGetScreenInfoWidth (out int width, out int height, out ScreenColorModes colorMode, [NullAllowed]out NSError error);

		[Export ("uiDrawText:topLeftX:topLeftY:fonts:error:")]
		bool UiDrawText (string text, int topLeftX, int topLeftY, Fonts font, [NullAllowed]out NSError error);

		[Export ("uiFillRectangle:topLeftY:width:height:color:error:")]
		bool UiFillRectangle (int topLeftX, int topLeftY, int width, int height, UIColor color, [NullAllowed]out NSError error);

		[Export ("uiSetContrast:error:")]
		bool UiSetContrast (int contrast, [NullAllowed]out NSError error);

		[Export ("uiPutPixel:y:color:error:")]
		bool UiPutPixel (int x, int y, UIColor color, [NullAllowed]out NSError error);

		[Export ("uiDisplayImage:topLeftY:image:error:")]
		bool UiDisplayImage (int topLeftX, int topLeftY, UIImage image, [NullAllowed]out NSError error);

		[Export ("uiStartAnimation:topLeftX:topLeftY:animated:error:")]
		bool UiStartAnimation (Animations animationIndex, int topLeftX, int topLeftY, bool animated, [NullAllowed]out NSError error);

		[Export ("uiStopAnimation:error:")]
		bool UiStopAnimation (Animations animationIndex, [NullAllowed]out NSError error);

		[Export ("uiControlLEDsWithBitMask:error:")]
		bool UiControlLEDsWithBitMask (UInt32 mask, [NullAllowed]out NSError error);

		[Export ("uiEnableVibrationForTime:error:")]
		bool UiEnableVibrationForTime (float time, [NullAllowed]out NSError error);

		[Export ("uiEnableSpeaker:error:")]
		bool UiEnableSpeaker (bool enabled, [NullAllowed]out NSError error);

		[Export ("uiIsSpeakerEnabled:error:")]
		bool UiIsSpeakerEnabled (out bool enabled, [NullAllowed]out NSError error);

		[Export ("uiDisplayWidth")]
		int UiDisplayWidth { get; }

		[Export ("uiDisplayHeight")]
		int UiDisplayHeight { get; }

		[Export ("uiDisplayAtBottom")]
		bool UiIsDisplayAtBottom { get; }



		[Export ("prnFlushCache:")]
		bool PrnFlushCache ([NullAllowed]out NSError error);

		[Export ("prnWriteDataToChannel:data:error:")]
		bool PrnWriteDataToChannel (Channels channel, NSData data, [NullAllowed]out NSError error);

		[Export ("prnReadDataFromChannel:length:timeout:error:")]
		NSData PrnReadDataFromChannel (Channels channel, int length, double timeout, [NullAllowed]out NSError error);

		[Export ("prnWaitPrintJob:error:")]
		bool PrnWaitPrintJob (double timeout, [NullAllowed]out NSError error);

		[Export ("prnGetPrinterStatus:error:")]
		bool PrnGetPrinterStatus (out int status, [NullAllowed]out NSError error);

		[Export ("prnSelfTest:error:")]
		bool PrnSelfTest (bool longTest, [NullAllowed]out NSError error);

		[Export ("prnTurnOff:")]
		bool PrnTurnOff ([NullAllowed]out NSError error);

		[Export ("prnFeedPaper:error:")]
		bool PrnFeedPaper (int lines, [NullAllowed]out NSError error);

		[Export ("prnPrintBarcode:barcode:error:")]
		bool PrnPrintBarcode (BarcodePrintingTypes barType, NSData barcode, [NullAllowed]out NSError error);

		[Export ("prnPrintBarcodePDF417:truncated:autoEncoding:eccl:size:error:")]
		bool PrnPrintBarcodePDF417 (NSData barcode, bool truncated, bool autoEncoding, Pdf417Eccl eccl, Pdf417Size size, [NullAllowed]out NSError error);

		[Export ("prnPrintBarcodeQRCode:eccl:size:error:")]
		bool PrnPrintBarcodeQRCode (NSData barcode, QRCodeEccl eccl, QRCodeSize size, [NullAllowed]out NSError error);

		[Export ("prnPrintLogo:error:")]
		bool PrnPrintLogo (PrintLogoSize mode, [NullAllowed]out NSError error);

		[Export ("prnSetBarcodeSettings:height:hriPosition:align:error:")]
		bool PrnSetBarcodeSettings (int scale, int height, BarcodeTextPosition hriPosition, Alignment alignment, [NullAllowed]out NSError error);

		[Export ("prnSetDensity:error:")]
		bool PrnSetDensity (int percent, [NullAllowed]out NSError error);

		[Export ("prnSetLineSpace:error:")]
		bool PrnSetLineSpace (int linespace, [NullAllowed]out NSError error);

		[Export ("prnSetLeftMargin:error:")]
		bool PrnSetLeftMargin (int leftMargin, [NullAllowed]out NSError error);

		[Export ("prnPrintText:usingEncoding:error:")]
		bool PrnPrintText (string text, NSStringEncoding encoding, [NullAllowed]out NSError error);

		[Export ("prnPrintText:error:")]
		bool PrnPrintText (string text, [NullAllowed]out NSError error);

		[Export ("prnSetCodepage:error:")]
		bool PrnSetCodepage (PrinterCodepages codepage, [NullAllowed]out NSError error);

		[Export ("prnPrintDelimiter:error:")]
		bool PrnPrintDelimiter (char delimiterChar, [NullAllowed]out NSError error);

		[Export ("prnGetBlackMarkTreshold:error:")]
		bool PrnGetBlackMarkTreshold (out int threshold, [NullAllowed]out NSError error);

		[Export ("prnSetBlackMarkTreshold:error:")]
		bool PrnSetBlackMarkTreshold (int threshold, [NullAllowed]out NSError error);

		[Export ("prnCalibrateBlackMark:error:")]
		bool PrnCalibrateBlackMark (out int threshold, [NullAllowed]out NSError error);

		[Export ("prnLoadLogo:align:error:")]
		bool PrnLoadLogo (UIImage logo, Alignment alignment, [NullAllowed]out NSError error);

		[Export ("prnPrintImage:align:error:")]
		bool PrnPrintImage (UIImage image, Alignment alignment, [NullAllowed]out NSError error);



		[Export ("pageIsSupported")]
		bool PageIsSupported ();

		[Export ("pageStart:")]
		bool pageStart ([NullAllowed]out NSError error);

		[Export ("pagePrint:")]
		bool PagePrint ([NullAllowed]out NSError error);

		[Export ("pageEnd:")]
		bool PageEnd ([NullAllowed]out NSError error);

		[Export ("pageSetWorkingArea:top:width:height:error:")]
		bool PageSetWorkingArea (int left, int top, int width, int height, [NullAllowed]out NSError error);

		[Export ("pageSetWorkingArea:top:width:height:orientation:error:")]
		bool PageSetWorkingArea (int left, int top, int width, int height, PageOrientation orientation, [NullAllowed]out NSError error);

		[Export ("pageFillRectangle:error:")]
		bool PageFillRectangle (UIColor color, [NullAllowed]out NSError error);

		[Export ("pageFillRectangle:top:width:height:color:error:")]
		bool PageFillRectangle (int left, int top, int width, int height, UIColor color, [NullAllowed]out NSError error);

		[Export("pageRectangleFrame:top:width:height:framewidth:color:error:")]
		bool PageRectangleFrame(int left, int top, int width, int height, int frameWidth, UIColor color, [NullAllowed]out NSError error);

		[Export ("pageSetRelativePositionLeft:top:error:")]
		bool PageSetRelativePositionLeft (int left, int top, [NullAllowed]out NSError error);



		[Export ("tableIsSupported")]
		bool TableIsSupported ();

		[Export ("tableCreate:error:")]
		bool TableCreate (TableFlags borderFlags, [NullAllowed]out NSError error);

		[Export ("tableCreate:")]
		bool TableCreate ([NullAllowed]out NSError error);

		[Export ("tableAddColumn:")]
		bool TableAddColumn ([NullAllowed]out NSError error);

		[Export ("tableAddColumn:error:")]
		bool TableAddColumn (Fonts font, [NullAllowed]out NSError error);

		[Export ("tableAddColumn:style:alignment:error:")]
		bool TableAddColumn (Fonts font, int style, Alignment alignment, [NullAllowed]out NSError error);

		[Export ("tableAddColumn:style:alignment:flags:error:")]
		bool TableAddColumn (Fonts font, int style, Alignment alignment, TableFlags borderFlags, [NullAllowed]out NSError error);

		[Export ("tableAddCell:error:")]
		bool TableAddCell (string data, [NullAllowed]out NSError error);

		[Export ("tableAddCell:font:error:")]
		bool TableAddCell (string data, Fonts font, [NullAllowed]out NSError error);

		[Export ("tableAddCell:font:style:error:")]
		bool TableAddCell (string data, Fonts font, int style, [NullAllowed]out NSError error);

		[Export ("tableAddCell:font:style:alignment:error:")]
		bool TableAddCell (string data, Fonts font, int style, Alignment alignment, [NullAllowed]out NSError error);

		[Export ("tableAddDelimiter:")]
		bool TableAddDelimiter ([NullAllowed]out NSError error);

		[Export ("tableSetRowHeight:error:")]
		bool TableSetRowHeight (int height, [NullAllowed]out NSError error);

		[Export ("tablePrint:")]
		bool TablePrint ([NullAllowed]out NSError error);



		[Wrap ("WeakDelegate")][NullAllowed]
		DTDeviceDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("delegates")]
		NSObject [] Delegates { get; }

		[Export ("connstate")]
		int Connstate { get; }

		[Export ("connectionType")]
		DeviceConnectionType ConnectionType { get; }

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
		PPEmvStatuses EmvLastStatus { get; }

	}
}

