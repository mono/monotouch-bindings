using System;
using LineaProSdk;

namespace LineaTest
{
	/// <summary>
	/// A class inheriting DTDeviceDelegate which invokes events after communicating with the LineaPro device.
	/// </summary>
	public class LineaDispatcher 
		: LineaDelegate
	{
		#region Delegates
		//Generic event handler for Linea event dispatching.
		public delegate void LineaEventHandler<T> (LineaDelegate Dispatcher, T Arguments) where T:LineaEventArgs;
		#endregion //Delegates

		#region Events		
		/// <summary>
		/// Occurs when the LineaPro scans a barcode.
		/// </summary>
		public event LineaEventHandler<BarcodeScannedEventArgs> BarcodeScanned;

		/// <summary>
		/// Occurs when the LineaPro connection state changes.
		/// </summary>
		public event LineaEventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged;

		/// <summary>
		/// Occurs when the LineaPro reads data from a swiped magcard.
		/// </summary>
		public event LineaEventHandler<MagcardReadEventArgs> MagcardRead;
		#endregion //Events

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="LineaTest.LineaDispatcher"/> class.
		/// </summary>
		public LineaDispatcher()
			:base()
		{
		}
		#endregion //Constructors

		#region Methods
		#region Overrides
		/// <summary>
		/// Called when the LineaPro scans a barcode.
		/// </summary>
		/// <param name="barcode">The string barcode data.</param>
		/// <param name="aType">The barcode type.</param>
		public override void BarcodeData (string barcode, int aType)
		{
			if ( BarcodeScanned != null )
				BarcodeScanned.Invoke (this, new BarcodeScannedEventArgs (barcode, (Barcodes)aType));
		}

		/// <summary>
		/// Called when the connection state of the LineaPro changes.
		/// </summary>
		/// <param name="state">The connection state.</param>
		public override void ConnectionState (ConnStates state)
		{
			if ( ConnectionStateChanged != null )
				ConnectionStateChanged.Invoke (this, new ConnectionStateChangedEventArgs(state));
		}

		/// <summary>
		/// Called when the LineaPro swipes a magcard and reads the data.
		/// </summary>
		public override void MagneticCardData (string track1, string track2, string track3)
		{
			if ( MagcardRead != null )
			{
				string FullData = string.Format ("{0}{1}{2}", track1 ?? "", track2 ?? "", track3 ?? "");
				MagcardRead.Invoke (this, new MagcardReadEventArgs(FullData) );
			}
		}
		#endregion //Overrides
		#endregion //Methods
	}

	#region Event argument classes
	/// <summary>
	/// The abstract base class from which all LineaPro events will inherit.
	/// </summary>
	public abstract class LineaEventArgs
		: EventArgs
	{
	}

	/// <summary>
	/// Event argument class created when the LineaPro scans a barcode.
	/// </summary>
	public class BarcodeScannedEventArgs
		: LineaEventArgs
	{
		/// <summary>
		/// Gets the barcode data string.
		/// </summary>
		public string Data { get; protected set; }

		/// <summary>
		/// Gets the type of barcode that was scanned.
		/// </summary>
		public Barcodes BarcodeType { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="LineaTest.BarcodeScannedEventArgs"/> class.
		/// </summary>
		public BarcodeScannedEventArgs(string Data, Barcodes BarcodeType)
		{
			this.Data = Data;
			this.BarcodeType = BarcodeType;
		}
	}

	/// <summary>
	/// Event argument class created when the LineaPro connection state changes.
	/// </summary>
	public class ConnectionStateChangedEventArgs
		: LineaEventArgs
	{
		/// <summary>
		/// Gets the device connection state.
		/// </summary>
		public ConnStates State { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="LineaTest.ConnectionStateChangedEventArgs"/> class.
		/// </summary>
		/// <param name="State">The connection state.</param>
		public ConnectionStateChangedEventArgs(ConnStates State)
		{
			this.State = State;
		}
	}

	/// <summary>
	/// Event argument class created when the LineaPro reads data from a magcard.
	/// </summary>
	public class MagcardReadEventArgs
		: LineaEventArgs
	{
		/// <summary>
		/// The data read from the magcard.
		/// </summary>
		public string Data { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="LineaTest.MagcardReadEventArgs"/> class.
		/// </summary>
		/// <param name="Data">The complete magcard data.</param>
		public MagcardReadEventArgs(string Data)
		{
			this.Data = Data;
		}
	}
	#endregion //Event argument classes
}

