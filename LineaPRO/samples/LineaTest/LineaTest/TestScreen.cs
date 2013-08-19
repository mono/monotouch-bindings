using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using LineaProSdk;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text.RegularExpressions;

namespace LineaTest
{
	public partial class TestScreen : UIViewController
	{
		/// <summary>
		/// Gets or sets the LineaPro device object.
		/// </summary>
		Linea LineaDevice { get; set; }

		/// <summary>
		/// Gets or sets the Linea dispacther delegate extension, which invokes events.
		/// </summary>
		/// <value>The linea dispatcher.</value>
		LineaDispatcher LineaDispatcher { get; set; }

		readonly UIColor DisconnectedColor = UIColor.FromRGB (142, 27, 32);
		readonly UIColor ConnectingColor = UIColor.FromRGB (255,206,3);
		readonly UIColor ConnectedColor = UIColor.FromRGB (43,174,52);

		readonly int[] BarcodeTone = new int[] {1046,80,1397,80};

		UILabel ConnectionLabel {get; set; }
		UILabel ScanTypeLabel {get; set; }
		UILabel ScanDataLabel {get; set; }

		public TestScreen () : base ("TestScreen", null)
		{
			View.BackgroundColor = DisconnectedColor;

			ConnectionLabel = new UILabel (new RectangleF(10,10,View.Frame.Width-20,40));
			ConnectionLabel.BackgroundColor = UIColor.Clear;
			ConnectionLabel.TextAlignment = UITextAlignment.Center;
			ConnectionLabel.AdjustsFontSizeToFitWidth = true;
			ConnectionLabel.Font = UIFont.BoldSystemFontOfSize (26);
			ConnectionLabel.Text = "Linea disconnected";
			ConnectionLabel.TextColor = UIColor.FromRGB (245, 245, 245);
			View.Add (ConnectionLabel);

			ScanTypeLabel = new UILabel (new RectangleF(10,70,View.Frame.Width-20,40));
			ScanTypeLabel.BackgroundColor = UIColor.Clear;
			ScanTypeLabel.TextAlignment = UITextAlignment.Center;
			ScanTypeLabel.AdjustsFontSizeToFitWidth = true;
			ScanTypeLabel.Font = UIFont.BoldSystemFontOfSize (26);
			ScanTypeLabel.Text = "";
			ScanTypeLabel.TextColor = UIColor.FromRGB (245, 245, 245);
			View.Add (ScanTypeLabel);

			ScanDataLabel = new UILabel (new RectangleF(10,130,View.Frame.Width-20,40));
			ScanDataLabel.BackgroundColor = UIColor.Clear;
			ScanDataLabel.TextAlignment = UITextAlignment.Center;
			ScanDataLabel.AdjustsFontSizeToFitWidth = true;
			ScanDataLabel.Font = UIFont.BoldSystemFontOfSize (20);
			ScanDataLabel.Text = "";
			ScanDataLabel.TextColor = UIColor.FromRGB (245, 245, 245);
			View.Add (ScanDataLabel);
			
			LineaDevice = Linea.SharedDevice;
			LineaDispatcher = new LineaDispatcher ();

			LineaDispatcher.ConnectionStateChanged += HandleConnectionStateChanged;
			LineaDispatcher.BarcodeScanned += HandleBarcodeScanned;
			LineaDispatcher.MagcardRead += HandleMagcardRead;

			LineaDevice.AddDelegate (LineaDispatcher);
			LineaDevice.Connect ();
		}

		void HandleBarcodeScanned (LineaDelegate Dispatcher, BarcodeScannedEventArgs Arguments)
		{
			Console.WriteLine (string.Format("Barcode scanned: {0} ({1})",Arguments.Data,Arguments.BarcodeType));
			ScanTypeLabel.Text = string.Format("Barcode ({0})",Arguments.BarcodeType);
			ScanDataLabel.Text = Arguments.Data;
		}

		void HandleConnectionStateChanged (LineaDelegate Dispatcher, ConnectionStateChangedEventArgs Arguments)
		{
			switch (Arguments.State)
			{
				case ConnStates.Disconnected:
					Console.WriteLine ("LineaPro disconnected.");
					View.BackgroundColor = DisconnectedColor;
					ConnectionLabel.Text = "Linea disconnected";
					break;
				case ConnStates.Connecting:
					Console.WriteLine ("LineaPro connecting...");
					View.BackgroundColor = ConnectingColor;
					ConnectionLabel.Text = "Linea connecting";
					break;
				case ConnStates.Connected:
					Console.WriteLine ("LineaPro connected.");
					View.BackgroundColor = ConnectedColor;
					ConnectionLabel.Text = "Linea connected!";
					break;

			}
		}

		void HandleMagcardRead (LineaDelegate Dispatcher, MagcardReadEventArgs Arguments)
		{
			Console.WriteLine (string.Format("Magcard swiped: {0}",Arguments.Data));

			PlayLineaSound(LineaDevice, 100, BarcodeTone);

			string CardNumber = ParseMagcardData (Arguments.Data);
			if ( CardNumber == null )
			{
				ScanTypeLabel.Text = "Magcard (Error)";
				ScanDataLabel.Text = "Could not parse!";
			}
			else
			{				
				ScanTypeLabel.Text = "Magcard";
				ScanDataLabel.Text = CardNumber;
			}
		}

		string ParseMagcardData(string RawData)
		{
			Regex MagcardRegex = new Regex (@"^%B(\d+)\^");
			Match NumberMatch = MagcardRegex.Match (RawData);
			if ( !NumberMatch.Success )
				return null;
			return NumberMatch.Groups [1].Value;
		}

		/// <summary>
		/// Plays a sound through the Linea device
		/// </summary>
		/// <returns><c>true</c>, if successful, <c>false</c> otherwise.</returns>
		/// <param name="Device">The targeted device.</param>
		/// <param name="Volume">The sound volume.</param>
		/// <param name="Tones">An even-length array of integers, where the odd elements are frequencies and the even elements are durations.</param>
		public static bool PlayLineaSound(Linea Device, int Volume, int[] Tones)
		{
			//An error object that may be created if the "play sound" attempt is unsuccessful.
			NSError Error;

			//Attempts to play the sound, providing the volume, the tones, and an output error.
			bool Success = Device.PlaySound (Volume, Tones, out Error);

			//Writing the error if one occurred.
			if (Error != null)
				Console.WriteLine (Error.LocalizedDescription);

			return Success;
		}
	}
}