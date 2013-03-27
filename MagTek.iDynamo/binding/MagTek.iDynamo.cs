using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.AudioToolbox;
using MonoTouch.AudioUnit;
using MonoTouch.ExternalAccessory;

namespace MagTek.iDynamo
{
	/// <summary>
	/// Magtek IDynamo Objective C Wrapper class.
	/// </summary>
	[BaseType (typeof (NSObject))]
	interface MTSCRA
	{ 
		/// <summary>
		/// Opens the connection to the card reader.
		/// </summary>
		/// <returns>
		/// True if successful, otherwise false.
		/// </returns>
		[Export ("openDevice")]
		bool OpenDevice ();
		
		/// <summary>
		/// Close the connection to the card reader.
		/// </summary>
		/// <returns>
		/// True if successful, otherwise false.
		/// </returns>
		[Export ("closeDevice")]
		bool CloseDevice ();
		
		/// <summary>
		/// Gets whether the card reader is currently connected.
		/// </summary>
		[Export ("isDeviceConnected")]
		bool IsDeviceConnected { get; }
		
		/// <summary>
		/// Get stored masked track1 data.
		/// </summary>
		/// <returns>
		/// The track 1 masked data.
		/// </returns>
		[Export ("getTrack1Masked")]
		string GetTrack1Masked ();

		/// <summary>
		/// Get stored masked track2 data.
		/// </summary>
		/// <returns>
		/// The track 2 masked data.
		/// </returns>
		[Export ("getTrack2Masked")]
		string GetTrack2Masked ();

		/// <summary>
		/// Get stored masked track3 data.
		/// </summary>
		/// <returns>
		/// The track 3 masked data.
		/// </returns>
		[Export ("getTrack3Masked")]
		string GetTrack3Masked ();
		
		/// <summary>
		/// Get stored masked tracks data.
		/// </summary>
		/// <returns>
		/// The masked track data.
		/// </returns>
		[Export ("getMaskedTracks")]
		string GetMaskedTracks ();
		
		/// <summary>
		/// Get stored encrypted track1 data.
		/// </summary>
		/// <returns>
		/// The track1 data.
		/// </returns>
		[Export ("getTrack1")]
		string GetTrack1 ();

		/// <summary>
		/// Get stored encrypted track2 data.
		/// </summary>
		/// <returns>
		/// The track2 data.
		/// </returns>
		[Export("getTrack2")]
		string GetTrack2();

		/// <summary>
		/// Get stored encrypted track3 data.
		/// </summary>
		/// <returns>
		/// The track3 data.
		/// </returns>
		[Export("getTrack3")]
		string GetTrack3();
		
		/// <summary>
		/// Get stored MagnePrint.
		/// </summary>
		/// <returns>
		/// Encrypted magne print.
		/// </returns>
		[Export ("getMagnePrint")]
		string GetMagnePrint ();
		
		/// <summary>
		/// Get stored MagnePrintStatus.
		/// </summary>
		/// <returns>
		/// Magne print status.
		/// </returns>
		[Export ("getMagnePrintStatus")]
		string GetMagnePrintStatus ();
		
		/// <summary>
		/// Receives Device Serial Number.
		/// </summary>
		/// <returns>
		/// Serial Number.
		/// </returns>
		[Export ("getDeviceSerial")]
		string GetDeviceSerial ();

		/// <summary>
		/// Receives Magtek Device Serial Number.
		/// </summary>
		/// <returns>
		/// Serial Number.
		/// </returns>
		[Export ("getMagTekDeviceSerial")]
		string GetMagTekDeviceSerial ();

		/// <summary>
		/// Receives the firmware version.
		/// </summary>
		/// <returns>
		/// The firmware version.
		/// </returns>
		[Export ("getFirmware")]
		string GetFirmware ();

		/// <summary>
		/// Receives the device name.
		/// </summary>
		/// <returns>
		/// The device name.
		/// </returns>
		[Export ("getDeviceName")]
		string GetDeviceName ();

		/// <summary>
		/// Receives the device capabilities.
		/// </summary>
		/// <returns>
		/// The device capabilities.
		/// </returns>
		[Export ("getDeviceCaps")]
		string GetDeviceCaps ();

		/// <summary>
		/// Receives the device status.
		/// </summary>
		/// <returns>
		/// The device status.
		/// </returns>
		[Export ("getDeviceStatus")]
		string GetDeviceStatus ();

		/// <summary>
		/// Receives the TLV Version.
		/// </summary>
		/// <returns>
		/// The TLV Version.
		/// </returns>
		[Export ("getTLVVersion")]
		string GetTLVVersion ();
		
		/// <summary>
		/// Receives the device part number.
		/// </summary>
		/// <returns>
		/// The device part number.
		/// </returns>
		[Export ("getDevicePartNumber")]
		string GetDevicePartNumber ();
		
		/// <summary>
		/// Receives Key Serial Number.
		/// </summary>
		/// <returns>
		/// Key Serial Number.
		/// </returns>
		[Export ("getKSN")]
		string GetKSN ();
		
		/// <summary>
		/// Retrieve individual tag value, only supported in audio reader
		/// </summary>
		[Export ("getTagValue:")]
		string GetTagValue (MTSCRATransactionData tag);
		
		/// <summary>
		/// Retrieve MSR Capability.
		/// </summary>
		[Export ("getCapMSR")]
		string GetCapMSR ();
		
		/// <summary>
		/// Retrieve Tracks Capability.
		/// </summary>
		[Export ("getCapTracks")]
		string GetCapTracks ();
		
		/// <summary>
		/// Retrieve MagStripe Encryption Capability
		/// </summary>
		[Export ("getCapMagStripeEncryption")]
		string GetCapMagStripeEncryption ();
		
		/// <summary>
		/// Sends the command to the device.
		/// </summary>
		/// <param name='pData'>
		/// Command.
		/// </param>
		[Export ("sendCommandToDevice:")]
		void SendCommandToDevice (string pData);
		
		/// <summary>
		/// Sets the protocol String for iDynamo
		/// </summary>
		/// <param name='pData'>
		/// Protocol String.
		/// </param>
		[Export ("setDeviceProtocolString:")]
		void SetDeviceProtocolString (string pData);
		
		/// <summary>
		/// Listens for events.
		/// </summary>
		/// <param name='events'>
		/// The events to list for.
		/// </param>
		[Export ("listenForEvents:")]
		void ListenForEvents (MTSCRATransactionEvent events);
		
		/// <summary>
		/// Get the device type.
		/// </summary>
		[Export ("getDeviceType")]
		MTSCRADeviceType GetDeviceType ();
		
		/// <summary>
		/// Retrieves the Length of the PAN
		/// </summary>
		[Export ("getCardPANLength")]
		int GetCardPANLength ();
		
		/// <summary>
		/// Receives Session Id.
		/// </summary>
		/// <returns>
		/// Session Id.
		/// </returns>
		[Export ("getSessionID")]
		string GetSessionID ();
		
		/// <summary>
		/// Retrieve the whole response from the reader.
		/// </summary>
		[Export ("getResponseData")]
		string GetResponseData ();
		
		/// <summary>
		/// Retrieves the name in the card.
		/// </summary>
		[Export ("getCardName")]
		string GetCardName ();
		
		/// <summary>
		/// Retrieves the IIN in the card.
		/// </summary>
		[Export ("getCardIIN")]
		string GetCardIIN ();

		/// <summary>
		/// Retrieves the Last 4 of the PAN
		/// </summary>
		[Export ("getCardLast4")]
		string GetCardLast4 ();

		/// <summary>
		/// Retrieves the Expiration Date.
		/// </summary>
		[Export ("getCardExpDate")]
		string GetCardExpDate ();

		/// <summary>
		/// Retrieves the card service code.
		/// </summary>
		[Export ("getCardServiceCode")]
		string GetCardServiceCode ();
		
		/// <summary>
		/// Retrieves the card status.
		/// </summary>
		[Export ("getCardStatus")]
		string GetCardStatus ();
		
		/// <summary>
		/// Retrieves the track decode status.
		/// </summary>
		[Export ("getTrackDecodeStatus")]
		string GetTrackDecodeStatus ();
		
		/// <summary>
		/// Retrieves the response type.
		/// </summary>
		[Export ("getResponseType")]
		string GetResponseType ();
		
		/// <summary>
		/// Sets the type of device.
		/// </summary>
		/// <param name='deviceType'>
		/// Protocol String.
		/// </param>
		[Export ("setDeviceType:")]
		void SetDeviceType (MTSCRADeviceType deviceType);
		
		/// <summary>
		/// Retrieves whether the device is opened.
		/// </summary>
		[Export ("isDeviceOpened")]
		bool IsDeviceOpened ();
		
		/// <summary>
		/// Clears all the buffer that is stored during card swipe or command response.
		/// </summary>
		[Export ("clearBuffers")]
		void ClearBuffers ();
	}
}
