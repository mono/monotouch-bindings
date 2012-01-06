namespace Redpark
{
	public enum DataSizeType
	{
		kDataSize7 = 0x07,
		kDataSize8 = 0x08
	}
	

	public enum ParityType
	{
		kParityNone = 0x00,
		kParityOdd = 0x01,
		kParityEven = 0x02
	}
	

	public enum StopBitsType
	{
		kStopBits1 = 0x01,
		kStopBits2 = 0x02
	}
	
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct SerialPortConfig
	{
		char  BaudLo,      // baud rate lo/hi up to 57600
		BaudHi;
		DataSizeType DataLen;		// SERIAL_DATABITS_ 7, 8
		ParityType Parity;			// SERIAL_PARITY_ NONE, ODD, EVEN  
		StopBitsType StopBits;         	// STOPBITS_ 1, 2       
		char txFlowControl,          // TXFLOW_
		rxFlowControl,          // RXFLOW_
		xonChar,                // XON/XOFF flow control chars if used
		xoffChar,       		 
				// RX forwarding parameters:
		rxForwardingTimeout,    // forward rx data when idle timeout reached 
		rxForwardCount,         // or received this many chars..
		txAckSetting,           // NON-zero if a txAck response is requested (sent when tx buffer becomes empty)
		returnStatus;  
	}
	
}