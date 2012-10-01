using System;

namespace Redpark
{
	
	public enum DataSizeType
	{
		Seven  = 0x07,
		Eight = 0x08
	}
	
	public enum ParityType
	{
		None = 0x00,
		Odd  = 0x01,
		Even = 0x02
	}
	
	public enum StopBitsType
	{
		One = 0x01,
		Two = 0x02
	}
	
	public struct rscMsgHdr
	{
		public byte hdr1;
		public byte hdr2;
		public byte len;			// of data following 'cmd'
		public byte cmd;
	}
	
	
	public struct serialPortStatus { 
		public byte  
		txDiscard,                      // non-zero if tx data msg from App discarded
		rxOverrun,	                // non-zero if overrun error occurred
		rxParity,			// non-zero if parity error occurred
		rxFrame,			// non-zero if frame error occurred
		txAck,				// ack when tx buffer becomes empty (sent only if txAxkSetting non-zero in config)
		msr,				// 0-3 current modem status bits for CTS, DSR, DCD & RI, 4-7 previous modem status bits, MODEM_STAT_
		rtsDtrState,			// 0-3 current modem status bits for RTS & DTR, 4-7 previous modem status bits, MODEM_STAT_
		rxFlowStat,			// rx flow control off= 0 on = RXFLOW_RTS/DTR/XOFF
		txFlowStat,			// rx flow control off= 0 on = TXFLOW_DCD/CTS/DSR/XOFF
		returnResponse;			// Non-zero if returned in response to config or control
		// message with returnStatus requested (non-zero). If non-zero the
		// value will equal the returnStatus byte.
	}

	public struct serialPortConfig { 
		public byte  baudLo,      // baud rate lo/hi up to 57600
		baudHi,
		dataLen,		// SERIAL_DATABITS_ 7, 8
		parity,			// SERIAL_PARITY_ NONE, ODD, EVEN  
		stopBits,         	// STOPBITS_ 1, 2       
		txFlowControl,          // TXFLOW_
		rxFlowControl,          // RXFLOW_
		xonChar,                // XON/XOFF flow control chars if used
		xoffChar,       		 
		// RX forwarding parameters:
		rxForwardingTimeout,    // forward rx data when idle timeout reached 
		rxForwardCount,         // or received this many chars..
		txAckSetting,           // NON-zero if a txAck response is requested (sent when tx buffer becomes empty)
		returnStatus;           // NON-zero if a status response (to this config message) is requested
	}
	
	public struct serialPortControl { 
		public byte txFlush,          // non-zero if tx buffer should be flushed
		rxFlush,                      // non-zero if rx buffer should be flushed
		setDtr,                       // change DTR state to..                       
		dtr,                          //   DTR state 1=On, 0=Off (ignored if setDtr == 0)
		setRts,                       // change RTS state to.. 
		rts,                          //   RTS state 1=On, 0=Off (ignored if setRts == 0)
		txBreak,                      // tx 'n' break characters
		returnStatus;                 // non-zero if a status response (to this control message) is requested
	}
	
}