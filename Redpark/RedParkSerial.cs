namespace Redpark {
	
	[BaseType (typeof (NSObject))]
	interface RscMgr {
		[Export ("setDelegate:delegate")]
		void SetDelegatee (RscMgrDelegate theDelegate );

		[Export ("init")]
		NSObject Init ();

		[Export ("open")]
		void Open ();

		[Export ("setBaud:")]
		void SetBaud (int baud);

		[Export ("setDataSize:")]
		void SetDataSize (DataSizeType dataSize);

		[Export ("setParity:")]
		void SetParity (ParityType parity);

		[Export ("setStopBits:")]
		void SetStopBits (StopBitsType stopBits);

		[Export ("write:Length:")]
		int Write (UInt8 data, UInt32 length);

		[Export ("read:Length:")]
		int Read (UInt8 data, UInt32 length);

		[Export ("getReadBytesAvailable")]
		int GetReadBytesAvailable ();

		[Export ("getModemStatus")]
		int GetModemStatus ();

		[Export ("getDtr")]
		bool GetDtr ();

		[Export ("getRts")]
		bool GetRts ();

		[Export ("setDtr:")]
		void SetDtr (bool enable);

		[Export ("setRts:")]
		void SetRts (bool enable);
		/*
		[Export ("setPortConfig:RequestStatus:")]
		void SetPortConfigRequestStatus (SerialPortConfig config, bool reqStatus);

		[Export ("setPortControl:RequestStatus:")]
		void SetPortControlRequestStatus (SerialPortConfig control, bool reqStatus);

		[Export ("getPortConfig:portConfig")]
		void GetPortConfig (SerialPortConfig config );

		[Export ("getPortStatus:portStatus")]
		void GetPortStatusport (serialPortStatus portStatus);
		 */
		[Export ("writeRscMessage:Length:MsgData:")]
		int WriteRsc (int cmd, int len, UInt8 msgData);

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface RscMgrDelegate {
		[Abstract]
		[Export ("cableConnected:")]
		void CableConnected (string protocol);

		[Abstract]
		[Export ("cableDisconnected")]
		void CableDisconnected ();

		[Abstract]
		[Export ("portStatusChanged")]
		void PortStatusChanged ();

		[Abstract]
		[Export ("readBytesAvailable:")]
		void ReadBytesAvailable (UInt32 length);

	}
	
}