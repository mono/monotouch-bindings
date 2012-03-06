using System;

namespace MagTek.iDynamo
{
	public enum MTSCRATransactionData
	{
		TLV_OPSTS,
		TLV_CARDSTS,
		TLV_TRACKSTS,
		
		TLV_CARDNAME,
		TLV_CARDIIN,
		TLV_CARDLAST4,
		TLV_CARDEXPDATE,
		TLV_CARDSVCCODE,
		TLV_CARDPANLEN,
		
		TLV_ENCTK1,
		TLV_ENCTK2,
		TLV_ENCTK3,
		
		TLV_DEVSN,
		TLV_DEVSNMAGTEK,
		TLV_DEVFW,
		TLV_DEVNAME,
		TLV_DEVCAPS,
		TLV_DEVSTATUS,
		TLV_TLVVERSION,
		TLV_DEVPARTNUMBER,
		
		TLV_CAPMSR,
		TLV_CAPTRACKS,
		TLV_CAPMAGSTRIPEENCRYPTION,
		
		TLV_KSN,
		TLV_CMAC,
	}
	
	public enum MTSCRATransactionStatus 
	{
		OK,
		Start,
		Error,
	}

	[Flags]
	public enum MTSCRATransactionEvent 
	{
		OK    = 1,
		Error = 2,
		Start = 4,
	}

	[Flags]
	public enum MTSCRACapabilities 
	{
		Masking       = 1,
		Encryption    = 2,
		CardAuth      = 4,
		DeviceAuth    = 8,
		SessionId     = 16,
		Discovery     = 32,
	}
	
	public enum MTSCRADeviceType 
	{
		MagTekAudioReader,
		MagTekIDynamo,
		MagTekNone,
	}

	public enum MTSCRACardDataContent
	{
		MaskedTrackData,
		DeviceEncryptionStatus,
		EncryptedTrack1,
		EncryptedTrack2,
		EncryptedTrack3,
		MagnePrintStatus,
		EncryptedMagnePrint,
		DeviceSerialNumber,
		EncryptedSessionId,
		DeviceKSN,
	}
}
