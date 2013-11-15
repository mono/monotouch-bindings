// 
//  Copyright 2012  Clancey
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using Redpark;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

namespace HelloNetduino
{

	/*
	 * To use the following iPhone app you will need to deploy this sample to your Netduino
	 * 
	 * 
using System;
using System.IO.Ports;
using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace HelloRedPark
{
    public class Program
    {
        static SerialPort serial;
        static OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
        public static void Main()
        {
            // initialize the serial port for COM1 (using D0 & D1)
            serial = new SerialPort(SerialPorts.COM1, 9600, Parity.None, 8, StopBits.One);
            // open the serial-port, so we can send & receive data
            serial.Open();
            // add an event-handler for handling incoming data
            serial.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
            // wait forever...
            Thread.Sleep(Timeout.Infinite);


        }

        static string Buffer = string.Empty;
        static void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] bytes = new byte[serial.BytesToRead];
            serial.Read(bytes, 0, bytes.Length);
            Buffer += new string(Encoding.UTF8.GetChars(bytes));
    
            // Have we received a full line of data?
            int Pos = Buffer.IndexOf("\r\n");
            while (Pos >= 0)
            {
                var text = Buffer.Substring(0, Pos);
                //Clear out the old message;
                Buffer = Buffer.Substring(Pos + 2);
                Debug.Print(text);
                led.Write(text == "On");
                //Check for more messages
                Pos = Buffer.IndexOf("\r\n");
            }

           
        }
        static void writeLine(string line)
        {
            byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(line);

            // send the bytes over the serial-port
            serial.Write(utf8Bytes, 0, utf8Bytes.Length);
        }

    }
}

	 * */
	
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
	
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UIViewController viewController;
		UISwitch theSwitch;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		RscMgr rscMgr;
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			viewController = new UIViewController ();
			theSwitch = new UISwitch(new RectangleF((window.Frame.Width - 75)/2,(window.Frame.Height - 30)/2,75,30));
			theSwitch.ValueChanged += delegate(object sender, EventArgs e) {
				SentText(theSwitch.On ? "On" : "Off");
				Console.WriteLine("Switch changed");
			};
			rscMgr = new RscMgr();
			rscMgr.Delegate = new RedParkDelegate(rscMgr);
			rscMgr.Baud = 9600;
			Console.WriteLine("Baud {0}", rscMgr.Baud);
			rscMgr.SetParity(ParityType.None);
			rscMgr.SetStopBits(StopBitsType.One);

			viewController.View.AddSubview(theSwitch);
			window.RootViewController = viewController;
			window.MakeKeyAndVisible ();
			return true;
		}
		private void SentText(string s)
		{
			s += "\r\n";
			byte[] buffer = Encoding.UTF8.GetBytes(s);
			rscMgr.Write(buffer,0,buffer.Length);
//
//			NSData someData = new NSString(s).Encode(NSStringEncoding.UTF8);
//
//			IntPtr bytes = someData.Bytes;
//			var length = someData.Length;
//			
//			//loopbackCount = 0;
//			rscMgr.Write(bytes,length);
			//txCount += length; // JMB make sure stats display is accurrate using new test window
			//[self updateStats:kStatTx];

		}
	}

	public class RedParkDelegate : RscMgrDelegate{
		RscMgr Manager;
		public RedParkDelegate(RscMgr manager)
		{
			Manager = manager;
		}
		#region implemented abstract members of RscMgrDelegate

		public override void CableConnected (string protocol)
		{
			Console.WriteLine("Connected: {0}",protocol);
		}

		public override  void CableDisconnected ()
		{
			Console.WriteLine("Disconected");
		}

		public override void PortStatusChanged ()
		{
			Console.WriteLine("Status Changed");
		}

		public override void ReadBytesAvailable (int len)
		{
			Console.WriteLine("Bytes Available");
			byte[] bytes = new byte[len];
			Manager.Read(bytes,0,len);
			string line = System.Text.Encoding.UTF8.GetString(bytes);
			Console.WriteLine(line);
		}

		#endregion


	}

}
