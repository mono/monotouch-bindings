using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreBluetooth;
using MonoTouch.CoreLocation;

//Wrapper around the EstimoteSDK for iOS 7 (libEstimoteSDK7.a) library
//The latest version of the library can always be found here:
//https://github.com/Estimote/iOS-SDK/tree/master/EstimoteSDK
namespace Estimote.iOS
{
	/// <summary>
	/// Estimote beacon delegate protocol.
	/// ESTBeaconDelegate defines beacon connection delegate methods. Connection is an asynchronous operation 
	/// so you need to be prepared that eg. beaconDidDisconnectWith: method can be invoked without previous action.
	/// </summary>
	[Model, BaseType (typeof (NSObject))]
	public partial interface ESTBeaconDelegate {

		/// <summary>
		/// Delegate method that indicates error in beacon connection.
		/// </summary>
		/// <param name="beacon">Reference to beacon object</param>
		/// <param name="error">Information about reason of error</param>
		[Export ("beaconConnectionDidFail:withError:")]
		void BeaconConnectionDidFail (ESTBeacon beacon, NSError error);

		/// <summary>
		/// Delegate method that indicates success in beacon connection.
		/// </summary>
		/// <param name="beacon">Reference to beacon object</param>
		[Export ("beaconConnectionDidSucceeded:")]
		void BeaconConnectionDidSucceeded(ESTBeacon beacon);

		/// <summary>
		/// Delegate method that beacon did disconnect with device.
		/// </summary>
		/// <param name="beacon">Reference to beacon object</param>
		/// <param name="error">Information about reason of error</param>
		[Export ("beaconDidDisconnect:withError:")]
		void BeaconDidDisconnect (ESTBeacon beacon, NSError error);
	}

	public delegate void ESTCompletionBlock(NSError error);
	public delegate void ESTUnsignedCompletionBlock(byte value, NSError error);
	public delegate void ESTBoolCompletionBlock(bool value, NSError error);
	public delegate void ESTStringCompletionBlock(NSString value, NSError error);

	/// <summary>
	/// The ESTBeacon class represents a beacon that was encountered during region monitoring.
	/// You do not create instances of this class directly. The ESTBeaconManager object reports
	/// encountered beacons to its associated delegate object. You can use the information in a beacon 
	/// object to identify which beacon was encountered.
	/// ESTBeacon class contains basic Apple CLBeacon object reference as well as some additional functionality.
	/// It allows to connect with Estimote beacon to read / write its characteristics.
	/// </summary>
	[BaseType (typeof (NSObject))]
	public partial interface ESTBeacon {

		[Export ("firmwareState")]
		ESTBeaconFirmwareState FirmwareState { get; set; }

		//The ESTBeaconManager object reports encountered beacons to this associated delegate object.
		[Export ("delegate")]
		ESTBeaconDelegate Delegate { get; set; }

		///////////////////////////////////////////////////////
		// Bluetooth beacon available when used with startEstimoteBeaconsDiscoveryForRegion:
		[Export ("peripheral", ArgumentSemantic.Retain)]
		CBPeripheral Peripheral { get; set; }

		[Export ("macAddress", ArgumentSemantic.Retain)]
		string MacAddress { get; set; }

		[Export ("measuredPower", ArgumentSemantic.Retain)]
		NSNumber MeasuredPower { get; set; }

		[Export ("major", ArgumentSemantic.Retain)]
		NSNumber Major { get; set; }

		[Export ("minor", ArgumentSemantic.Retain)]
		NSNumber Minor { get; set; }

		[Export ("rssi", ArgumentSemantic.Retain)]
		NSNumber Rssi { get; set; }

		/////////////////////////////////////////////////////
		// Properties filled when characteristics are read
		[Export ("power", ArgumentSemantic.Retain)]
		NSNumber Power { get; set; }

		[Export ("frequency", ArgumentSemantic.Retain)]
		NSNumber Frequency { get; set; }

		[Export ("batteryLevel", ArgumentSemantic.Retain)]
		NSNumber BatteryLevel { get; set; }

		[Export ("hardwareVersion", ArgumentSemantic.Retain)]
		string HardwareVersion { get; set; }

		[Export ("firmwareVersion", ArgumentSemantic.Retain)]
		string FirmwareVersion { get; set; }

		/////////////////////////////////////////////////////
		// Core location properties
		[Export ("ibeacon", ArgumentSemantic.Retain)]
		CLBeacon Ibeacon { get; set; }

		[Export ("isConnected")]
		bool IsConnected { get; }

		// Connect to particular beacon using bluetooth.
		// Connection is required to change values like
		// Major, Minor, Power and Frequency.
		[Export ("connectToBeacon")]
		void ConnectToBeacon ();

		// Disconnect device with particular beacon
		[Export ("disconnectBeacon")]
		void DisconnectBeacon ();

		/// <summary>
		/// Read major of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Block with major value as param</param>
		[Export ("readBeaconMajorWithCompletion:")]
		void ReadBeaconMajorWithCompletion (ESTUnsignedCompletionBlock completion);

		/// <summary>
		/// Read minor of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Block with minor value as param</param>
		[Export ("readBeaconMinorWithCompletion:")]
		void ReadBeaconMinorWithCompletion (ESTUnsignedCompletionBlock completion);

		/// <summary>
		/// Read frequency of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Block with frequency value as param</param>
		[Export ("readBeaconFrequencyWithCompletion:")]
		void ReadBeaconFrequencyWithCompletion (ESTUnsignedCompletionBlock completion);

		/// <summary>
		/// Read power of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Block with power value as param</param>
		[Export ("readBeaconPowerWithCompletion:")]
		void ReadBeaconPowerWithCompletion (ESTUnsignedCompletionBlock completion);

		/// <summary>
		///  Read battery level of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Block with battery level value as param</param>
		[Export ("readBeaconBatteryWithCompletion:")]
		void ReadBeaconBatteryWithCompletion (ESTUnsignedCompletionBlock completion);

		/// <summary>
		/// Read firmware version of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Block with firmware version value as param</param>
		[Export ("readBeaconFirmwareVersionWithCompletion:")]
		void ReadBeaconFirmwareVersionWithCompletion (ESTStringCompletionBlock completion);

		/// <summary>
		/// Read hardware version of connected beacon (Previous connection required)
		/// </summary>
		/// <param name="completion">Block with hardware version value as param</param>
		[Export ("readBeaconHardwareVersionWithCompletion:")]
		void ReadBeaconHardwareVersionWithCompletion (ESTStringCompletionBlock completion);

		/// <summary>
		/// Writes major param to bluetooth connected beacon.
		/// </summary>
		/// <param name="major">major major beacon value</param>
		/// <param name="completion">Block handling operation completion</param>
		[Export ("writeBeaconMajor:withCompletion:")]
		void WriteBeaconMajor (short major, ESTUnsignedCompletionBlock completion);

		/// <summary>
		/// Writes minor param to bluetooth connected beacon.
		/// </summary>
		/// <param name="minor">minor minor beacon value</param>
		/// <param name="completion">Block handling operation completion</param>
		[Export ("writeBeaconMinor:withCompletion:")]
		void WriteBeaconMinor (short minor, ESTUnsignedCompletionBlock completion);

		/// <summary>
		/// Writes frequency of bluetooth connected beacon.
		/// </summary>
		/// <param name="frequency">Advertising beacon frequency</param>
		/// <param name="completion">Block handling operation completion</param>
		[Export ("writeBeaconFrequency:withCompletion:")]
		void WriteBeaconFrequency (short frequency, ESTUnsignedCompletionBlock completion);

		/// <summary>
		/// Writes power of bluetooth connected beacon.
		/// </summary>
		/// <param name="power">Power advertising beacon power</param>
		/// <param name="completion">Block handling operation completion</param>
		[Export ("writeBeaconPower:withCompletion:")]
		void WriteBeaconPower (ESTBeaconPower power, ESTUnsignedCompletionBlock completion);

		/// <summary>
		/// Verifies if new firmware version is available for download
		/// and updates firmware of connected beacon. Internet connection 
		/// is required to pass this process.
		/// </summary>
		/// <param name="progress">Block handling operation progress</param>
		/// <param name="completion">Block handling operation completion</param>
		[Export ("updateBeaconFirmwareWithProgress:andCompletion:")]
		void UpdateBeaconFirmwareWithProgress (ESTStringCompletionBlock progress, ESTCompletionBlock completion);
	}

	/// <summary>
	/// A ESTBeaconRegion object defines a type of region that is based on the device’s proximity to a Bluetooth beacon, 
	/// as opposed to a geographic location. A beacon region looks for devices whose identifying information matches the information you provide. 
	/// When that device comes in range, the region triggers the delivery of an appropriate notification.
	/// You can monitor beacon regions in two ways. To receive notifications when a device enters or exits 
	/// the vicinity of a beacon, use the startMonitoringForRegion: method of your location manager object. 
	/// While a beacon is in range, you can also call the startRangingBeaconsInRegion: method to begin receiving 
	/// notifications when the relative distance to the beacon changes.
	///	ESTBeaconRegion extends basic CLBeaconRegion Core Location object, allowing to directly initialize 
	/// region that is supported by Estimote Cloud platform.
	/// </summary>
	[BaseType (typeof (CLBeaconRegion))]
	public partial interface ESTBeaconRegion {

		/// <summary>
		/// Initialize an Estimote beacon region. Major and minor values will be wildcarded.
		/// </summary>
		/// <param name="identifier">Region identifier</param>
		[Export ("initRegionWithIdentifier:")]
		IntPtr Constructor (string identifier);

		/// <summary>
		/// Initialize an Estimote beacon region with major value. Minor value will be wildcarded.
		/// </summary>
		/// <param name="major">Major location value</param>
		/// <param name="identifier">Region identifier</param>
		[Export ("initRegionWithMajor:identifier:")]
		IntPtr Constructor (ushort major, string identifier);

		/// <summary>
		/// Initialize a Estimote beacon region identified by a major and minor values.
		/// </summary>
		/// <param name="major">Major location value. Represents the most significant value in a beacon.</param>
		/// <param name="minor">Minor location value. Represents the least significant value in a beacon.</param>
		/// <param name="identifier">Region identifier</param>
		[Export ("initRegionWithMajor:minor:identifier:")]
		IntPtr Constructor (ushort major, ushort minor, string identifier);
	}
	
	/// <summary>
	/// The ESTBeaconManagerDelegate protocol defines the delegate methods to respond to related events.
	/// </summary>
	[Model, BaseType (typeof (NSObject))]
	public partial interface ESTBeaconManagerDelegate {

		/// <summary>
		/// Delegate method invoked during ranging. 
		/// Allows to retrieve NSArray of all discovered beacons
		/// represented with ESTBeacon objects.
		/// </summary>
		/// <param name="manager">Estimote beacon manager</param>
		/// <param name="beacons">All beacons as ESTBeacon objects</param>
		/// <param name="region">Estimote beacon region</param>
		[Export ("beaconManager:didRangeBeacons:inRegion:")]
		void DidRangeBeacons (ESTBeaconManager manager, NSArray [] beacons, ESTBeaconRegion region);

		/// <summary>
		/// Delegate method invoked when ranging fails for particular region. Related NSError object passed.
		/// </summary>
		/// <param name="manager">Estimote beacon manager</param>
		/// <param name="region">Estimote beacon region</param>
		/// <param name="error">Object containing error info</param>
		[Export ("beaconManager:rangingBeaconsDidFailForRegion:withError:")]
		void RangingBeaconsDidFailForRegion (ESTBeaconManager manager, ESTBeaconRegion region, NSError error);

		/// <summary>
		/// Delegate method invoked when monitoring fails for particular region. Related NSError object passed.
		/// </summary>
		/// <param name="manager">Estimote beacon manager</param>
		/// <param name="region">Estimote beacon region</param>
		/// <param name="error">Object containing error info</param>
		[Export ("beaconManager:monitoringDidFailForRegion:withError:")]
		void MonitoringDidFailForRegion (ESTBeaconManager manager, ESTBeaconRegion region, NSError error);

		/// <summary>
		/// Method triggered when iOS device enters estimote beacon region during monitoring.
		/// </summary>
		/// <param name="manager">Estimote beacon manager</param>
		/// <param name="region">Estimote beacon region</param>
		[Export ("beaconManager:didEnterRegion:")]
		void DidEnterRegion (ESTBeaconManager manager, ESTBeaconRegion region);

		//Beware! There is a bug in Apple's CLLocation API (that is used under the hood by the Estimote library).
		//http://beekn.net/2013/11/apple-ibeacon-bugs-complicate-bluetooth-le-experience/
		//Your app is likely to lose range of beacons for brief instances and will briefly report didExitRegion before quickly returning to being in range.
		//Your app will sometimes make the wrong ‘guess’ as to which proximity region it’s in before eventually correcting itself. It will sometimes 
		//report Proximity == near when you’re “immediate” or “immediate” when you’re “near” and then flip itself back to the correct value.
		//To solve this would require some sort of hack on your side or a fix from Apple.
		/// <summary>
		/// Method triggered when iOS device leaves estimote beacon region during monitoring.
		/// </summary>
		/// <param name="manager">Estimote beacon manager</param>
		/// <param name="region">Estimote beacon region</param>
		[Export ("beaconManager:didExitRegion:")]
		void DidExitRegion (ESTBeaconManager manager, ESTBeaconRegion region);

		/// <summary>
		/// Method triggered when estimote beacon region state was determined using requestStateForRegion:
		/// </summary>
		/// <param name="manager">Estimote beacon manager</param>
		/// <param name="state">Estimote beacon region state</param>
		/// <param name="region">Estimote beacon region</param>
		[Export ("beaconManager:didDetermineState:forRegion:")]
		void DidDetermineState (ESTBeaconManager manager, CLRegionState state, ESTBeaconRegion region);

		/// <summary>
		/// Method triggered when device starts advertising as iBeacon.
		/// </summary>
		/// <param name="manager">Estimote beacon manager</param>
		/// <param name="error">Info about any error</param>
		[Export ("beaconManagerDidStartAdvertising:error:")]
		void BeaconManagerDidStartAdvertising (ESTBeaconManager manager, NSError error);

		/// <summary>
		/// Delegate method invoked to handle discovered ESTBeacon objects using CoreBluetooth framework
		/// in particular region.
		/// </summary>
		/// <param name="manager">Estimote beacon manager</param>
		/// <param name="beacons">All beacons as ESTBeacon objects</param>
		/// <param name="region">Estimote beacon region</param>
		[Export ("beaconManager:didDiscoverBeacons:inRegion:")]
		void DidDiscoverBeacons (ESTBeaconManager manager, NSArray [] beacons, ESTBeaconRegion region);

		/// <summary>
		/// Delegate method invoked when CoreBluetooth based discovery process fails.
		/// </summary>
		/// <param name="manager">Estimote beacon manager</param>
		/// <param name="region">Estimote beacon region</param>
		[Export ("beaconManager:didFailDiscoveryInRegion:")]
		void DidFailDiscoveryInRegion (ESTBeaconManager manager, ESTBeaconRegion region);
	}

	/// <summary>
	/// The ESTBeaconManager class defines the interface for handling and configuring the estimote beacons 
	/// and get related events to your application. You use an instance of this class to establish the 
	/// parameters that describes each beacon behavior. You can also use a beacon manager object to retrieve all beacons in range.
	///
	/// A beacon manager object provides support for the following location-related activities:
	/// - Monitoring distinct regions of interest and generating location events when the user enters or leaves those regions (works in background mode).
	/// - Reporting the range to nearby beacons and ther distance for the device.
	/// </summary>
	[BaseType (typeof (CLLocationManagerDelegate))]
	public partial interface ESTBeaconManager
	{
		[Export ("delegate", ArgumentSemantic.Assign)]
		ESTBeaconManagerDelegate Delegate { get; set; }

		//Allows to avoid beacons with unknown state (proximity == 0), when ranging. Default value is false.
		[Export ("avoidUnknownStateBeacons")]
		bool AvoidUnknownStateBeacons { get; set; }

		[Export ("virtualBeaconRegion", ArgumentSemantic.Retain)]
		ESTBeaconRegion VirtualBeaconRegion { get; set; }

		/// <summary>
		/// Range all Estimote beacons that are visible in range.
		/// Delegate method beaconManager:didRangeBeacons:inRegion: 
		/// is used to retrieve found beacons. Returned NSArray contains 
		/// ESTBeacon objects.
		/// </summary>
		/// <param name="region">Estimote beacon region</param>
		[Export ("startRangingBeaconsInRegion:")]
		void StartRangingBeaconsInRegion (ESTBeaconRegion region);

		/// <summary>
		/// Start monitoring for particular region.
		/// Functionality works in the background mode as well.
		/// Every time you enter or leave region appropriate
		/// delegate method invoked: beaconManager:didEnterRegion:
		/// and beaconManager:didExitRegion:
		/// </summary>
		/// <param name="region">Estimote beacon region</param>
		[Export ("startMonitoringForRegion:")]
		void StartMonitoringForRegion (ESTBeaconRegion region);

		/// <summary>
		/// Stops ranging Estimote beacons.
		/// </summary>
		/// <param name="region">Estimote beacon region</param>
		[Export ("stopRangingBeaconsInRegion:")]
		void StopRangingBeaconsInRegion (ESTBeaconRegion region);

		/// <summary>
		/// Unsubscribe application from iOS monitoring of Estimote beacon region.
		/// </summary>
		/// <param name="region">Estimote beacon region</param>
		[Export ("stopMonitoringForRegion:")]
		void StopMonitoringForRegion (ESTBeaconRegion region);

		/// <summary>
		/// Allows to validate current state for particular region.
		/// </summary>
		/// <param name="region">Estimote beacon region</param>
		[Export ("requestStateForRegion:")]
		void RequestStateForRegion (ESTBeaconRegion region);

		/// <summary>
		/// Allows to turn iPhone device into virtual estimote beacon.
		/// </summary>
		/// <param name="major">Major beacon value</param>
		/// <param name="minor">Minor beacon value</param>
		/// <param name="identifier">Unique identifier for your region</param>
		[Export ("startAdvertisingWithMajor:withMinor:withIdentifier:")]
		void StartAdvertisingWithMajor (ushort major, ushort minor, string identifier);

		/// <summary>
		/// Stop advertising the iPhone device as virtual estimote beacon.
		/// </summary>
		[Export ("stopAdvertising")]
		void StopAdvertising ();

		/// <summary>
		/// Start beacon discovery process based on CoreBluetooth 
		/// framework. Method is useful for older beacons discovery 
		/// that are not advertising as iBeacons.
		/// </summary>
		/// <param name="region">estimote beacon region</param>
		[Export ("startEstimoteBeaconsDiscoveryForRegion:")]
		void StartEstimoteBeaconsDiscoveryForRegion (ESTBeaconRegion region);

		/// <summary>
		/// Stops CoreBluetooth based beacon discovery process.
		/// </summary>
		[Export ("stopEstimoteBeaconDiscovery")]
		void StopEstimoteBeaconDiscovery ();
	}
}
