// 
// MagTekDemoViewController.cs
//  
// Author: Jeffrey Stedfast <jeff@xamarin.com>
// 
// Copyright (c) 2012 Xamarin Inc.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 
using System;
using System.Text;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using MagTek.iDynamo;

namespace MagTekDemo
{
	public partial class MagTekDemoViewController : UIViewController
	{
		static NSString trackDataReadyNotification = new NSString ("trackDataReadyNotification");
		static NSString devConnectionNotification = new NSString ("devConnectionNotification");
		static Selector devConnStatusChangeSel = new Selector ("devConnStatusChange");
		static Selector trackDataReadySel = new Selector ("trackDataReady:");
		static NSString statusKey = new NSString ("status");
		const string kRevVersion = "rev. 1.0.3.0";
		
		long glSwipeCount = 0;
		MTSCRA mtSCRALib;
		
		public MagTekDemoViewController (MTSCRA lib) : base ("MagTekDemoViewController", null)
		{
			mtSCRALib = lib;
		}
		
		void ClearLabels ()
		{
			transStatus.Text = "";
			responseData.Text = "";
			rawResponseData.Text = "";
		}
		
		void DisplayData ()
		{
			StringBuilder response = new StringBuilder ();
			
			transStatus.Text = "Transaction Done.";
			if (mtSCRALib.GetDeviceType () == MTSCRADeviceType.MagTekAudioReader) {
				glSwipeCount++;
				
				response.AppendFormat ("SwipeCount={0}\n", glSwipeCount);
				response.AppendFormat ("Response.Type={0}\n", mtSCRALib.GetResponseType ());
				response.AppendFormat ("Track.Status={0}\n", mtSCRALib.GetTrackDecodeStatus ());
				response.AppendFormat ("Track.Masked: {0}\n", mtSCRALib.GetMaskedTracks ());
				response.AppendFormat ("Track1.Masked: {0}\n", mtSCRALib.GetTrack1Masked ());
				response.AppendFormat ("Track2.Masked: {0}\n", mtSCRALib.GetTrack2Masked ());
				response.AppendFormat ("Track1.Encrypted: {0}\n", mtSCRALib.GetTrack1 ());
				response.AppendFormat ("Track2.Encrypted: {0}\n", mtSCRALib.GetTrack2 ());
				response.AppendFormat ("Track3.Encrypted: {0}\n", mtSCRALib.GetTrack3 ());
				response.AppendFormat ("Card.IIN: {0}\n", mtSCRALib.GetCardIIN ());
				response.AppendFormat ("Card.Name: {0}\n", mtSCRALib.GetCardName ());
				response.AppendFormat ("Card.Last4: {0}\n", mtSCRALib.GetCardLast4 ());
				response.AppendFormat ("Card.ExpDate: {0}\n", mtSCRALib.GetCardExpDate ());
				response.AppendFormat ("Card.SvcCode: {0}\n", mtSCRALib.GetCardServiceCode ());
				response.AppendFormat ("Card.PANLength: {0}\n", mtSCRALib.GetCardPANLength ());
				response.AppendFormat ("KSN: {0}\n", mtSCRALib.GetKSN ());
				response.AppendFormat ("Device.SerialNumber: {0}\n", mtSCRALib.GetDeviceSerial ());
				response.AppendFormat ("TLV.CARDIIN: {0}\n", mtSCRALib.GetTagValue (MTSCRATransactionData.TLV_CARDIIN));
				response.AppendFormat ("MagTek SN: {0}\n", mtSCRALib.GetMagTekDeviceSerial ());
				response.AppendFormat ("Firmware Part Number: {0}\n", mtSCRALib.GetFirmware ());
				response.AppendFormat ("TLV Version: {0}\n", mtSCRALib.GetTLVVersion ());
				response.AppendFormat ("Device Model Name: {0}\n", mtSCRALib.GetDeviceName ());
				response.AppendFormat ("Capability MSR: {0}\n", mtSCRALib.GetCapMSR ());
				response.AppendFormat ("Capability Tracks: {0}\n", mtSCRALib.GetCapTracks ());
				response.AppendFormat ("Capability Encryption: {0}\n", mtSCRALib.GetCapMagStripeEncryption ());
				
				responseData.Text = response.ToString ();
				rawResponseData.Text = mtSCRALib.GetResponseData ();
			} else {
				response.AppendFormat ("Track.Masked: {0}\n", mtSCRALib.GetMaskedTracks ());
				response.AppendFormat ("Track1.Masked: {0}\n", mtSCRALib.GetTrack1Masked ());
				response.AppendFormat ("Track2.Masked: {0}\n", mtSCRALib.GetTrack2Masked ());
				response.AppendFormat ("Track1.Encrypted: {0}\n", mtSCRALib.GetTrack1 ());
				response.AppendFormat ("Track2.Encrypted: {0}\n", mtSCRALib.GetTrack2 ());
				response.AppendFormat ("Track3.Encrypted: {0}\n", mtSCRALib.GetTrack3 ());
				response.AppendFormat ("Card.IIN: {0}\n", mtSCRALib.GetCardIIN ());
				response.AppendFormat ("Card.Name: {0}\n", mtSCRALib.GetCardName ());
				response.AppendFormat ("Card.Last4: {0}\n", mtSCRALib.GetCardLast4 ());
				response.AppendFormat ("Card.ExpDate: {0}\n", mtSCRALib.GetCardExpDate ());
				response.AppendFormat ("Card.SvcCode: {0}\n", mtSCRALib.GetCardServiceCode ());
				response.AppendFormat ("Card.PANLength: {0}\n", mtSCRALib.GetCardPANLength ());
				response.AppendFormat ("KSN: {0}\n", mtSCRALib.GetKSN ());
				response.AppendFormat ("Device.SerialNumber: {0}\n", mtSCRALib.GetDeviceSerial ());
				response.AppendFormat ("MagnePrint: {0}\n", mtSCRALib.GetMagnePrint ());
				response.AppendFormat ("MagnePrintStatus: {0}\n", mtSCRALib.GetMagnePrintStatus ());
				response.AppendFormat ("SessionID: {0}\n", mtSCRALib.GetSessionID ());
				response.AppendFormat ("Device Model Name: {0}\n", mtSCRALib.GetDeviceName ());
				
				responseData.Text = response.ToString ();
				rawResponseData.Text = mtSCRALib.GetResponseData ();
			}
		}
		
		partial void OnClearScreen (NSObject sender)
		{
			command.Text = "";
			ClearLabels ();
			
			mtSCRALib.ClearBuffers ();
			glSwipeCount = 0;
		}
		
		partial void OnDisplayResponse (NSObject sender)
		{
			//DisplayData ();
			/*
			if (mtSCRALib.IsDeviceConnected) {
				if (mtSCRALib.IsDeviceOpened) {
					Console.WriteLine ("closeDevice");
					mtSCRALib.CloseDevice ();
				} else {
					Console.WriteLine ("openDevice");
					mtSCRALib.OpenDevice ();
				}
			}*/
		}
		
		partial void OnSendMessageToDevice (NSObject sender)
		{
			mtSCRALib.SendCommandToDevice (command.Text);
		}
		
		void OnDataEvent (MTSCRATransactionStatus status)
		{
			// ClearLabels ();
			
			Console.WriteLine ("Transaction Status = {0}", status);
			
			switch (status) {
			case MTSCRATransactionStatus.OK:
				DisplayData ();
				break;
			case MTSCRATransactionStatus.Start:
				transStatus.Text = "Card Swiped.";
				break;
			case MTSCRATransactionStatus.Error:
				transStatus.Text = "Bad Swipe.";
				break;
			default:
				break;
			}
		}
		
		[Export ("trackDataReady:")]
		void TrackDataReady (NSNotification notification)
		{
			NSNumber status = (NSNumber) notification.UserInfo.ValueForKey (statusKey);
			InvokeOnMainThread (delegate {
				OnDataEvent ((MTSCRATransactionStatus) status.IntValue);
			});
		}
		
		[Export ("devConnStatusChange")]
		void DevConnStatusChange ()
		{
			if (mtSCRALib.IsDeviceConnected) {
				deviceStatus.Text = "Device Connected";
			} else {
				deviceStatus.Text = "Device Disconnected";
			}
		}
		
		bool OnShouldReturn (UITextField field)
		{
			command.ResignFirstResponder ();
			return true;
		}
		
		public override void ViewDidLoad ()
		{
			NSNotificationCenter.DefaultCenter.AddObserver (this, trackDataReadySel, trackDataReadyNotification, null);
			NSNotificationCenter.DefaultCenter.AddObserver (this, devConnStatusChangeSel, devConnectionNotification, null);
			
			DevConnStatusChange ();
			
			scrollView.ContentSize = new SizeF (320, 1000);
			
			ClearLabels ();
			
			revVersion.Text = kRevVersion;
			command.ShouldReturn += OnShouldReturn;
			
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

